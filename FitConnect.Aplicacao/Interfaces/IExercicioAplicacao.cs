using FitConnect.Dominio.Entidades;

namespace FitConnect.Aplicacao.Interfaces
{
    public interface IExercicioAplicacao
    {
        Task<int> CriarAsync(Exercicio exercicio);

        Task AtualizarAsync(Exercicio exercicio);

        Task<Exercicio> ObterPorIdAsync(int exercicioId);

        Task<IEnumerable<Exercicio>> ListarAsync();

        Task DeletarAsync(Exercicio exercicio);

    }
}