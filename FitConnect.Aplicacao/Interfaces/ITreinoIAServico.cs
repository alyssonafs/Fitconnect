using FitConnect.Aplicacao.Models.Requisicao.TreinoIaServico;

namespace FitConnect.Aplicacao.Interfaces
{
    public interface ITreinoIAServico
    {
        Task<PlanoTreinoDto> GerarTreinoAsync(TreinoRequisicaoDto treinoRequisicaoDto);
    }
}