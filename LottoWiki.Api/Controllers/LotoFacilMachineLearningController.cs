using LottoWiki.Api.Configurations;
using LottoWiki.Service.Interfaces.MachineLearning;
using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotoFacilMachineLearningController : ControllerBase
    {
        private readonly ILotoFacilDataModelService _service;
        private readonly ILogger<LotoFacilMachineLearningController> _logger;

        public LotoFacilMachineLearningController(ILotoFacilDataModelService service, ILogger<LotoFacilMachineLearningController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("CSV-DataModel")]
        public IActionResult GetCsv()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "path", "data_model.csv");
            _logger.LogMethodInfo();
            _service.CreateCsv(path);

            return Ok();
        }
    }
}