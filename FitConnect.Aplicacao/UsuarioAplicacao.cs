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

            if(!String.IsNullOrEmpty(usuario.Nome))
            {
                usuarioDominio.Nome = usuario.Nome;
            }

            if (!String.IsNullOrEmpty(usuario.Email))
            {
                usuarioDominio.Email = usuario.Email;
            }

            if (Enum.IsDefined(typeof(TiposUsuario), usuario.TipoUsuario))
            {
                usuarioDominio.TipoUsuario = usuario.TipoUsuario;
            }

            if (Enum.IsDefined(typeof(TiposGenero), usuario.Genero))
            {
                usuarioDominio.Genero = usuario.Genero;
            }

            if (!String.IsNullOrEmpty(usuario.DataNascimento.ToString()))
            {
                usuarioDominio.DataNascimento = usuario.DataNascimento;
            }

            if (!String.IsNullOrEmpty(usuario.Peso.ToString()))
            {
                usuarioDominio.Peso = usuario.Peso;
            }

            if (!String.IsNullOrEmpty(usuario.Altura.ToString()))
            {
                usuarioDominio.Altura = usuario.Altura;
            }

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
            var usuarioDominio = await _usuarioRepositorio.ObterPorIdTodosAsync(usuarioId);

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            if (usuarioDominio.Ativo == false)
            {
                throw new Exception("Usuário já deletado!");
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
            var usuarioDominio = await _usuarioRepositorio.ObterPorIdTodosAsync(usuarioId);            

            if (usuarioDominio == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            if (usuarioDominio.Ativo == true)
            {
                throw new Exception("Usuário já está ativo!");
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
                throw new Exception("O campo tipo usuário não pode ser vazio ou opção inválida!");
            }
            if (!Enum.IsDefined(typeof(TiposGenero), usuario.Genero))
            {
                throw new Exception("O campo gênero não pode ser vazio ou opção inválida!");
            }
            if (String.IsNullOrEmpty(usuario.DataNascimento.ToString()))
            {
                throw new Exception("O campo data de nascimento não pode ser vazio!");
            }
        }

        #endregion
    }
}