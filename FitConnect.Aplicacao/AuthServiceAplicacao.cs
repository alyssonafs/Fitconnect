using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FitConnect.Aplicacao
{
    public class AuthServiceAplicacao : IAuthServiceAplicacao
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AuthServiceAplicacao(IConfiguration config, IUsuarioRepositorio usuarioRepositorio)
        {
            _config = config;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<string> GerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim("usuarioId", usuario.Id.ToString()),
                new Claim("email", usuario.Email),
                new Claim("nome", usuario.Nome)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var exp = DateTime.UtcNow.AddHours(4);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: exp,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task RedefinirSenhaAsync(string email, string novaSenha, string confirmarSenha)
        {
            if (novaSenha.Length < 6)
            {
                throw new Exception("A senha deve conter no mínimo 6 caracteres.");
            }

            if (novaSenha != confirmarSenha)
            {
                throw new Exception("As senhas não coincidem.");
            }

            var usuario = await _usuarioRepositorio.ObterPorEmailAsync(email);

            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(novaSenha);

            await _usuarioRepositorio.AtualizarAsync(usuario);
        }

        public async Task<string> SolicitarRecuperacaoAsync(string email)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPorEmailAsync(email);

            if (usuarioDominio == null)
            {
                throw new Exception("E-mail não cadastrado");
            }

            return usuarioDominio.Email;
        }

        public async Task<Usuario> ValidarUsuario(string email, string senha)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPorEmailAsync(email);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            bool senhaValida = BCrypt.Net.BCrypt.Verify(senha, usuarioDominio.Senha);

            if (!senhaValida)
            {
                throw new Exception("Senha inválida.");
            }

            return usuarioDominio;
        }
    }
}