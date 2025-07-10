using FactoryX.Application.DTOs;

namespace FactoryX.Application.Services;

public interface IWorkOrderService
{
    Task<IEnumerable<WorkOrderDto>> GetAllAsync();
    Task<WorkOrderDto?> GetByIdAsync(int id);
    Task<WorkOrderDto> CreateAsync(WorkOrderDto dto);
    Task UpdateAsync(WorkOrderDto dto);
    Task DeleteAsync(int id);
}