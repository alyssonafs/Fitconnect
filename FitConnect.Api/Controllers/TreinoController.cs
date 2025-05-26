using FitConnect.Api.Models.Requisicao.Treino;
using FitConnect.Api.Models.Resposta.Treino;
using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace FitConnect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreinoController : ControllerBase
    {
        private readonly ITreinoAplicacao _treinoAplicacao;

        public TreinoController(ITreinoAplicacao treinoAplicacao)
        {
            _treinoAplicacao = treinoAplicacao;
        }

        [HttpGet]
        [Route("Obter/{treinoId}")]
        public async Task<ActionResult> Obter([FromRoute] int treinoId)
        {
            try
            {
                var treinoDominio = await _treinoAplicacao.ObterPorIdAsync(treinoId);

                var treinoResposta = new TreinoResposta()
                {
                    Id = treinoDominio.Id,
                    Nome = treinoDominio.Nome,
                    PersonalId = treinoDominio.PersonalId
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
                    Nome = treinoAtualizar.Nome,
                    PersonalId = treinoAtualizar.PersonalId
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
    }
}