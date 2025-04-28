using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Contexto;
using FitConnect.Repositorio.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitConnect.Repositorio.DataAccess
{
    public class TreinoCompartilhadoRepositorio : BaseRepositorio, ITreinoCompartilhadoRepositorio
    {
        public TreinoCompartilhadoRepositorio(FitConnectContexto contexto) : base(contexto)
        {
            
        }
        public async Task AtualizarAsync(TreinoCompartilhado treinoCompartilhado)
        {
            _contexto.TreinosCompartilhados.Update(treinoCompartilhado);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarAsync(TreinoCompartilhado treinoCompartilhado)
        {
            _contexto.TreinosCompartilhados.Remove(treinoCompartilhado);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<TreinoCompartilhado>> ListarAsync()
        {
            return await _contexto.TreinosCompartilhados.ToListAsync();
        }

        public async Task<TreinoCompartilhado> ObterPorId(int treinoCompartilhadoId)
        {
            return await _contexto.TreinosCompartilhados
                            .Where(tc => tc.Id == treinoCompartilhadoId)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SalvarAsync(TreinoCompartilhado treinoCompartilhado)
        {
            await _contexto.TreinosCompartilhados.AddAsync(treinoCompartilhado);
            await _contexto.SaveChangesAsync();

            return treinoCompartilhado.Id;
        }
    }
}