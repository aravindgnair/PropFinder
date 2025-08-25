using PropFinder.Domain.Entities;

namespace PropFinder.Application.Interfaces;

public interface IPropertyRepository
{
    Task<IEnumerable<Property>> GetAllAsync(string? type, decimal? minPrice, decimal? maxPrice);
    Task<Property?> GetByIdAsync(Guid id);
    Task AddAsync(Property property);
    Task SaveChangesAsync();
}
