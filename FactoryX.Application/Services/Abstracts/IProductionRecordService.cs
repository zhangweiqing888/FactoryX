using FactoryX.Application.DTOs;

namespace FactoryX.Application.Services.Abstracts;

public interface IProductionRecordService
{
    Task<IEnumerable<ProductionRecordDto>> GetAllAsync();
    Task<ProductionRecordDto?> GetByIdAsync(int id);
    Task<ProductionRecordDto> CreateAsync(ProductionRecordDto dto);
    Task UpdateAsync(ProductionRecordDto dto);
    Task DeleteAsync(int id);
}