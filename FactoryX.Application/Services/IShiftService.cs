using FactoryX.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryX.Application.Services;

public interface IShiftService
{
    Task<IEnumerable<ShiftDto>> GetAllAsync();
    Task<ShiftDto?> GetByIdAsync(int id);
    Task<ShiftDto> CreateAsync(ShiftDto dto);
    Task UpdateAsync(ShiftDto dto);
    Task DeleteAsync(int id);
}