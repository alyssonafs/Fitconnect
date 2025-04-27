using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Contexto;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Repositorio.DataAccess
{
    public class TreinoRepositorio : BaseRepositorio, ITreinoRepositorio
    {
        public TreinoRepositorio(FitConnectContexto contexto) : base(contexto)
        {
            
        }
        public Task AtualizarAsync(Treino treino)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<Treino>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Treino> ObterPorId(int treinoId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SalvarAsync(Treino treino)
        {
            throw new NotImplementedException();
        }
    }
}