using FactoryX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactoryX.Infrastructure.EntityConfigurations;

public class WorkOrderConfiguration : EntityBaseConfiguration<WorkOrder>
{
    public override void Configure(EntityTypeBuilder<WorkOrder> builder)
    {
        base.Configure(builder);

        builder.ToTable("work_orders");

        builder.Property(w => w.Status).IsRequired().HasMaxLength(30);

        builder.HasOne(w => w.Product)
            .WithMany(p => p.WorkOrders)
            .HasForeignKey(w => w.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(w => w.Machine)
            .WithMany(m => m.WorkOrders)
            .HasForeignKey(w => w.MachineId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(w => w.ProductionRecords)
            .WithOne(pr => pr.WorkOrder)
            .HasForeignKey(pr => pr.WorkOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(w => w.MaterialUsages)
            .WithOne(mu => mu.WorkOrder)
            .HasForeignKey(mu => mu.WorkOrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}