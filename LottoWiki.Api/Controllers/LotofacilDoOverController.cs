using LottoWiki.Api.Configurations;
using LottoWiki.Service.Interfaces.External;
using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotofacilDoOverController : ControllerBase
    {
        private readonly ILotoFacilQueryDoOver _service;
        private readonly ILogger<LotofacilDoOverController> _logger;

        public LotofacilDoOverController(ILotoFacilQueryDoOver service, ILogger<LotofacilDoOverController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("DoOver")]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetLast()
        {
            _logger.LogMethodInfo();
            int[] response = _service.GetLast();
            if (response == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(response);
        }
    }
}