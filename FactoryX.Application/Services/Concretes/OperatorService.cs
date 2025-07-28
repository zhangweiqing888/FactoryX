using FactoryX.Application.DTOs;
using FactoryX.Application.Services.Abstracts;
using FactoryX.Domain.Entities;
using FactoryX.Domain.Interfaces;

namespace FactoryX.Application.Services.Concretes;

public class OperatorService : IOperatorService
{
    private readonly IRepository<Operator> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public OperatorService(IRepository<Operator> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OperatorDto>> GetAllAsync()
    {
        var operators = await _repository.GetAllAsync();
        return operators.Select(ToDto);
    }

    public async Task<OperatorDto?> GetByIdAsync(int id)
    {
        var op = await _repository.GetByIdAsync(id);
        return op == null ? null : ToDto(op);
    }

    public async Task<OperatorDto> CreateAsync(OperatorDto dto)
    {
        var entity = FromDto(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return ToDto(entity);
    }

    public async Task UpdateAsync(OperatorDto dto)
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

    private static OperatorDto ToDto(Operator o) => new()
    {
        Id = o.Id,
        Name = o.Name,
        EmployeeNumber = o.EmployeeNumber
    };

    private static Operator FromDto(OperatorDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        EmployeeNumber = dto.EmployeeNumber
    };
}