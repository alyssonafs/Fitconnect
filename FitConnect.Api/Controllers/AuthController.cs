using FitConnect.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitConnect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthServiceAplicacao _authServiceAplicacao;

        public AuthController(IAuthServiceAplicacao authServiceAplicacao)
        {
            _authServiceAplicacao = authServiceAplicacao;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                var usuario = await _authServiceAplicacao.ValidarUsuario(login.Email, login.Senha);

                var token = await _authServiceAplicacao.GerarToken(usuario);

                return Ok(new
                {
                    token,
                    usuario = new
                    {
                        usuario.Id,
                        usuario.Email,
                        usuario.Nome
                    }
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost]
        [Route("solicitar-recuperacao")]
        public async Task<ActionResult> SolicitarRecuperacao([FromBody] EmailDTO email)
        {
            try
            {
                var usuario = await _authServiceAplicacao.SolicitarRecuperacaoAsync(email.Email);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("redefinir-senha")]
        public async Task<ActionResult> RedefinirSenha([FromBody] RedefinirSenhaDTO redefinirSenhaDTO)
        {
            try
            {
                var usuario = await _authServiceAplicacao.SolicitarRecuperacaoAsync(redefinirSenhaDTO.Email);

                await _authServiceAplicacao.RedefinirSenhaAsync(redefinirSenhaDTO.Email, redefinirSenhaDTO.NovaSenha, redefinirSenhaDTO.ConfirmarSenha);

                return Ok("Senha redefinida com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}