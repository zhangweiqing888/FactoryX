using FactoryX.Domain.Common;

namespace FactoryX.Domain.Entities;

public class WorkOrder : EntityBase
{
    public int ProductId { get; set; }
    public int MachineId { get; set; }
    public int Quantity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public Product? Product { get; set; }
    public Machine? Machine { get; set; }
    public ICollection<ProductionRecord>? ProductionRecords { get; set; }
    public ICollection<MaterialUsage>? MaterialUsages { get; set; }
}