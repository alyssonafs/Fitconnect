using FitConnect.Aplicacao.Interfaces;
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
    }
}