using FitConnect.Dominio.Enumeradores;

namespace FitConnect.Api.Models.Resposta.Usuario
{
    public class UsuarioResposta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TiposUsuario TipoUsuario { get; set; }
    }
}