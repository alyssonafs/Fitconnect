using FitConnect.Dominio.Enumeradores;

namespace FitConnect.Aplicacao.Models.Requisicao.TreinoIaServico
{
    public class TreinoRequisicaoDto
    {
        public int PersonalId { get; set; }
        public int UsuarioAlvoId { get; set; }
        public InfoUsuarioDto UsuarioAlvoInfo { get; set; }
        public string Objetivo { get; set; }

        public List<TiposGruposMusculares> GruposMusculares { get; set; }
        public List<ExercicioDto> ExerciciosDisponiveis { get; set; }

    }
}