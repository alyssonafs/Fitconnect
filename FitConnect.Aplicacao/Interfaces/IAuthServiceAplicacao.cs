using FitConnect.Dominio.Entidades;

namespace FitConnect.Aplicacao.Interfaces
{
    public interface IAuthServiceAplicacao
    {
        Task<string> GerarToken(Usuario usuario);

        Task<Usuario> ValidarUsuario(string email, string senha);

        Task<string> SolicitarRecuperacaoAsync(string email);

        Task RedefinirSenhaAsync(string email, string novaSenha, string confirmarSenha);
    }
}