using FitConnect.Dominio.Entidades;

namespace FitConnect.Repositorio.DataAccess.Interfaces
{
    public interface IExercicioTreinoRepositorio
    {
        Task<int> SalvarAsync(ExercicioTreino exercicioTreino);

        Task AtualizarAsync(ExercicioTreino exercicioTreino);

        Task<ExercicioTreino> ObterPorId(int exercicioTreinoId);

        Task<IAsyncEnumerable<ExercicioTreino>> ListarAsync();

    }
}