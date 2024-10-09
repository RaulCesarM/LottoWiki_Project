using LottoWiki.Service.Interfaces.MachineLearning.Training;
using Microsoft.AspNetCore.Mvc;

namespace LottoWiki.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotoFacilMachineLearningOperations : ControllerBase
    {
        private readonly IDataConverter _data;

        public LotoFacilMachineLearningOperations(IDataConverter data)
        {
            _data = data;
        }

        [HttpGet("Create CSV")]
        public async Task<IActionResult> CreateCsvFile()
        {
            try
            {
                var result = await _data.CreateCSV();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}