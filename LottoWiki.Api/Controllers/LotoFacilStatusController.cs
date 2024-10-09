using LottoWiki.Api.Configurations;
using LottoWiki.Service.Interfaces.External;
using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotoFacilStatusController : ControllerBase
    {
        private readonly ILogger<LotoFacilStatusController> _logger;
        private readonly ILotoFacilQueryStatus _service;

        public LotoFacilStatusController(ILotoFacilQueryStatus service, ILogger<LotoFacilStatusController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(char[]), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetById(int id)
        {
            char[] response = _service.GetById(id);
            if (response == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(id);
        }

        [HttpGet("last")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetLastId()
        {
            int response = _service.GetLastId();
            if (response == 0)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(response);
        }
    }
}