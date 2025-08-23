using PropFinder.Application.Interfaces;
using PropFinder.Domain.Entities;

namespace PropFinder.Infrastructure.Persistence.Repositories;

public class SpaceRepository : ISpaceRepository
{
    public Task AddAsync(Space space)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Space>> GetAllAsync(Guid? propertyId, string? type, float? minSize)
    {
        throw new NotImplementedException();
    }

    public Task<Space?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
