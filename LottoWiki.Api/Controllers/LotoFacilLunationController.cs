using LottoWiki.Api.Configurations;
using LottoWiki.Service.Interfaces.External;
using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotoFacilLunationController : ControllerBase
    {
        private readonly ILotoFacilQueryLunation _service;
        private readonly ILogger<LotoFacilLunationController> _logger;

        public LotoFacilLunationController(ILotoFacilQueryLunation service, ILogger<LotoFacilLunationController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("Crescente")]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetCrescentMoon()
        {
            int[] result = _service.GetCrescentMoon();
            if (result == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Cheia")]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetFullMoon()
        {
            int[] result = _service.GetFullMoon();
            if (result == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Nova")]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetNewMoon()
        {
            int[] result = _service.GetNewMoon();
            if (result == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Minguante")]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetWaningMoons()
        {
            int[] result = _service.GetWaningMoons();
            if (result == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("QuartoCrescente")]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetQuarterCrescenteMoon()
        {
            int[] result = _service.GetQuarterCrescenteMoon();
            if (result == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GibosaCrescente")]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetGibbousCrescentMoon()
        {
            int[] result = _service.GetGibbousCrescentMoon();
            if (result == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GibosaMinguante")]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetGibbousWaningMoon()
        {
            int[] result = _service.GetGibbousWaningMoon();
            if (result == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("QuartoMinguante")]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetQuarterWaningMoon()
        {
            int[] result = _service.GetQuarterWanningMoon();
            if (result == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(result);
        }
    }
}