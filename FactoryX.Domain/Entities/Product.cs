using FactoryX.Domain.Common;

namespace FactoryX.Domain.Entities;

public class Product : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<WorkOrder>? WorkOrders { get; set; }
}