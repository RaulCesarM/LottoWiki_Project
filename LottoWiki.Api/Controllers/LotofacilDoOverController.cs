using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Api.Configurations;
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
        [ProducesResponseType(typeof(LotoFacilViewModelSmal), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetLast()
        {
            _logger.LogMethodInfo();
            LotoFacilViewModelSmal response = _service.GetLast();
            if (response == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("DoOver/{id}")]
        [ProducesResponseType(typeof(LotoFacilViewModelSmal), 200)]
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
    }
}