using FitConnect.Dominio.Entidades;

namespace FitConnect.Aplicacao.Interfaces
{
    public interface ITreinoCompartilhadoAplicacao
    {
        Task<int> CriarAsync(TreinoCompartilhado treinoCompartilhado);

        Task AtualizarAsync(TreinoCompartilhado treinoCompartilhado);

        Task<TreinoCompartilhado> ObterPorIdAsync(int treinoCompartilhadoId);

        Task<IEnumerable<TreinoCompartilhado>> ListarAsync();

        Task<IEnumerable<TreinoCompartilhado>> ListarTreinosAluno(int alunoId);

        Task DeletarAsync(int treinoCompartilhadoId);

    }
}