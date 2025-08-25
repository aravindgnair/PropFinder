using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PropFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpacesController : ControllerBase
    {
        private readonly ILogger<SpacesController> _logger;

        public SpacesController(ILogger<SpacesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException("This method is not implemented yet.");
        }
    }
}
