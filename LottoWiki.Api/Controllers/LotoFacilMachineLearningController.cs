using LotoWiki.MachineLearning.Interfaces;
using LottoWiki.Api.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotoFacilMachineLearningController : ControllerBase
    {
        private readonly ITraining _service;
        private readonly IConsumir _consumir;
        private readonly ILogger<LotoFacilMachineLearningController> _logger;

        public LotoFacilMachineLearningController(
            ITraining service,
            IConsumir consumir,
            ILogger<LotoFacilMachineLearningController> logger)
        {
            _logger = logger;
            _service = service;
            _consumir = consumir;
        }

        [HttpGet("Treino")]
        public IActionResult GetTest()
        {
            _logger.LogMethodInfo();
            _service.PrepararModelo();

            return Ok();
        }

        [HttpGet("Teste")]
        public IActionResult Prever([FromQuery] string sequencia)
        {
            var previsao = _consumir.Prever(sequencia);
            return Ok(new { Sequencia = sequencia, Previsao = previsao });
        }
    }
}