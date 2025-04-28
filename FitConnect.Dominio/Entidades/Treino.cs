namespace FitConnect.Dominio.Entidades
{
    public class Treino
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int PersonalId { get; set; }

        public List<TreinoCompartilhado> TreinosCompartilhados { get; set; }

        public List<ExercicioTreino> ExerciciosTreino { get; set; }

        public Usuario Personal { get; set; }
    }
}