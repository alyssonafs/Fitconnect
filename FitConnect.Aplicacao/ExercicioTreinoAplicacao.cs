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

        public ExercicioTreinoAplicacao(IExercicioTreinoRepositorio exercicioTreinoRepositorio, IExercicioRepositorio exercicioRepositorio, ITreinoRepositorio treinoRepositorio)
        {
            _exercicioTreinoRepositorio = exercicioTreinoRepositorio;
            _exercicioRepositorio = exercicioRepositorio;
            _treinoRepositorio = treinoRepositorio;
        }

        public async Task AtualizarAsync(ExercicioTreino exercicioTreino)
        {
            var exercicioTreinoDominio = await _exercicioTreinoRepositorio.ObterPorIdAsync(exercicioTreino.Id);

            if (exercicioTreinoDominio == null)
            {
                throw new Exception("ExercicioTreino não encontrado!");
            }

            var treinoBusca = await _treinoRepositorio.ObterPorIdAsync(exercicioTreino.TreinoId);
            var exercicioBusca = await _exercicioRepositorio.ObterPorIdAsync(exercicioTreino.ExercicioId);

            if (!String.IsNullOrEmpty(exercicioTreino.Serie))
            {
                exercicioTreinoDominio.Serie = exercicioTreino.Serie;
            }

            if (treinoBusca != null)
            {
                exercicioTreinoDominio.TreinoId = exercicioTreino.TreinoId;
            }

            if (exercicioBusca != null)
            {
                exercicioTreinoDominio.ExercicioId = exercicioTreino.ExercicioId;
            }

            await _exercicioTreinoRepositorio.AtualizarAsync(exercicioTreinoDominio);
        }

        public async Task<int> CriarAsync(ExercicioTreino exercicioTreino)
        {
            var treinoBusca = await _treinoRepositorio.ObterPorIdAsync(exercicioTreino.TreinoId);
            var exercicioBusca = await _exercicioRepositorio.ObterPorIdAsync(exercicioTreino.ExercicioId);

            ValidarCamposExercicioTreino(exercicioTreino, treinoBusca, exercicioBusca);

            return await _exercicioTreinoRepositorio.SalvarAsync(exercicioTreino);
        }

        public async Task DeletarAsync(int exercicioTreinoId)
        {
            var exercicioTreinoDominio = await _exercicioTreinoRepositorio.ObterPorIdAsync(exercicioTreinoId);

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

        public async Task DeletarPorTreinoEExercicioAsync(int treinoId, int exercicioId)
        {
            var exercicioTreino = await _exercicioTreinoRepositorio.ObterPorTreinoEExercicioAsync(treinoId, exercicioId);

            if (exercicioTreino == null)
            {
                throw new Exception("Exercício não encontrado no treino.");
            }

            await _exercicioTreinoRepositorio.DeletarAsync(exercicioTreino);
        }

        public async Task<List<ExercicioTreinoDto>> ListarPorTreinoAsync(int treinoId)
        {
            var lista = await _exercicioTreinoRepositorio.ListarPorTreinoAsync(treinoId);

            return lista.Select(e => new ExercicioTreinoDto
            {
                Id = e.Id,
                ExercicioId = e.ExercicioId,
                TreinoId = e.TreinoId,
                Nome = e.Exercicio.Nome,
                GrupoMuscular = e.Exercicio.GrupoMuscular,
                Descricao = e.Exercicio.Descricao,
                VideoURL = e.Exercicio.VideoURL,
                Series = e.Serie
            }).ToList();
        }


        #region Util

        private static void ValidarCamposExercicioTreino(ExercicioTreino exercicioTreino, Treino treino, Exercicio exercicio)
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