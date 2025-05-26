using FitConnect.Dominio.Enumeradores;

namespace FitConnect.Api.Models.Requisicao.Usuario
{
    public class UsuarioAtualizar
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TiposUsuario TipoUsuario { get; set; }
        public TiposGenero Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}