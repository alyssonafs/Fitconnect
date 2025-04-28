using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Contexto;
using FitConnect.Repositorio.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitConnect.Repositorio.DataAccess
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(FitConnectContexto contexto) : base(contexto)
        {
            
        }
        public async Task AtualizarAsync(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarAsync(Usuario usuario)
        {
            _contexto.Usuarios.Remove(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeleteLogicoAsync(Usuario usuario)
        {
            usuario.Ativo = false;
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> ListarAsync(bool ativo)
        {
            return await _contexto.Usuarios.Where(u => u.Ativo == ativo).ToListAsync();
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _contexto.Usuarios
                        .Where(u => u.Email == email)
                        .Where(u => u.Ativo)
                        .FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterPorId(int usuarioId)
        {
            return await _contexto.Usuarios
                            .Where(u => u.Id == usuarioId)
                            .Where(u => u.Ativo)
                            .FirstOrDefaultAsync();
        }

        public async Task RestaurarAsync(Usuario usuario)
        {
            usuario.Ativo = true;
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task<int> SalvarAsync(Usuario usuario)
        {
            await _contexto.Usuarios.AddAsync(usuario);
            await _contexto.SaveChangesAsync();

            return usuario.Id;
        }
    }
}