using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.Contexto;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Repositorio.DataAccess
{
    public class ExercicioTreinoRepositorio : BaseRepositorio, IExercicioTreinoRepositorio
    {
        public ExercicioTreinoRepositorio(FitConnectContexto contexto) : base(contexto)
        {
            
        }
        public Task AtualizarAsync(ExercicioTreino exercicioTreino)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<ExercicioTreino>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ExercicioTreino> ObterPorId(int exercicioTreinoId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SalvarAsync(ExercicioTreino exercicioTreino)
        {
            throw new NotImplementedException();
        }
    }
}