using FitConnect.Aplicacao.Interfaces;
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
    }
}