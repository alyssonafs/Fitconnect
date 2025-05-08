using FitConnect.Dominio.Entidades;

namespace FitConnect.Repositorio.DataAccess.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<int> SalvarAsync(Usuario usuario);

        Task AtualizarAsync(Usuario usuario);

        Task<Usuario> ObterPorIdAsync(int usuarioId);
        Task<Usuario> ObterPorIdTodosAsync(int usuarioId);

        Task<Usuario> ObterPorEmailAsync(string email);

        Task<IEnumerable<Usuario>> ListarAsync(bool ativo);

        Task DeletarAsync(Usuario usuario);

    }
}