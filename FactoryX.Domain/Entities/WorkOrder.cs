namespace FactoryX.Domain.Entities;

public class WorkOrder
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int MachineId { get; set; }
    public int Quantity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
}