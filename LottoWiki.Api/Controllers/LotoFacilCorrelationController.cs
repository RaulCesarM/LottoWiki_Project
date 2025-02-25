using LottoWiki.Api.Configurations;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.ViewModels.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotoFacilCorrelationController : ControllerBase
    {
        private readonly ILotoFacilQueryCorrelation _service;
        private readonly ILogger<LotoFacilCorrelationController> _logger;

        public LotoFacilCorrelationController(ILotoFacilQueryCorrelation service, ILogger<LotoFacilCorrelationController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(int[][]), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetByPeriod()
        {
            _logger.LogMethodInfo();
            var correlations = _service.PopulateArrayOfArrays(180);
            if (correlations == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(correlations);
        }

        [HttpGet("places/{key}")]
        [ProducesResponseType(typeof(LotoFacilViewModelCorrelationFriends), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetByKey([FromRoute] int key)
        {
            _logger.LogMethodInfo();
            LotoFacilViewModelCorrelationFriends correlations = _service.GetTopCorrelationsForTarget(key);
            if (correlations == null)
            {
                _logger.LogMethodWarning();
                return NotFound(new { Message = $"No correlations found for target with key {key}." });
            }

            return Ok(correlations);
        }

        [HttpGet("number/{number}")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetNumber([FromRoute] int number)
        {
            _logger.LogMethodInfo();
            int correlations = _service.GetMostCorrelatedNumber(number);
            if (correlations == null)
            {
                _logger.LogMethodWarning();
                return NotFound(new { Message = $"No correlations found for target with key {number}." });
            }

            return Ok(correlations);
        }

        [HttpGet("numberleast/{number}")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetLeastNumber([FromRoute] int number)
        {
            _logger.LogMethodInfo();
            int correlations = _service.GetLeastCorrelatedNumber(number);
            if (correlations == null)
            {
                _logger.LogMethodWarning();
                return NotFound(new { Message = $"No correlations found for target with key {number}." });
            }

            return Ok(correlations);
        }
    }
}