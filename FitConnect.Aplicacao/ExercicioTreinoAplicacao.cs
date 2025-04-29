using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Aplicacao
{
    public class ExercicioTreinoAplicacao : IExercicioTreinoAplicacao
    {
        readonly IExercicioTreinoRepositorio _exercicioTreinoRepositorio;
        readonly ITreinoRepositorio _treinoRepositorio;
        readonly IExercicioRepositorio _exercicioRepositorio;

        public ExercicioTreinoAplicacao(IExercicioTreinoRepositorio exercicioTreinoRepositorio)
        {
            _exercicioTreinoRepositorio = exercicioTreinoRepositorio;
        }

        public Task AtualizarAsync(ExercicioTreino exercicioTreino)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CriarAsync(ExercicioTreino exercicioTreino)
        {
            var treinoBusca = _treinoRepositorio.ObterPorIdAsync(exercicioTreino.TreinoId);
            var exercicioBusca = _exercicioRepositorio.ObterPorIdAsync(exercicioTreino.ExercicioId);

            ValidarCamposExercicioTreino(exercicioTreino, treinoBusca, exercicioBusca);

            return await _exercicioTreinoRepositorio.SalvarAsync(exercicioTreino);
        }

        public Task DeletarAsync(ExercicioTreino exercicioTreino)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExercicioTreino>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ExercicioTreino> ObterPorIdAsync(int exercicioTreinoId)
        {
            throw new NotImplementedException();
        }

        #region Util

        private static void ValidarCamposExercicioTreino(ExercicioTreino exercicioTreino, Task<Treino> treino, Task<Exercicio> exercicio)
        {
            if (String.IsNullOrEmpty(exercicioTreino.Serie))
            {
                throw new Exception("O campo série não pode ser vazio!");
            }
            if (treino == null)
            {
                throw new Exception("O campo treino não pode ser vazio!");
            }
            if (exercicio == null)
            {
                throw new Exception("O campo exercício não pode ser vazio!");
            }
        }

        #endregion
    }
}