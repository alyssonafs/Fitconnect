using FitConnect.Dominio.Entidades;

namespace FitConnect.Repositorio.DataAccess.Interfaces
{
    public interface ITreinoRepositorio
    {
        Task<int> SalvarAsync(Treino treino);

        Task AtualizarAsync(Treino treino);

        Task<Treino> ObterPorIdAsync(int treinoId);

        Task<IEnumerable<Treino>> ListarAsync(bool ativo);

        Task DeletarAsync(Treino treino);

    }
}