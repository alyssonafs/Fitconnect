using FitConnect.Api.Models.Requisicao.Exercicio;
using FitConnect.Api.Models.Resposta.Exercicio;
using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Dominio.Enumeradores;
using Microsoft.AspNetCore.Mvc;

namespace FitConnect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioAplicacao _exercicioAplicacao;

        public ExercicioController(IExercicioAplicacao exercicioAplicacao)
        {
            _exercicioAplicacao = exercicioAplicacao;
        }

        [HttpGet]
        [Route("Obter/{exercicioId}")]
        public async Task<IActionResult> Obter([FromRoute] int exercicioId)
        {
            try
            {
                var exercicioDominio = await _exercicioAplicacao.ObterPorIdAsync(exercicioId);

                var exercicioResposta = new ExercicioResposta()
                {
                    Id = exercicioDominio.Id,
                    Nome = exercicioDominio.Nome,
                    GrupoMuscular = exercicioDominio.GrupoMuscular,
                    Descricao = exercicioDominio.Descricao,
                    VideoURL = exercicioDominio.VideoURL
                };

                return Ok(exercicioResposta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter exercício: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("NovoExercicio")]
        public async Task<ActionResult> Criar([FromBody] ExercicioCriar exercicioCriar)
        {
            try
            {
                var exercicioDominio = new Exercicio()
                {
                    Nome = exercicioCriar.Nome,
                    GrupoMuscular = exercicioCriar.GrupoMuscular,
                    Descricao = exercicioCriar.Descricao,
                    VideoURL = exercicioCriar.VideoURL
                };

                var exercicioId = await _exercicioAplicacao.CriarAsync(exercicioDominio);

                return Ok(exercicioId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar exercício: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] ExercicioAtualizar exercicioAtualizar)
        {
            try
            {
                var exercicioDominio = new Exercicio()
                {
                    Id = exercicioAtualizar.Id,
                    Nome = exercicioAtualizar.Nome,
                    GrupoMuscular = exercicioAtualizar.GrupoMuscular,
                    Descricao = exercicioAtualizar.Descricao,
                    VideoURL = exercicioAtualizar.VideoURL
                };

                await _exercicioAplicacao.AtualizarAsync(exercicioDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar exercício: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Deletar/{exercicioId}")]
        public async Task<ActionResult> Deletar([FromRoute] int exercicioId)
        {
            try
            {
                await _exercicioAplicacao.DeletarAsync(exercicioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar exercício: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Restaurar/{exercicioId}")]
        public async Task<ActionResult> Restaurar([FromRoute] int exercicioId)
        {
            try
            {
                await _exercicioAplicacao.RestaurarAsync(exercicioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao restaurar exercício: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> Listar([FromQuery] bool ativos)
        {
            try
            {
                var exerciciosDominio = await _exercicioAplicacao.ListarAsync(ativos);

                var exercicios = exerciciosDominio.Select(exercicio => new ExercicioResposta()
                {
                    Id = exercicio.Id,
                    Nome = exercicio.Nome,
                    GrupoMuscular = exercicio.GrupoMuscular,
                    Descricao = exercicio.Descricao,
                    VideoURL = exercicio.VideoURL
                }).ToList();

                return Ok(exercicios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar exercícios: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ListarTiposGruposMusculares")]
        public ActionResult ListarTiposGruposMusculares()
        {
            try
            {
                var tipoGruposMusculares = Enum.GetValues(typeof(TiposGruposMusculares))
                                        .Cast<TiposGruposMusculares>()
                                        .Select(t => new 
                                        {
                                            id = (int)t, nome = t.ToString()
                                        })
                                        .ToList();
                
                return Ok(tipoGruposMusculares);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar os tipos de grupos musculares: {ex.Message}");
            }
        }
    }
}