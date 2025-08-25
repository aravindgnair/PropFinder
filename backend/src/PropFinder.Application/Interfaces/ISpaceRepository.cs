using PropFinder.Domain.Entities;

namespace PropFinder.Application.Interfaces;

public interface ISpaceRepository
{
    Task<IEnumerable<Space>> GetAllAsync(Guid? propertyId, string? type, float? minSize);
    Task<Space?> GetByIdAsync(Guid id);
    Task AddAsync(Space space);
    Task SaveChangesAsync();
}
