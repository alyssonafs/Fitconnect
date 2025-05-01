using System.Reflection.Metadata.Ecma335;
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

        public async Task AtualizarAsync(ExercicioTreino exercicioTreino)
        {
            var exercicioTreinoDominio = await _exercicioTreinoRepositorio.ObterPorIdAsync(exercicioTreino.Id);

            if (exercicioTreinoDominio == null)
            {
                throw new Exception("ExercicioTreino não encontrado!");
            }

            var treinoBusca = _treinoRepositorio.ObterPorIdAsync(exercicioTreino.TreinoId);
            var exercicioBusca = _exercicioRepositorio.ObterPorIdAsync(exercicioTreino.ExercicioId);

            ValidarCamposExercicioTreino(exercicioTreino, treinoBusca, exercicioBusca);

            exercicioTreinoDominio.Serie = exercicioTreino.Serie;
            exercicioTreinoDominio.TreinoId = exercicioTreino.TreinoId;
            exercicioTreinoDominio.ExercicioId = exercicioTreino.ExercicioId;

            await _exercicioTreinoRepositorio.AtualizarAsync(exercicioTreinoDominio);
        }

        public async Task<int> CriarAsync(ExercicioTreino exercicioTreino)
        {
            var treinoBusca = _treinoRepositorio.ObterPorIdAsync(exercicioTreino.TreinoId);
            var exercicioBusca = _exercicioRepositorio.ObterPorIdAsync(exercicioTreino.ExercicioId);

            ValidarCamposExercicioTreino(exercicioTreino, treinoBusca, exercicioBusca);

            return await _exercicioTreinoRepositorio.SalvarAsync(exercicioTreino);
        }

        public async Task DeletarAsync(ExercicioTreino exercicioTreino)
        {
            var exercicioTreinoDominio = await _exercicioTreinoRepositorio.ObterPorIdAsync(exercicioTreino.Id);

            if (exercicioTreinoDominio == null)
            {
                throw new Exception("Exercício Treino não encontrado!");
            }

            await _exercicioTreinoRepositorio.DeletarAsync(exercicioTreinoDominio);
        }

        public async Task<IEnumerable<ExercicioTreino>> ListarAsync()
        {
            return await _exercicioTreinoRepositorio.ListarAsync();
        }

        public async Task<ExercicioTreino> ObterPorIdAsync(int exercicioTreinoId)
        {
            var exercicioTreinoDominio = await _exercicioTreinoRepositorio.ObterPorIdAsync(exercicioTreinoId);

            if (exercicioTreinoDominio == null)
            {
                throw new Exception("Exercício Treino não encontrado!");
            }

            return exercicioTreinoDominio;
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