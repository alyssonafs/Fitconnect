using FitConnect.Dominio.Entidades;

namespace FitConnect.Repositorio.DataAccess.Interfaces
{
    public interface IExercicioRepositorio
    {
        Task<int> SalvarAsync(Exercicio exercicio);

        Task AtualizarAsync(Exercicio exercicio);

        Task<Exercicio> ObterPorId(int exercicioId);

        Task<IEnumerable<Exercicio>> ListarAsync();

        Task DeletarAsync(Exercicio exercicio);

    }
}
