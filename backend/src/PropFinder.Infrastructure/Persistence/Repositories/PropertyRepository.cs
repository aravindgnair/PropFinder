using PropFinder.Application.Interfaces;
using PropFinder.Domain.Entities;

namespace PropFinder.Infrastructure.Persistence.Repositories;

public class PropertyRepository : IPropertyRepository
{
    public Task AddAsync(Property property)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Property>> GetAllAsync(string? type, decimal? minPrice, decimal? maxPrice)
    {
        throw new NotImplementedException();
    }

    public Task<Property?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
