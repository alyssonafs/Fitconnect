using FitConnect.Dominio.Entidades;

namespace FitConnect.Repositorio.DataAccess.Interfaces
{
    public interface IExercicioTreinoRepositorio
    {
        Task<int> SalvarAsync(ExercicioTreino exercicioTreino);

        Task AtualizarAsync(ExercicioTreino exercicioTreino);

        Task<ExercicioTreino> ObterPorIdAsync(int exercicioTreinoId);

        Task<IEnumerable<ExercicioTreino>> ListarAsync();

        Task DeletarAsync(ExercicioTreino exercicioTreino);

        Task<ExercicioTreino> ObterPorTreinoEExercicioAsync(int treinoId, int exercicioId);

        Task<List<ExercicioTreino>> ListarPorTreinoAsync(int treinoId);

    }
}