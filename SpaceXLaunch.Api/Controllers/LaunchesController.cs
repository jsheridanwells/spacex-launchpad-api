using System.Threading.Tasks;
using LaunchData.Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace SpaceXLaunch.Api.Controllers
{
    [Route("api/[controller]")]
    public class LaunchesController : Controller
    {
        private readonly ILaunchDataService _service;
        public LaunchesController(ILaunchDataService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetLaunches()
        {
            var launches = await _service.GetLaunchData();
            return Ok(launches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLaunchpadById([FromRoute] string id)
        {
            var launchpad = await _service.GetLaunchpadDataById(id);

            if (launchpad == null)
            {
                return NotFound();
            }

            return Ok(launchpad);
        }
    }
}
