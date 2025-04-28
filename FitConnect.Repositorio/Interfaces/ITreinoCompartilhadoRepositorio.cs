using FitConnect.Dominio.Entidades;

namespace FitConnect.Repositorio.DataAccess.Interfaces
{
    public interface ITreinoCompartilhadoRepositorio
    {
        Task<int> SalvarAsync(TreinoCompartilhado treinoCompartilhado);

        Task AtualizarAsync(TreinoCompartilhado treinoCompartilhado);

        Task<TreinoCompartilhado> ObterPorId(int treinoCompartilhadoId);

        Task<IEnumerable<TreinoCompartilhado>> ListarAsync();

        Task DeletarAsync(TreinoCompartilhado treinoCompartilhado);

    }
}