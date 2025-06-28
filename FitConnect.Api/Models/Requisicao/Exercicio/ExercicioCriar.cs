using FitConnect.Dominio.Enumeradores;

namespace FitConnect.Api.Models.Requisicao.Exercicio
{
    public class ExercicioCriar
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public TiposGruposMusculares GrupoMuscular { get; set; }

        public string Descricao { get; set; }

        public string VideoURL { get; set; }

    }
}