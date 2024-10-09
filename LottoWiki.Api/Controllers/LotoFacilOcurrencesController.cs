using LottoWiki.Api.Configurations;
using LottoWiki.Service.Interfaces.External;
using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotoFacilOcurrencesController : ControllerBase
    {
        private readonly ILotoFacilQueryOcurrences _service;
        private readonly ILogger<LotoFacilOcurrencesController> _logger;

        public LotoFacilOcurrencesController(ILotoFacilQueryOcurrences service, ILogger<LotoFacilOcurrencesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<int>), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetByPeriod()
        {
            int[] ocurrences = _service.GetLast();
            if (ocurrences == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(ocurrences);
        }
    }
}