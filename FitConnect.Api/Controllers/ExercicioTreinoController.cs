using FitConnect.Api.Models.Requisicao.ExercicioTreino;
using FitConnect.Api.Models.Resposta.ExercicioTreino;
using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace FitConnect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercicioTreinoController : ControllerBase
    {
        private readonly IExercicioTreinoAplicacao _exercicioTreinoAplicacao;

        public ExercicioTreinoController(IExercicioTreinoAplicacao exercicioTreinoAplicacao)
        {
            _exercicioTreinoAplicacao = exercicioTreinoAplicacao;
        }

        [HttpGet]
        [Route("Obter/{exercicioTreinoId}")]
        public async Task<IActionResult> Obter([FromRoute] int exercicioTreinoId)
        {
            try
            {
                var exercicioTreinoDominio = await _exercicioTreinoAplicacao.ObterPorIdAsync(exercicioTreinoId);

                var exercicioTreinoResposta = new ExercicioTreinoResposta()
                {
                    Id = exercicioTreinoDominio.Id,
                    Serie = exercicioTreinoDominio.Serie,
                    TreinoId = exercicioTreinoDominio.TreinoId,
                    ExercicioId = exercicioTreinoDominio.ExercicioId
                };

                return Ok(exercicioTreinoResposta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter exercícioTreino: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("NovoExercicioTreino")]
        public async Task<ActionResult> Criar([FromBody] ExercicioTreinoCriar exercicioTreinoCriar)
        {
            try
            {
                var exercicioTreinoDominio = new ExercicioTreino()
                {
                    Serie = exercicioTreinoCriar.Serie,
                    TreinoId = exercicioTreinoCriar.TreinoId,
                    ExercicioId = exercicioTreinoCriar.ExercicioId
                };

                var exercicioTreinoId = await _exercicioTreinoAplicacao.CriarAsync(exercicioTreinoDominio);

                return Ok(exercicioTreinoId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar exercício treino: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] ExercicioTreinoAtualizar exercicioTreinoAtualizar)
        {
            try
            {
                var exercicioTreinoDominio = new ExercicioTreino()
                {
                    Id = exercicioTreinoAtualizar.Id,
                    Serie = exercicioTreinoAtualizar.Serie,
                    TreinoId = exercicioTreinoAtualizar.TreinoId,
                    ExercicioId = exercicioTreinoAtualizar.ExercicioId
                };

                await _exercicioTreinoAplicacao.AtualizarAsync(exercicioTreinoDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar exercício treino: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Deletar/{exercicioTreinoId}")]
        public async Task<ActionResult> Deletar([FromRoute] int exercicioTreinoId)
        {
            try
            {
                await _exercicioTreinoAplicacao.DeletarAsync(exercicioTreinoId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar exercício treino: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var exerciciosTreinoDominio = await _exercicioTreinoAplicacao.ListarAsync();

                var exerciciosTreino = exerciciosTreinoDominio.Select(exercicioTreino => new ExercicioTreinoResposta()
                {
                    Id = exercicioTreino.Id,
                    Serie = exercicioTreino.Serie,
                    TreinoId = exercicioTreino.TreinoId,
                    ExercicioId = exercicioTreino.ExercicioId
                }).ToList();

                return Ok(exerciciosTreino);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar exercícios treinos: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("RemoverExercicio")]
        public async Task<IActionResult> RemoverExercicio([FromQuery] int treinoId, [FromQuery] int exercicioId)
        {
            try
            {
                await _exercicioTreinoAplicacao.DeletarPorTreinoEExercicioAsync(treinoId, exercicioId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao remover exercício do treino: {ex.Message}");
            }
        }

        [HttpGet("ListarPorTreino/{treinoId}")]
        public async Task<IActionResult> ListarPorTreino(int treinoId)
        {
            var lista = await _exercicioTreinoAplicacao.ListarPorTreinoAsync(treinoId);
            return Ok(lista);
        }
    }
}