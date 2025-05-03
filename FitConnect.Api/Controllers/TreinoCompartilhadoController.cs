using FitConnect.Aplicacao.Interfaces;
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
    }
}