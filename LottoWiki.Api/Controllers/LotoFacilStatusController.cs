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
            return Ok(response);
        }

        [HttpGet("lastId")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetLastId()
        {
            int id = _service.GetLastId();

            if (id == 0)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }

            return Ok(id);
        }

        [HttpGet("{id}/{col}/{qtd}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetByLuckyBall(int id, int col, int qtd)
        {
            char[] response = _service.GetByLuckyBall(id, col, qtd);
            string responseConverted = new string(response);
            if (response == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(responseConverted);
        }
    }
}