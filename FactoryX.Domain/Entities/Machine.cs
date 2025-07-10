namespace FactoryX.Domain.Entities;

public class Machine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int Capacity { get; set; }
    // Navigation properties can be added later
}