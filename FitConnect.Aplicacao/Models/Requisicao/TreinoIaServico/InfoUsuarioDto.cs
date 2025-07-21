using FitConnect.Dominio.Enumeradores;

namespace FitConnect.Aplicacao.Models.Requisicao.TreinoIaServico
{
    public class InfoUsuarioDto
    {
        public double Altura { get; set; }
        public double Peso { get; set; }
        public int Idade { get; set; }
        public double IMC { get; set; }
        public TiposGenero Genero { get; set; }
    }
}