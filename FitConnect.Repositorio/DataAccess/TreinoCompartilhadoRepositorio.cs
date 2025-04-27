using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Contexto;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Repositorio.DataAccess
{
    public class TreinoCompartilhadoRepositorio : BaseRepositorio, ITreinoCompartilhadoRepositorio
    {
        public TreinoCompartilhadoRepositorio(FitConnectContexto contexto) : base(contexto)
        {
            
        }
        public Task AtualizarAsync(TreinoCompartilhado treinoCompartilhado)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<TreinoCompartilhado>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TreinoCompartilhado> ObterPorId(int treinoCompartilhadoId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SalvarAsync(TreinoCompartilhado treinoCompartilhado)
        {
            throw new NotImplementedException();
        }
    }
}