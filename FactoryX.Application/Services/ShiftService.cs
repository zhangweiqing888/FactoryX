using FactoryX.Application.DTOs;
using FactoryX.Domain.Entities;
using FactoryX.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryX.Application.Services;

public class ShiftService : IShiftService
{
    private readonly IRepository<Shift> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ShiftService(IRepository<Shift> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ShiftDto>> GetAllAsync()
    {
        var shifts = await _repository.GetAllAsync();
        var list = new List<ShiftDto>();
        foreach (var s in shifts)
        {
            list.Add(ToDto(s));
        }
        return list;
    }

    public async Task<ShiftDto?> GetByIdAsync(int id)
    {
        var shift = await _repository.GetByIdAsync(id);
        return shift == null ? null : ToDto(shift);
    }

    public async Task<ShiftDto> CreateAsync(ShiftDto dto)
    {
        var entity = FromDto(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return ToDto(entity);
    }

    public async Task UpdateAsync(ShiftDto dto)
    {
        var entity = FromDto(dto);
        _repository.Update(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            _repository.Remove(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    private static ShiftDto ToDto(Shift s) => new()
    {
        Id = s.Id,
        Name = s.Name,
        StartTime = s.StartTime,
        EndTime = s.EndTime
    };

    private static Shift FromDto(ShiftDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        StartTime = dto.StartTime,
        EndTime = dto.EndTime
    };
}