using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitConnect.Repositorio.DataAccess
{
    public class ExercicioRepositorio : BaseRepositorio, IExercicioRepositorio
    {
        public ExercicioRepositorio(FitConnectContexto contexto) : base(contexto)
        {
            
        }
        public async Task AtualizarAsync(Exercicio exercicio)
        {
            _contexto.Exercicios.Update(exercicio);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarAsync(Exercicio exercicio)
        {
            _contexto.Exercicios.Remove(exercicio);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercicio>> ListarAsync(bool ativo)
        {
            return await _contexto.Exercicios.Where(e => e.Ativo == ativo).ToListAsync();
        }

        public async Task<Exercicio> ObterPorIdAsync(int exercicioId)
        {
            return await _contexto.Exercicios
                            .Where(e => e.Id == exercicioId)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SalvarAsync(Exercicio exercicio)
        {
            await _contexto.Exercicios.AddAsync(exercicio);
            await _contexto.SaveChangesAsync();

            return exercicio.Id;
        }
    }
}