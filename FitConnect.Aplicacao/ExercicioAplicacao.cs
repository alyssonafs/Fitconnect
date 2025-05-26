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

            if (!String.IsNullOrEmpty(exercicio.Nome))
            {
                exercicioDominio.Nome = exercicio.Nome;
            }

            if (!String.IsNullOrEmpty(exercicio.GrupoMuscular))
            {
                exercicioDominio.GrupoMuscular = exercicio.GrupoMuscular;
            }            

            if (!String.IsNullOrEmpty(exercicio.Descricao))
            {
                exercicioDominio.Descricao = exercicio.Descricao;
            }
            
            if (!String.IsNullOrEmpty(exercicio.VideoURL))    
            {
                exercicioDominio.VideoURL = exercicio.VideoURL;
            }            

            await _exercicioRepositorio.AtualizarAsync(exercicioDominio);
        }

        public async Task<int> CriarAsync(Exercicio exercicio)
        {
            ValidarCamposExercicio(exercicio);

            return await _exercicioRepositorio.SalvarAsync(exercicio);
        }

        public async Task DeletarAsync(int  exercicioId)
        {
            var exercicioDominio = await _exercicioRepositorio.ObterPorIdAsync(exercicioId);

            if (exercicioDominio == null)
            {
                throw new Exception("Exercício não encontrado!");
            }

            if (exercicioDominio.Ativo == false)
            {
                throw new Exception("Exercício já deletado!");
            }

            exercicioDominio.Deletar();

            await _exercicioRepositorio.AtualizarAsync(exercicioDominio);
        }

        public async Task RestaurarAsync(int  exercicioId)
        {
            var exercicioDominio = await _exercicioRepositorio.ObterPorIdAsync(exercicioId);

            if (exercicioDominio == null)
            {
                throw new Exception("Exercício não encontrado!");
            }

            if (exercicioDominio.Ativo == true)
            {
                throw new Exception("Exercício já está ativo!");
            }

            exercicioDominio.Restaurar();

            await _exercicioRepositorio.AtualizarAsync(exercicioDominio);
        }

        public async Task<IEnumerable<Exercicio>> ListarAsync(bool ativo)
        {
            return await _exercicioRepositorio.ListarAsync(ativo);
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