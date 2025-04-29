using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Aplicacao
{
    public class TreinoCompartilhadoAplicacao : ITreinoCompartilhadoAplicacao
    {
        readonly ITreinoCompartilhadoRepositorio _treinoCompartilhadoRepositorio;
        readonly ITreinoRepositorio _treinoRepositorio;
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public TreinoCompartilhadoAplicacao(ITreinoCompartilhadoRepositorio treinoCompartilhadoRepositorio)
        {
            _treinoCompartilhadoRepositorio = treinoCompartilhadoRepositorio;
        }

        public Task AtualizarAsync(TreinoCompartilhado treinoCompartilhado)
        {
            throw new NotImplementedException();
        }

        public Task DeletarAsync(TreinoCompartilhado treinoCompartilhado)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TreinoCompartilhado>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TreinoCompartilhado> ObterPorIdAsync(int treinoCompartilhadoId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CriarAsync(TreinoCompartilhado treinoCompartilhado)
        {
            var treinoBusca = _treinoRepositorio.ObterPorIdAsync(treinoCompartilhado.TreinoId);
            var alunoBusca = _usuarioRepositorio.ObterPorIdAsync(treinoCompartilhado.AlunoId);

            ValidarCamposTreinoCompartilhado(treinoBusca, alunoBusca);

            return await _treinoCompartilhadoRepositorio.SalvarAsync(treinoCompartilhado);
        }
        #region Util

        private static void ValidarCamposTreinoCompartilhado(Task<Treino> treino, Task<Usuario> aluno)
        {
            if (treino == null)
            {
                throw new Exception("O campo treino não pode ser vazio!");
            }
            if (aluno == null)
            {
                throw new Exception("O campo aluno não pode ser vazio!");
            }
        }

        #endregion
    }
}