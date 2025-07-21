using FitConnect.Dominio.Enumeradores;

namespace FitConnect.Aplicacao.Models.Requisicao.TreinoIaServico
{
    public class ExercicioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TiposGruposMusculares GrupoMuscular { get; set; }
    }
}