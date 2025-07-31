using AutoMapper;
using FactoryX.Application.DTOs;
using FactoryX.Application.DTOs.Requests.MachineRequests;
using FactoryX.Application.Services.Abstracts;
using FactoryX.Domain.Entities;
using FactoryX.Domain.Interfaces;
using FactoryX.Infrastructure.Contracts;

namespace FactoryX.Application.Services.Concretes;

public class MachineService : IMachineService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IRepository<Machine> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MachineService(IRepository<Machine> repository, IUnitOfWork unitOfWork, IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MachineDto>> GetAllAsync()
    {
        var machines = await _repositoryManager.MachineRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MachineDto>>(machines);
    }

    public async Task<MachineDto?> GetByIdAsync(int id)
    {
        var machine = await _repositoryManager.MachineRepository.GetByIdAsync(id);
        return machine == null ? null : _mapper.Map<MachineDto>(machine);
    }

    public async Task<MachineDto> CreateAsync(MachineDto dto)
    {
        var entity = _mapper.Map<Machine>(request);

    }

    public async Task UpdateAsync(MachineDto dto)
    {
        var entity = _mapper.Map<Machine>(dto);
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
}