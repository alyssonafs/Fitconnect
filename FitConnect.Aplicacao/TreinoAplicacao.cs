using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Dominio.Enumeradores;
using FitConnect.Repositorio.DataAccess.Interfaces;

namespace FitConnect.Aplicacao
{
    public class TreinoAplicacao : ITreinoAplicacao
    {
        readonly ITreinoRepositorio _treinoRepositorio;
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public TreinoAplicacao(ITreinoRepositorio treinoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _treinoRepositorio = treinoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }
        public async Task AtualizarAsync(Treino treino)
        {
            var treinoDominio = await _treinoRepositorio.ObterPorIdAsync(treino.Id);

            if (treinoDominio == null)
            {
                throw new Exception("Treino não encontrado!");
            }

            var personalBusca = await _usuarioRepositorio.ObterPorIdAsync(treino.PersonalId);

            if (!String.IsNullOrEmpty(treino.Nome))
            {
                treinoDominio.Nome = treino.Nome;
            }
            if(personalBusca != null)
            {
                if (personalBusca.TipoUsuario == 0)
                {
                    treinoDominio.PersonalId = treino.PersonalId;
                }
            }            

            await _treinoRepositorio.AtualizarAsync(treinoDominio);
        }

        public async Task DeletarAsync(int treinoId)
        {
            var treinoDominio = await _treinoRepositorio.ObterPorIdAsync(treinoId);

            if (treinoDominio == null)
            {
                throw new Exception("Treino não encontrado!");
            }

            await _treinoRepositorio.DeletarAsync(treinoDominio);
        }

        public async Task<IEnumerable<Treino>> ListarAsync()
        {
            return await _treinoRepositorio.ListarAsync();
        }

        public async Task<Treino> ObterPorIdAsync(int treinoId)
        {
            var treinoDominio = await _treinoRepositorio.ObterPorIdAsync(treinoId);

            if (treinoDominio == null)
            {
                throw new Exception("Treino não encontrado!");
            }

            return treinoDominio;
        }

        public async Task<int> CriarAsync(Treino treino)
        {
           var personalBusca = await _usuarioRepositorio.ObterPorIdAsync(treino.PersonalId);

           ValidarCamposTreino(treino, personalBusca);

            return await _treinoRepositorio.SalvarAsync(treino);
        }

        #region Util

        private static void ValidarCamposTreino(Treino treino, Usuario personal)
        {
            if (String.IsNullOrEmpty(treino.Nome))
            {
                throw new Exception("O campo nome não pode ser vazio!");
            }
            if (personal == null)
            {
                throw new Exception("O campo personal não pode ser vazio!");
            }
            if (personal.TipoUsuario != 0)
            {
                throw new Exception("Somente usuário do tipo personal pode criar treinos!");
            }
        }

        #endregion
    }
}