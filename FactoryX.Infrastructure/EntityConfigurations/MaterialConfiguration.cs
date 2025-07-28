using FactoryX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactoryX.Infrastructure.EntityConfigurations;

public class MaterialConfiguration : EntityBaseConfiguration<Material>
{
    public override void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable("materials");

        builder.Property(m => m.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(m => m.Code).IsUnique();

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Unit)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasMany(m => m.MaterialUsages)
            .WithOne(mu => mu.Material)
            .HasForeignKey(mu => mu.MaterialId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}