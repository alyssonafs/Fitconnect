namespace FitConnect.Api.Models.Requisicao.ExercicioTreino
{
    public class ExercicioTreinoCriar
    {
        public int Id { get; set; }

        public string Serie { get; set; }

        public int TreinoId { get; set; }

        public int ExercicioId { get; set; }
    }
}