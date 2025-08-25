using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropFinder.Domain.Entities;

namespace PropFinder.Infrastructure.Persistence.Configurations;

public class SpaceConfiguration : IEntityTypeConfiguration<Space>
{
    public void Configure(EntityTypeBuilder<Space> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
               .ValueGeneratedOnAdd();

        builder.Property(s => s.Type)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.Size)
               .HasColumnType("float")
               .IsRequired();

        builder.Property(s => s.Description)
               .HasMaxLength(500);
    }
}
