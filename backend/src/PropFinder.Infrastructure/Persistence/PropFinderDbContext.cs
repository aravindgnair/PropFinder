using Microsoft.EntityFrameworkCore;
using PropFinder.Domain.Entities;
using PropFinder.Infrastructure.Persistence.Configurations;

namespace PropFinder.Infrastructure.Persistence;

public class PropFinderDbContext(DbContextOptions<PropFinderDbContext> options) : DbContext(options)
{
    public DbSet<Property> Properties { get; set; }
    public DbSet<Space> Spaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PropertyConfiguration());
        modelBuilder.ApplyConfiguration(new SpaceConfiguration());
    }
}
