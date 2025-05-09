namespace FitConnect.Api.Models.Resposta.ExercicioTreino
{
    public class ExercicioTreinoResposta
    {
        public int Id { get; set; }

        public string Serie { get; set; }

        public int TreinoId { get; set; }

        public int ExercicioId { get; set; }
    }
}