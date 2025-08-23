using PropFinder.Application.DTOs;
using PropFinder.Application.Interfaces;
using PropFinder.Domain.Entities;

namespace PropFinder.Application.Services;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;

    public PropertyService(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }

    public async Task<IEnumerable<PropertyDetailDto>> GetPropertiesAsync(string? type, decimal? minPrice, decimal? maxPrice)
    {
        var properties = await _propertyRepository.GetAllAsync(type, minPrice, maxPrice);

        return properties.Select(p => new PropertyDetailDto
        {
            Id = p.Id,
            Address = p.Address,
            Type = p.Type,
            Price = p.Price,
            Description = p.Description,
            Spaces = p.Spaces.Select(s => new SpaceDetailDto
            {
                Id = s.Id,
                Type = s.Type,
                Size = s.Size,
                Description = s.Description
            }).ToList()
        });
    }

    public async Task<PropertyDetailDto?> GetPropertyByIdAsync(Guid id)
    {
        var property = await _propertyRepository.GetByIdAsync(id);

        if (property == null) return null;

        return new PropertyDetailDto
        {
            Id = property.Id,
            Address = property.Address,
            Type = property.Type,
            Price = property.Price,
            Description = property.Description,
            Spaces = property.Spaces.Select(s => new SpaceDetailDto
            {
                Id = s.Id,
                Type = s.Type,
                Size = s.Size,
                Description = s.Description
            }).ToList()
        };
    }

    public async Task<PropertyDetailDto> CreatePropertyAsync(CreatePropertyDto dto)
    {
        var property = new Property
        {
            Id = Guid.NewGuid(),
            Address = dto.Address,
            Type = dto.Type,
            Price = dto.Price,
            Description = dto.Description,
            Spaces = dto.Spaces?.Select(s => new Space
            {
                Id = Guid.NewGuid(),
                Type = s.Type,
                Size = s.Size,
                Description = s.Description
            }).ToList() ?? new List<Space>()
        };

        await _propertyRepository.AddAsync(property);

        return await GetPropertyByIdAsync(property.Id) ?? throw new Exception("Failed to create property.");
    }
}
