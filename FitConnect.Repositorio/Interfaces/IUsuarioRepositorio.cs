using FitConnect.Dominio.Entidades;

namespace FitConnect.Repositorio.DataAccess.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<int> SalvarAsync(Usuario usuario);

        Task AtualizarAsync(Usuario usuario);

        Task<Usuario> ObterPorId(int usuarioId);

        Task<Usuario> ObterPorEmailAsync(string email);

        Task<IAsyncEnumerable<Usuario>> ListarAsync(bool ativo);

    }
}