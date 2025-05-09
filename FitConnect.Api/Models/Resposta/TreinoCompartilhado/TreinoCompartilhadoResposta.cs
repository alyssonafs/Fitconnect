namespace FitConnect.Api.Models.Resposta.TreinoCompartilhado
{
    public class TreinoCompartilhadoResposta
    {
        public int Id { get; set; }

        public int TreinoId { get; set; }

        public int AlunoId { get; set; }

        public DateTime DataCompartilhamento { get; set; }
    }
}