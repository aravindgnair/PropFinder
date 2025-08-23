using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropFinder.Application.DTOs;
using PropFinder.Application.Interfaces;

namespace PropFinder.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertiesController : ControllerBase
{
    private readonly ILogger<PropertiesController> _logger;
    private readonly IPropertyService _propertyService;

    public PropertiesController(ILogger<PropertiesController> logger,
        IPropertyService propertyService)
    {
        _logger = logger;
        _propertyService = propertyService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? type, decimal? minPrice, decimal? maxPrice)
    {
        var properties = await _propertyService.GetPropertiesAsync(null, null, null);
        
        return Ok(properties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var property = await _propertyService.GetPropertyByIdAsync(id);

        return Ok(property);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePropertyDto property)
    {
        var newProperty = await _propertyService.CreatePropertyAsync(property);

        return Ok(newProperty);
    }
}
