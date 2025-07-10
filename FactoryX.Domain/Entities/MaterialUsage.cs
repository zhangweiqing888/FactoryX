namespace FactoryX.Domain.Entities;

public class MaterialUsage
{
    public int Id { get; set; }
    public int WorkOrderId { get; set; }
    public int MaterialId { get; set; }
    public int Quantity { get; set; }
}