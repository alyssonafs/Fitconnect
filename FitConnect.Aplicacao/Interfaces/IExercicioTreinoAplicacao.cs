using FitConnect.Dominio.Entidades;

namespace FitConnect.Aplicacao.Interfaces
{
    public interface IExercicioTreinoAplicacao
    {
        Task<int> CriarAsync(ExercicioTreino exercicioTreino);

        Task AtualizarAsync(ExercicioTreino exercicioTreino);

        Task<ExercicioTreino> ObterPorIdAsync(int exercicioTreinoId);

        Task<IEnumerable<ExercicioTreino>> ListarAsync();

        Task DeletarAsync(int exercicioTreinoId);

        Task DeletarPorTreinoEExercicioAsync(int treinoId, int exercicioId);

        Task<List<ExercicioTreinoDto>> ListarPorTreinoAsync(int treinoId);

    }
}