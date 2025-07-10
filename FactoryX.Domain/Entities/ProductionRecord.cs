namespace FactoryX.Domain.Entities;

public class ProductionRecord
{
    public int Id { get; set; }
    public int WorkOrderId { get; set; }
    public int OperatorId { get; set; }
    public int QuantityProduced { get; set; }
    public DateTime Timestamp { get; set; }
}