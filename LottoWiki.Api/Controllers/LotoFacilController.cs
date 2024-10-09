using LottoWiki.Api.Configurations;
using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.ViewModels.Hateoas;
using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotoFacilController : ControllerBase
    {
        private readonly ILotoFacilService _service;
        private readonly ILogger<LotoFacilController> _logger;

        public LotoFacilController(ILotoFacilService service, ILogger<LotoFacilController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{concurso:int}")]
        [ProducesResponseType(typeof(LotoFacilResource), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetByConcurso(int concurso)
        {
            _logger.LogMethodInfo();
            var response = _service.GetById(concurso);
            if (response == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }

            var resource = new LotoFacilResource
            {
                Data = response,
                Links = AddLinksToResource(concurso)
            };

            return Ok(resource);
        }

        [HttpGet("last")]
        [ProducesResponseType(typeof(LotoFacilResource), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetLast()
        {
            _logger.LogMethodInfo();

            var response = _service.GetLast();
            if (response == null)
            {
                _logger.LogMethodWarning();
                return NotFound();
            }

            var resource = new LotoFacilResource
            {
                Data = response,
                Links = AddLinksToResource(null)
            };

            return Ok(resource);
        }

        private IDictionary<string, string> AddLinksToResource(int? concurso)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            var links = new Dictionary<string, string>
            {
                { "self", $"{baseUrl}/api/LotoFacil/{concurso}" },
                { "getLast", $"{baseUrl}/api/LotoFacil/last" }
            };

            return links;
        }
    }
}