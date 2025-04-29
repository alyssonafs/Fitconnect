using FitConnect.Dominio.Entidades;

namespace FitConnect.Aplicacao.Interfaces
{
    public interface IUsuarioAplicacao
    {
        Task<int> CriarAsync(Usuario usuario);

        Task AtualizarAsync(Usuario usuario);

        Task<Usuario> ObterPorIdAsync(int usuarioId);

        Task<Usuario> ObterPorEmailAsync(string email);

        Task<IEnumerable<Usuario>> ListarAsync(bool ativo);

        Task DeletarAsync(int usuarioId);

        Task RestaurarAsync(int usuarioId);

    }
}