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

        public Task AtualizarAsync(Exercicio exercicio)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CriarAsync(Exercicio exercicio)
        {
            ValidarCamposExercicio(exercicio);

            return await _exercicioRepositorio.SalvarAsync(exercicio);
        }

        public Task DeletarAsync(Exercicio exercicio)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exercicio>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Exercicio> ObterPorIdAsync(int exercicioId)
        {
            throw new NotImplementedException();
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