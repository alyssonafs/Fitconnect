using System.Formats.Asn1;
using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitConnect.Repositorio.DataAccess
{
    public class TreinoRepositorio : BaseRepositorio, ITreinoRepositorio
    {
        public TreinoRepositorio(FitConnectContexto contexto) : base(contexto)
        {
            
        }
        public async Task AtualizarAsync(Treino treino)
        {
            _contexto.Treinos.Update(treino);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarAsync(Treino treino)
        {
            _contexto.Treinos.Remove(treino);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Treino>> ListarAsync(bool ativo)
        {
            return await _contexto.Treinos.Where(t => t.Ativo == ativo).ToListAsync();
        }

        public async Task<IEnumerable<Treino>> ListarTreinosPersonal(int personalId)
        {
            return await _contexto.Treinos.Where(t => t.PersonalId == personalId)
                                            .Where(t => t.Ativo == true)
                                            .ToListAsync();
        }

        public async Task<Treino> ObterPorIdAsync(int treinoId)
        {
            return await _contexto.Treinos
                            .Where(t => t.Id == treinoId)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SalvarAsync(Treino treino)
        {
            await _contexto.Treinos.AddAsync(treino);
            await _contexto.SaveChangesAsync();

            return treino.Id;
        }
    }
}