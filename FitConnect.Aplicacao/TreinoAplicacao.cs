using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Aplicacao
{
    public class TreinoAplicacao : ITreinoAplicacao
    {
        readonly ITreinoRepositorio _treinoRepositorio;

        public TreinoAplicacao(ITreinoRepositorio treinoRepositorio)
        {
            _treinoRepositorio = treinoRepositorio;
        }

        readonly IUsuarioRepositorio _usuarioRepositorio;
        public Task AtualizarAsync(Treino treino)
        {
            throw new NotImplementedException();
        }

        public Task DeletarAsync(Treino treino)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Treino>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Treino> ObterPorIdAsync(int treinoId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CriarAsync(Treino treino)
        {
            var personalBusca = _usuarioRepositorio.ObterPorIdAsync(treino.PersonalId);

            ValidarCamposTreino(treino, personalBusca);

            return await _treinoRepositorio.SalvarAsync(treino);
        }

        #region Util

        private static void ValidarCamposTreino(Treino treino, Task<Usuario> personal)
        {
            if (String.IsNullOrEmpty(treino.Nome))
            {
                throw new Exception("O campo nome não pode ser vazio!");
            }
            if (personal == null)
            {
                throw new Exception("O campo personal não pode ser vazio!");
            }
        }

        #endregion
    }
}