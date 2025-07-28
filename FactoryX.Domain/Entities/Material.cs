using FactoryX.Domain.Common;

namespace FactoryX.Domain.Entities;

public class Material : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public ICollection<MaterialUsage>? MaterialUsages { get; set; }
}