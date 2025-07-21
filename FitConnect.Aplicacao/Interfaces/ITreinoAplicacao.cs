using FitConnect.Aplicacao.Models.Requisicao.TreinoIaServico;
using FitConnect.Dominio.Entidades;

namespace FitConnect.Aplicacao.Interfaces
{
    public interface ITreinoAplicacao
    {
        Task<int> CriarAsync(Treino treino);

        Task AtualizarAsync(Treino treino);

        Task<Treino> ObterPorIdAsync(int treinoId);

        Task<IEnumerable<Treino>> ListarAsync(bool ativo);

        Task<IEnumerable<Treino>> ListarTreinosPersonal(int personalId);

        Task DeletarAsync(int treinoId);

        Task RestaurarAsync(int usuarioId);

        Task<IEnumerable<TreinoStoredProcedure>> ListarPorGrupoMuscularAsync(int grupoMuscular, int usuarioId);

        Task<int> SalvarTreinoGeradoIaAsync(int personalId, PlanoTreinoDto planoTreinoDto);

    }
}