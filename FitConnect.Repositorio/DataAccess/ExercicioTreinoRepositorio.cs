using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitConnect.Repositorio.DataAccess
{
    public class ExercicioTreinoRepositorio : BaseRepositorio, IExercicioTreinoRepositorio
    {
        public ExercicioTreinoRepositorio(FitConnectContexto contexto) : base(contexto)
        {

        }
        public async Task AtualizarAsync(ExercicioTreino exercicioTreino)
        {
            _contexto.ExerciciosTreinos.Update(exercicioTreino);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarAsync(ExercicioTreino exercicioTreino)
        {
            _contexto.ExerciciosTreinos.Remove(exercicioTreino);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExercicioTreino>> ListarAsync()
        {
            return await _contexto.ExerciciosTreinos.ToListAsync();
        }

        public async Task<ExercicioTreino> ObterPorIdAsync(int exercicioTreinoId)
        {
            return await _contexto.ExerciciosTreinos
                            .Where(et => et.Id == exercicioTreinoId)
                            .FirstOrDefaultAsync();
        }

        public async Task<ExercicioTreino> ObterPorTreinoEExercicioAsync(int treinoId, int exercicioId)
        {
            return await _contexto.ExerciciosTreinos.FirstOrDefaultAsync(et => et.TreinoId == treinoId && et.ExercicioId == exercicioId);
        }

        public async Task<List<ExercicioTreino>> ListarPorTreinoAsync(int treinoId)
        {
            return await _contexto.ExerciciosTreinos
                                    .Include(et => et.Exercicio)
                                    .Where(et => et.TreinoId == treinoId)
                                    .ToListAsync();
        }

        public async Task<int> SalvarAsync(ExercicioTreino exercicioTreino)
        {
            await _contexto.ExerciciosTreinos.AddAsync(exercicioTreino);
            await _contexto.SaveChangesAsync();

            return exercicioTreino.Id;
        }
    }
}