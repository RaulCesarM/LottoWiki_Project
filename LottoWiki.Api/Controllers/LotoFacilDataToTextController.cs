using LottoWiki.Api.Configurations;
using LottoWiki.Service.Interfaces.External;

using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotoFacilDataToTextController : ControllerBase
    {
        private readonly ILotoFacilQueryDataToText _service;
        private readonly ILogger<LotoFacilDataToTextController> _logger;

        public LotoFacilDataToTextController(ILotoFacilQueryDataToText service, ILogger<LotoFacilDataToTextController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("csv")]
        public IActionResult GetCsv()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "path", "arquivo.csv");
            _logger.LogMethodInfo();
            _service.CreateCsv(path);

            return Ok();
        }
    }
}