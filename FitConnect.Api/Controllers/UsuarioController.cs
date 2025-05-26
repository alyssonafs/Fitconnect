using FitConnect.Api.Models.Requisicao.Usuario;
using FitConnect.Api.Models.Resposta.Usuario;
using FitConnect.Aplicacao.Interfaces;
using FitConnect.Dominio.Entidades;
using FitConnect.Dominio.Enumeradores;
using Microsoft.AspNetCore.Mvc;

namespace FitConnect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpGet]
        [Route("Obter/{usuarioId}")]
        public async Task<ActionResult> Obter([FromRoute] int usuarioId)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.ObterPorIdAsync(usuarioId);

                var usuarioResposta = new UsuarioResposta()
                {
                    Id = usuarioDominio.Id,
                    Nome = usuarioDominio.Nome,
                    Email = usuarioDominio.Email,
                    TipoUsuario = usuarioDominio.TipoUsuario,
                    Genero = usuarioDominio.Genero,
                    DataNascimento = usuarioDominio.DataNascimento,
                    Peso = usuarioDominio.Peso,
                    Altura = usuarioDominio.Altura
                };

                return Ok(usuarioResposta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter usuário: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("NovoUsuario")]
        public async Task<ActionResult> Criar([FromBody] UsuarioCriar usuarioCriar)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Nome = usuarioCriar.Nome,
                    Email = usuarioCriar.Email,
                    Senha = usuarioCriar.Senha,
                    TipoUsuario = usuarioCriar.TipoUsuario,
                    Genero = usuarioCriar.Genero,
                    DataNascimento = usuarioCriar.DataNascimento,
                    Peso = usuarioCriar.Peso,
                    Altura = usuarioCriar.Altura
                };

                var usuarioId = await _usuarioAplicacao.CriarAsync(usuarioDominio);

                return Ok(usuarioId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar novo usuário: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] UsuarioAtualizar usuarioAtualizar)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Id = usuarioAtualizar.Id,
                    Nome = usuarioAtualizar.Nome,
                    Email = usuarioAtualizar.Email,
                    TipoUsuario = usuarioAtualizar.TipoUsuario,
                    Genero = usuarioAtualizar.Genero,
                    DataNascimento = usuarioAtualizar.DataNascimento,
                    Peso = usuarioAtualizar.Peso,
                    Altura = usuarioAtualizar.Altura
                };

                await _usuarioAplicacao.AtualizarAsync(usuarioDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar usuário: {ex.Message}");
            }
        } 

        [HttpPut]
        [Route("AlterarSenha")]
        public async Task<ActionResult> AlterarSenha([FromBody] UsuarioAlterarSenha usuarioAlterarSenha)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Id = usuarioAlterarSenha.Id,
                    Senha = usuarioAlterarSenha.Senha
                };

                await _usuarioAplicacao.AlterarSenhaAsync(usuarioDominio, usuarioAlterarSenha.SenhaAntiga);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao alterar senha do usuário: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Deletar/{usuarioId}")]
        public async Task<ActionResult> Deletar([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.DeletarAsync(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar usuário: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Restaurar/{usuarioId}")]
        public async Task<ActionResult> Restaurar([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.RestaurarAsync(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao restaurar usuário: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> Listar([FromQuery] bool ativos)
        {
            try
            {
                var usuariosDominio = await _usuarioAplicacao.ListarAsync(ativos);

                var usuarios = usuariosDominio.Select(usuario => new UsuarioResposta()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    TipoUsuario = usuario.TipoUsuario,
                    Genero = usuario.Genero,
                    DataNascimento = usuario.DataNascimento,
                    Peso = usuario.Peso,
                    Altura = usuario.Altura
                }).ToList();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar usuários: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ListarTiposUsuarios")]
        public ActionResult ListarTiposUsuario()
        {
            try
            {
                var tiposUsuarios = Enum.GetValues(typeof(TiposUsuario))
                                        .Cast<TiposUsuario>()
                                        .Select(t => new 
                                        {
                                            id = (int)t, nome = t.ToString()
                                        })
                                        .ToList();
                
                return Ok(tiposUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar os tipos de usuários: {ex.Message}");
            }
        }
    }
}