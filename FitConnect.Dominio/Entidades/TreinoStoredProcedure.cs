namespace FitConnect.Dominio.Entidades
{
    public class TreinoStoredProcedure
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PersonalId { get; set; }
        public bool Ativo { get; set; }
        public string PersonalNome { get; set; }
        public int QuantidadeExercicios { get; set; }
        public int TempoEstimado { get; set; }
    }
}