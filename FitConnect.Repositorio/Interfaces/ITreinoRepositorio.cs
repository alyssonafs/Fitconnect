using FitConnect.Dominio.Entidades;

namespace FitConnect.Repositorio.DataAccess.Interfaces
{
    public interface ITreinoRepositorio
    {
        Task<int> SalvarAsync(Treino treino);

        Task AtualizarAsync(Treino treino);

        Task<Treino> ObterPorId(int treinoId);

        Task<IEnumerable<Treino>> ListarAsync();

        Task DeletarAsync(Treino treino);

    }
}