using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Contexto;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Repositorio.DataAccess
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(FitConnectContexto contexto) : base(contexto)
        {
            
        }
        public Task AtualizarAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<Usuario>> ListarAsync(bool ativo)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterPorId(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SalvarAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}