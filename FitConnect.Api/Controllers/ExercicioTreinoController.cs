using FitConnect.Aplicacao.Interfaces;
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
    }
}