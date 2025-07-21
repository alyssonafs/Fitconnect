namespace FitConnect.Aplicacao.Models.Requisicao.TreinoIaServico
{
    public class PlanoTreinoDto
    {
        public string Nome { get; set; } = null;
        public List<ExercicioTreinoDto> Exercicios { get; set; } = new();
    }
}