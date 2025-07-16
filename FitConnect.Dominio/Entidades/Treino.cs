namespace FitConnect.Dominio.Entidades
{
    public class Treino
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int PersonalId { get; set; }

        public bool Ativo { get; set; }

        public bool GeradoPorIa { get; set; }

        public List<TreinoCompartilhado> TreinosCompartilhados { get; set; }

        public List<ExercicioTreino> ExerciciosTreino { get; set; }

        public Usuario Personal { get; set; }

        public Treino()
        {
            Ativo = true;
        }

        public void Deletar()
        {
            Ativo = false;
        }

        public void Restaurar()
        {
            Ativo = true;
        }
    }
}