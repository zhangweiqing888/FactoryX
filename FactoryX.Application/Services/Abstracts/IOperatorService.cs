using FactoryX.Application.DTOs;

namespace FactoryX.Application.Services.Abstracts;

public interface IOperatorService
{
    Task<IEnumerable<OperatorDto>> GetAllAsync();
    Task<OperatorDto?> GetByIdAsync(int id);
    Task<OperatorDto> CreateAsync(OperatorDto dto);
    Task UpdateAsync(OperatorDto dto);
    Task DeleteAsync(int id);
}