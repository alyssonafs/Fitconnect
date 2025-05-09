using FitConnect.Api.Models.Requisicao.TreinoCompartilhado;
using FitConnect.Api.Models.Resposta.TreinoCompartilhado;
using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace FitConnect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreinoCompartilhadoController : ControllerBase
    {
        private readonly ITreinoCompartilhadoAplicacao _treinoCompartilhadoAplicacao;

        public TreinoCompartilhadoController(ITreinoCompartilhadoAplicacao treinoCompartilhadoAplicacao)
        {
            _treinoCompartilhadoAplicacao = treinoCompartilhadoAplicacao;
        }

        [HttpGet]
        [Route("Obter/{treinoCompartilhadoId}")]
        public async Task<ActionResult> Obter([FromRoute] int treinoCompartilhadoId)
        {
            try
            {
                var treinoCompartilhadoDominio = await _treinoCompartilhadoAplicacao.ObterPorIdAsync(treinoCompartilhadoId);

                var treinoCompartilhadoResposta = new TreinoCompartilhadoResposta()
                {
                    Id = treinoCompartilhadoDominio.Id,
                    TreinoId = treinoCompartilhadoDominio.TreinoId,
                    AlunoId = treinoCompartilhadoDominio.AlunoId,
                    DataCompartilhamento = treinoCompartilhadoDominio.DataCompartilhamento
                };

                return Ok(treinoCompartilhadoResposta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter treino compartilhado: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("NovoTreinoCompartilhado")]
        public async Task<ActionResult> Criar([FromBody] TreinoCompartilhadoCriar treinoCompartilhadoCriar)
        {
            try
            {
                var treinoCompartilhadoDominio = new TreinoCompartilhado()
                {
                    TreinoId = treinoCompartilhadoCriar.TreinoId,
                    AlunoId = treinoCompartilhadoCriar.AlunoId
                };

                var treinoCompartilhadoId = await _treinoCompartilhadoAplicacao.CriarAsync(treinoCompartilhadoDominio);

                return Ok(treinoCompartilhadoId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar treino compartilhado: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] TreinoCompartilhadoAtualizar treinoCompartilhadoAtualizar)
        {
            try
            {
                var treinoCompartilhadoDominio = new TreinoCompartilhado()
                {
                    Id = treinoCompartilhadoAtualizar.Id,
                    TreinoId = treinoCompartilhadoAtualizar.TreinoId,
                    AlunoId = treinoCompartilhadoAtualizar.AlunoId
                };

                await _treinoCompartilhadoAplicacao.AtualizarAsync(treinoCompartilhadoDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar treino compartilhado: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Deletar/{treinoCompartilhadoId}")]
        public async Task<ActionResult> Deletar([FromRoute] int treinoCompartilhadoId)
        {
            try
            {
                await _treinoCompartilhadoAplicacao.DeletarAsync(treinoCompartilhadoId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar treino compartilhado: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var treinosCompartilhadosDominio = await _treinoCompartilhadoAplicacao.ListarAsync();

                var treinosCompartilhados = treinosCompartilhadosDominio.Select(treinoCompartilhado => new TreinoCompartilhadoResposta()
                {  
                    Id = treinoCompartilhado.Id,
                    TreinoId = treinoCompartilhado.TreinoId,
                    AlunoId = treinoCompartilhado.AlunoId,
                    DataCompartilhamento = treinoCompartilhado.DataCompartilhamento
                }).ToList();

                return Ok(treinosCompartilhados);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar treinos compartilhados: {ex.Message}");
            }
        }
    }
}