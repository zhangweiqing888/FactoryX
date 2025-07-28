using FactoryX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactoryX.Infrastructure.EntityConfigurations;

public class ProductConfiguration : EntityBaseConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasIndex(p => p.Code)
            .IsUnique();

        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .HasMaxLength(255);

        builder.HasMany(p => p.WorkOrders)
            .WithOne(w => w.Product)
            .HasForeignKey(w => w.ProductId);
    }
}