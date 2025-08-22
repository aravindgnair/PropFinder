using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PropFinder.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertiesController : ControllerBase
{
    private readonly ILogger<PropertiesController> _logger;

    public PropertiesController(ILogger<PropertiesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] object property)
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }
}
