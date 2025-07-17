using FitConnect.Api.Models.Requisicao.Treino;
using FitConnect.Api.Models.Resposta.Treino;
using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitConnect.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TreinoController : ControllerBase
    {
        private readonly ITreinoAplicacao _treinoAplicacao;
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public TreinoController(ITreinoAplicacao treinoAplicacao, IUsuarioAplicacao usuarioAplicacao)
        {
            _treinoAplicacao = treinoAplicacao;
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpGet]
        [Route("Obter/{treinoId}")]
        public async Task<ActionResult> Obter([FromRoute] int treinoId)
        {
            try
            {
                var treinoDominio = await _treinoAplicacao.ObterPorIdAsync(treinoId);

                var personal = await _usuarioAplicacao.ObterPorIdAsync(treinoDominio.PersonalId);
                var quantidadeExercicios = treinoDominio.ExerciciosTreino?.Count() ?? 0;

                var treinoResposta = new TreinoRespostaLista()
                {
                    Id = treinoDominio.Id,
                    Nome = treinoDominio.Nome,
                    PersonalId = treinoDominio.PersonalId,
                    PersonalNome = personal?.Nome ?? "Desconhecido",
                    QuantidadeExercicios = quantidadeExercicios,
                    TempoEstimado = quantidadeExercicios * 5
                };

                return Ok(treinoResposta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter treino: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("NovoTreino")]
        public async Task<ActionResult> Criar([FromBody] TreinoCriar treinoCriar)
        {
            try
            {
                var treinoDominio = new Treino()
                {
                    Nome = treinoCriar.Nome,
                    PersonalId = treinoCriar.PersonalId
                };

                var treinoId = await _treinoAplicacao.CriarAsync(treinoDominio);

                return Ok(treinoId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar novo treino: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] TreinoAtualizar treinoAtualizar)
        {
            try
            {
                var treinoDominio = new Treino()
                {
                    Id = treinoAtualizar.Id,
                    Nome = treinoAtualizar.Nome
                };

                await _treinoAplicacao.AtualizarAsync(treinoDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar treino: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Deletar/{treinoId}")]
        public async Task<ActionResult> Deletar([FromRoute] int treinoId)
        {
            try
            {
                await _treinoAplicacao.DeletarAsync(treinoId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar treino: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Restaurar/{treinoId}")]
        public async Task<ActionResult> Restaurar([FromRoute] int treinoId)
        {
            try
            {
                await _treinoAplicacao.RestaurarAsync(treinoId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao restaurar treino: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> Listar([FromQuery] bool ativos)
        {
            try
            {
                var treinosDominio = await _treinoAplicacao.ListarAsync(ativos);

                var treinos = treinosDominio.Select(treino => new TreinoResposta()
                {
                    Id = treino.Id,
                    Nome = treino.Nome,
                    PersonalId = treino.PersonalId
                }).ToList();

                return Ok(treinos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar treinos: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar/Personal")]
        public async Task<ActionResult> ListarPersonal([FromQuery] int personalId)
        {
            try
            {
                var treinosDominio = await _treinoAplicacao.ListarTreinosPersonal(personalId);

                var personal = await _usuarioAplicacao.ObterPorIdAsync(personalId);

                var treinos = treinosDominio.Select(treino => new TreinoRespostaLista()
                {
                    Id = treino.Id,
                    Nome = treino.Nome,
                    PersonalId = treino.PersonalId,
                    PersonalNome = personal?.Nome ?? "Desconhecido",
                    QuantidadeExercicios = treino.ExerciciosTreino?.Count() ?? 0,
                    TempoEstimado = (treino.ExerciciosTreino?.Count() ?? 0) * 5
                }).ToList();

                return Ok(treinos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar treinos do personal: {ex.Message}");
            }

        }

        [HttpGet("ListarPorGrupoMuscular")]
        public async Task<IActionResult> ListarPorGrupoMuscular([FromQuery] int grupoMuscular)
        {
            var treinos = await _treinoAplicacao.ListarPorGrupoMuscularAsync(grupoMuscular);
            return Ok(treinos);
        }
    }
}