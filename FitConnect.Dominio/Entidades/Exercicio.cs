namespace FitConnect.Dominio.Entidades
{
    public class Exercicio
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Serie { get; set; }

        public string Descricao { get; set; }

        public string VideoURL { get; set; }

        public int TreinoId { get; set; }
    }
}