using Microsoft.EntityFrameworkCore;
using PropFinder.Application.Interfaces;
using PropFinder.Domain.Entities;

namespace PropFinder.Infrastructure.Persistence.Repositories;

public class SpaceRepository(PropFinderDbContext context) : ISpaceRepository
{
    private readonly PropFinderDbContext _context = context;

    public async Task<IEnumerable<Space>> GetAllAsync(Guid? propertyId, string? type, float? minSize)
    {
        var query = _context.Spaces.AsQueryable();

        if (propertyId.HasValue)
            query = query.Where(s => s.PropertyId == propertyId.Value);

        if (!string.IsNullOrEmpty(type))
            query = query.Where(s => s.Type == type);

        if (minSize.HasValue)
            query = query.Where(s => s.Size >= minSize.Value);

        return await query.ToListAsync();
    }

    public async Task<Space?> GetByIdAsync(Guid id)
    {
        return await _context.Spaces.FindAsync(id);
    }

    public async Task AddAsync(Space space)
    {
        await _context.Spaces.AddAsync(space);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
