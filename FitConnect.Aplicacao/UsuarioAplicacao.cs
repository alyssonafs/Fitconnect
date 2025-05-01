using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Dominio.Enumeradores;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPorIdAsync(usuario.Id);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            ValidarCamposUsuario(usuario);

            usuarioDominio.Nome = usuario.Nome;
            usuarioDominio.Email = usuario.Email;
            usuarioDominio.TipoUsuario = usuario.TipoUsuario;

            await _usuarioRepositorio.AtualizarAsync(usuarioDominio);
        }

        public async Task<int> CriarAsync(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("Usuário não pode ser vazio!");
            }
            if (String.IsNullOrEmpty(usuario.Senha))
            {
                throw new Exception("Campo senha não pode ser vazio!");
            }

            ValidarCamposUsuario(usuario);

            return await _usuarioRepositorio.SalvarAsync(usuario);

        }

        public async Task DeletarAsync(int usuarioId)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPorIdAsync(usuarioId);

            if (usuarioDominio.Ativo == false)
            {
                throw new Exception("Usuário já deletado!");
            }

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            usuarioDominio.Deletar();

            await _usuarioRepositorio.AtualizarAsync(usuarioDominio);
        }

        public async Task<IEnumerable<Usuario>> ListarAsync(bool ativo)
        {
            return await _usuarioRepositorio.ListarAsync(ativo);
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPorEmailAsync(email);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            return usuarioDominio;
        }

        public async Task<Usuario> ObterPorIdAsync(int usuarioId)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPorIdAsync(usuarioId);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            return usuarioDominio;
        }

        public async Task RestaurarAsync(int usuarioId)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPorIdAsync(usuarioId);

            if (usuarioDominio.Ativo == true)
            {
                throw new Exception("Usuário já está ativo!");
            }

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            usuarioDominio.Restaurar();

            await _usuarioRepositorio.AtualizarAsync(usuarioDominio);
        }

        public async Task AlterarSenhaAsync(Usuario usuario, string senhaAntiga)
        {
            var usuarioDominio = await _usuarioRepositorio.ObterPorIdAsync(usuario.Id);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            if (usuarioDominio.Senha != senhaAntiga)
            {
                throw new Exception("Senha antiga inválida");
            }

            usuarioDominio.Senha = usuario.Senha;

            await _usuarioRepositorio.AtualizarAsync(usuarioDominio);
        }

        #region Util

        private static void ValidarCamposUsuario(Usuario usuario)
        {
            if (String.IsNullOrEmpty(usuario.Nome))
            {
                throw new Exception("O campo nome não pode ser vazio!");
            }
            if (String.IsNullOrEmpty(usuario.Email))
            {
                throw new Exception("O campo e-mail não pode ser vazio!");
            }
            if (!Enum.IsDefined(typeof(TiposUsuario), usuario.TipoUsuario))
            {
                throw new Exception("O campo tipo usuário não pode ser vazio!");
            }
        }

        #endregion
    }
}