using FitConnect.Dominio.Enumeradores;

namespace FitConnect.Dominio.Entidades
{
    public class Exercicio
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public TiposGruposMusculares GrupoMuscular { get; set; }

        public string Descricao { get; set; }

        public string VideoURL { get; set; }

        public bool Ativo { get; set; }

        public List<ExercicioTreino> ExerciciosTreino { get; set; }

        public Exercicio()
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