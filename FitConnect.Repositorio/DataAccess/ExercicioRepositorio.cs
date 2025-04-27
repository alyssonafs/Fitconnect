using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Contexto;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Repositorio.DataAccess
{
    public class ExercicioRepositorio : BaseRepositorio, IExercicioRepositorio
    {
        public ExercicioRepositorio(FitConnectContexto contexto) : base(contexto)
        {
            
        }
        public Task AtualizarAsync(Exercicio exercicio)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<Exercicio>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Exercicio> ObterPorId(int exercicioId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SalvarAsync(Exercicio exercicio)
        {
            throw new NotImplementedException();
        }
    }
}