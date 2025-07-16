using FitConnect.Dominio.Entidades;
using FitConnect.Dominio.Enumeradores;

namespace FitConnect.Repositorio.DataAccess.Interfaces
{
    public interface IExercicioRepositorio
    {
        Task<int> SalvarAsync(Exercicio exercicio);

        Task AtualizarAsync(Exercicio exercicio);

        Task<Exercicio> ObterPorIdAsync(int exercicioId);

        Task<IEnumerable<Exercicio>> ListarAsync(bool ativo);

        Task DeletarAsync(Exercicio exercicio);

        Task<List<Exercicio>> BuscarPorGrupoMuscularAsync(TiposGruposMusculares grupo);

    }
}
