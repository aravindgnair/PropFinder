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
    [ProducesResponseType(typeof(IEnumerable<PropertyDetailDto>), 200)]
    public async Task<IActionResult> Get(string? type, decimal? minPrice, decimal? maxPrice)
    {
        var properties = await _propertyService.GetPropertiesAsync(null, null, null);
        
        return Ok(properties);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PropertyDetailDto), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var property = await _propertyService.GetPropertyByIdAsync(id);

        if (property == null)
        {
            return NotFound("Property not found");
        }

        return Ok(property);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PropertyDetailDto), 200)]
    public async Task<IActionResult> Create([FromBody] CreatePropertyDto property)
    {
        var newProperty = await _propertyService.CreatePropertyAsync(property);
        
        return Ok(newProperty);
    }
}
