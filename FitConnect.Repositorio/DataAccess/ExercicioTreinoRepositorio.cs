using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Contexto;
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

        public async Task<ExercicioTreino> ObterPorId(int exercicioTreinoId)
        {
            return await _contexto.ExerciciosTreinos
                            .Where(et => et.Id == exercicioTreinoId)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SalvarAsync(ExercicioTreino exercicioTreino)
        {
            await _contexto.ExerciciosTreinos.AddAsync(exercicioTreino);
            await _contexto.SaveChangesAsync();

            return exercicioTreino.Id;
        }
    }
}