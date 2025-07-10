using FactoryX.Application.DTOs;
using FactoryX.Domain.Entities;
using FactoryX.Domain.Interfaces;

namespace FactoryX.Application.Services;

public class MachineService : IMachineService
{
    private readonly IRepository<Machine> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public MachineService(IRepository<Machine> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MachineDto>> GetAllAsync()
    {
        var machines = await _repository.GetAllAsync();
        return machines.Select(m => ToDto(m));
    }

    public async Task<MachineDto?> GetByIdAsync(int id)
    {
        var machine = await _repository.GetByIdAsync(id);
        return machine == null ? null : ToDto(machine);
    }

    public async Task<MachineDto> CreateAsync(MachineDto dto)
    {
        var entity = FromDto(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return ToDto(entity);
    }

    public async Task UpdateAsync(MachineDto dto)
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

    private static MachineDto ToDto(Machine m) => new()
    {
        Id = m.Id,
        Name = m.Name,
        Status = m.Status,
        Capacity = m.Capacity
    };

    private static Machine FromDto(MachineDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Status = dto.Status,
        Capacity = dto.Capacity
    };
}