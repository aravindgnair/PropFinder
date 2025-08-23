using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropFinder.Domain.Entities;

namespace PropFinder.Infrastructure.Persistence.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
               .ValueGeneratedOnAdd();

        builder.Property(p => p.Address)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(p => p.Type)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.Price)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(p => p.Description)
               .HasMaxLength(1000);

        builder.HasMany(p => p.Spaces)
               .WithOne()
               .HasForeignKey(s => s.PropertyId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
