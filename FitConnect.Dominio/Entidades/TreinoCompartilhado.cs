namespace FitConnect.Dominio.Entidades
{
    public class TreinoCompartilhado
    {
        public int Id { get; set; }

        public int TreinoId { get; set; }

        public int AlunoId { get; set; }

        public DateTime DataCompartilhamento { get; set; }

        public Treino Treino { get; set; }

        public Usuario Usuario { get; set; }

        public TreinoCompartilhado()
        {
            DataCompartilhamento = DateTime.Now;
        }
    }
}