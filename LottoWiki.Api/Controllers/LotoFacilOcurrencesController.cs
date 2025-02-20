using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Api.Configurations;
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

        [HttpGet("Ocurrences")]
        [ProducesResponseType(typeof(LotoFacilViewModelSmal), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetByPeriod()
        {
            LotoFacilViewModelSmal response = _service.GetLast();
            if (response == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("Ocurrences/{id}")]
        [ProducesResponseType(typeof(LotoFacilViewModelSmal), 200)]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetById([FromRoute] int id)
        {
            _logger.LogMethodInfo();
            LotoFacilViewModelSmal response = _service.GetById(id);
            if (response == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("teste")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetTest()
        {
            _logger.LogMethodInfo();
            int response = _service.GetRequiredContest(11, 3323, 5);
            if (response == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(response);
        }
    }
}