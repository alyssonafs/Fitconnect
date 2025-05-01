using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Aplicacao
{
    public class ExercicioAplicacao : IExercicioAplicacao
    {
        readonly IExercicioRepositorio _exercicioRepositorio;

        public ExercicioAplicacao(IExercicioRepositorio exercicioRepositorio)
        {
            _exercicioRepositorio = exercicioRepositorio;
        }

        public async Task AtualizarAsync(Exercicio exercicio)
        {
            var exercicioDominio = await _exercicioRepositorio.ObterPorIdAsync(exercicio.Id);

            if (exercicioDominio == null)
            {
                throw new Exception("Exercício não encontrado!");
            }

            exercicioDominio.Nome = exercicio.Nome;
            exercicioDominio.GrupoMuscular = exercicio.GrupoMuscular;

            if (!String.IsNullOrEmpty(exercicio.Descricao))
            {
                exercicioDominio.Descricao = exercicio.Descricao;
            }
            
            if (!String.IsNullOrEmpty(exercicio.VideoURL))    
            {
                exercicioDominio.VideoURL = exercicio.VideoURL;
            }            
        }

        public async Task<int> CriarAsync(Exercicio exercicio)
        {
            ValidarCamposExercicio(exercicio);

            return await _exercicioRepositorio.SalvarAsync(exercicio);
        }

        public async Task DeletarAsync(Exercicio exercicio)
        {
            var exercicioDominio = await _exercicioRepositorio.ObterPorIdAsync(exercicio.Id);

            if (exercicioDominio == null)
            {
                throw new Exception("Exercício não encontrado!");
            }

            await _exercicioRepositorio.DeletarAsync(exercicioDominio);
        }

        public async Task<IEnumerable<Exercicio>> ListarAsync()
        {
            return await _exercicioRepositorio.ListarAsync();
        }

        public async Task<Exercicio> ObterPorIdAsync(int exercicioId)
        {
            var exercicioDominio = await _exercicioRepositorio.ObterPorIdAsync(exercicioId);

            if (exercicioDominio == null)
            {
                throw new Exception("Exercício não encontrado!");
            }

            return exercicioDominio;
        }

        #region Util

        private static void ValidarCamposExercicio(Exercicio exercicio)
        {
            if (String.IsNullOrEmpty(exercicio.Nome))
            {
                throw new Exception("O campo nome não pode ser vazio!");
            }
            if (String.IsNullOrEmpty(exercicio.GrupoMuscular))
            {
                throw new Exception("O campo grupo muscular não pode ser vazio!");
            }
        }

        #endregion
    }
}