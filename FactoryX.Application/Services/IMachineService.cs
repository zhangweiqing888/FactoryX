using FactoryX.Application.DTOs;

namespace FactoryX.Application.Services;

public interface IMachineService
{
    Task<IEnumerable<MachineDto>> GetAllAsync();
    Task<MachineDto?> GetByIdAsync(int id);
    Task<MachineDto> CreateAsync(MachineDto dto);
    Task UpdateAsync(MachineDto dto);
    Task DeleteAsync(int id);
}