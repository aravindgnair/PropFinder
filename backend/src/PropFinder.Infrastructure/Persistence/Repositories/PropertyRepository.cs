using Microsoft.EntityFrameworkCore;
using PropFinder.Application.Interfaces;
using PropFinder.Domain.Entities;

namespace PropFinder.Infrastructure.Persistence.Repositories;

public class PropertyRepository(PropFinderDbContext context) : IPropertyRepository
{
    private readonly PropFinderDbContext _context = context;

    public async Task<IEnumerable<Property>> GetAllAsync(string? type, decimal? minPrice, decimal? maxPrice)
    {
        var query = _context.Properties.Include(p => p.Spaces).AsQueryable();

        if (!string.IsNullOrEmpty(type))
            query = query.Where(p => p.Type == type);

        if (minPrice.HasValue)
            query = query.Where(p => p.Price >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(p => p.Price <= maxPrice.Value);

        return await query.ToListAsync();
    }

    public async Task<Property?> GetByIdAsync(Guid id)
    {
        return await _context.Properties
                             .Include(p => p.Spaces)
                             .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Property property)
    {
        await _context.Properties.AddAsync(property);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}