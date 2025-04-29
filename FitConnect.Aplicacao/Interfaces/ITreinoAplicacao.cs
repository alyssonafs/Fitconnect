using FitConnect.Dominio.Entidades;

namespace FitConnect.Aplicacao.Interfaces
{
    public interface ITreinoAplicacao
    {
        Task<int> CriarAsync(Treino treino);

        Task AtualizarAsync(Treino treino);

        Task<Treino> ObterPorIdAsync(int treinoId);

        Task<IEnumerable<Treino>> ListarAsync();

        Task DeletarAsync(Treino treino);

    }
}