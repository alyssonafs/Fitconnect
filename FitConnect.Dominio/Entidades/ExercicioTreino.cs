namespace FitConnect.Dominio.Entidades
{
    public class ExercicioTreino
    {
        public int Id { get; set; }

        public string Serie { get; set; }

        public int TreinoId { get; set; }

        public int ExercicioId { get; set; }

        public Treino Treino { get; set; }

        public Exercicio Exercicio { get; set; }
    }
}