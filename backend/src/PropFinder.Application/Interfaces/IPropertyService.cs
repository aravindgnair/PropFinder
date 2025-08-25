using PropFinder.Application.DTOs;

namespace PropFinder.Application.Interfaces;

public interface IPropertyService
{
    Task<PropertyDetailDto> CreatePropertyAsync(CreatePropertyDto dto);
    Task<IEnumerable<PropertyDetailDto>> GetPropertiesAsync(string? type, decimal? minPrice, decimal? maxPrice);
    Task<PropertyDetailDto?> GetPropertyByIdAsync(Guid id);
}
