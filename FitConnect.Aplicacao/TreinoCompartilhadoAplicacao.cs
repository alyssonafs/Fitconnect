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

        public async Task AtualizarAsync(TreinoCompartilhado treinoCompartilhado)
        {
            var treinoCompartilhadoDominio = await _treinoCompartilhadoRepositorio.ObterPorIdAsync(treinoCompartilhado.Id);

            if (treinoCompartilhadoDominio == null)
            {
                throw new Exception("Treino Compartilhado não encontrado!");
            }

            var treinoBusca = _treinoRepositorio.ObterPorIdAsync(treinoCompartilhado.TreinoId);
            var alunoBusca = _usuarioRepositorio.ObterPorIdAsync(treinoCompartilhado.AlunoId);

            ValidarCamposTreinoCompartilhado(treinoBusca, alunoBusca);

            treinoCompartilhadoDominio.TreinoId = treinoCompartilhado.TreinoId;
            treinoCompartilhadoDominio.AlunoId = treinoCompartilhado.AlunoId;

            await _treinoCompartilhadoRepositorio.AtualizarAsync(treinoCompartilhadoDominio);

        }

        public async Task DeletarAsync(TreinoCompartilhado treinoCompartilhado)
        {
            var treinoCompartilhadoDominio = await _treinoCompartilhadoRepositorio.ObterPorIdAsync(treinoCompartilhado.Id);

            if (treinoCompartilhadoDominio == null)
            {
                throw new Exception("Treino Compartilhado não encontrado!");
            }

            await _treinoCompartilhadoRepositorio.DeletarAsync(treinoCompartilhadoDominio);
        }

        public async Task<IEnumerable<TreinoCompartilhado>> ListarAsync()
        {
            return await _treinoCompartilhadoRepositorio.ListarAsync();
        }

        public async Task<TreinoCompartilhado> ObterPorIdAsync(int treinoCompartilhadoId)
        {
            var treinoCompartilhadoDominio = await _treinoCompartilhadoRepositorio.ObterPorIdAsync(treinoCompartilhadoId);

            if (treinoCompartilhadoDominio == null)
            {
                throw new Exception("Treino Compartilhado não encontrado!");
            }

            return treinoCompartilhadoDominio;
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