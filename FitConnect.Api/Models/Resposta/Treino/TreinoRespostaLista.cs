namespace FitConnect.Api.Models.Resposta.Treino
{
    public class TreinoRespostaLista
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int PersonalId { get; set; }

        public string PersonalNome { get; set; }

        public int QuantidadeExercicios { get; set; }

        public int TempoEstimado { get; set; }
    }
}