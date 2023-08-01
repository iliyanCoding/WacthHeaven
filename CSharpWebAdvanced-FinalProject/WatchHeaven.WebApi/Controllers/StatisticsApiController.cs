using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Services.Data.Models.Statistics;

namespace WatchHeaven.WebApi.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IWatchService _watchService;

        public StatisticsApiController(IWatchService watchService)
        {
            this._watchService = watchService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatistics() 
        {
            try
            {
                StatisticsServiceModel serviceModel = await this._watchService.GetStatisticsAsync();

                return Ok(serviceModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
