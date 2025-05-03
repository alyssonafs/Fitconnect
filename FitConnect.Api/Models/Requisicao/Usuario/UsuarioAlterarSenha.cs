namespace FitConnect.Api.Models.Requisicao.Usuario
{
    public class UsuarioAlterarSenha
    {
        public int Id { get; set; }
        public string Senha { get; set;}
        public string SenhaAntiga { get; set; }
    }
}