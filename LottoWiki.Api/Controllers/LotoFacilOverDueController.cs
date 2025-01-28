using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Api.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotoFacilOverDueController : ControllerBase
    {
        private readonly ILotoFacilQueryOverdue _service;
        private readonly ILogger<LotoFacilOverDueController> _logger;

        public LotoFacilOverDueController(ILotoFacilQueryOverdue service, ILogger<LotoFacilOverDueController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("OverDue")]
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

        [HttpGet("OverDue/{id}")]
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