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

        public Task AtualizarAsync(Usuario usuario)
        {
            throw new NotImplementedException();
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

        public Task DeletarAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> ListarAsync(bool ativo)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterPorIdAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task RestaurarAsync(int usuarioId)
        {
            throw new NotImplementedException();
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