using FactoryX.Application.DTOs;
using FactoryX.Domain.Entities;
using FactoryX.Domain.Interfaces;

namespace FactoryX.Application.Services;

public class WorkOrderService : IWorkOrderService
{
    private readonly IRepository<WorkOrder> _repository;
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Machine> _machineRepository;
    private readonly IUnitOfWork _unitOfWork;

    public WorkOrderService(IRepository<WorkOrder> repository, IRepository<Product> productRepository, IRepository<Machine> machineRepository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _productRepository = productRepository;
        _machineRepository = machineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WorkOrderDto>> GetAllAsync()
    {
        var workOrders = await _repository.GetAllAsync();
        var products = (await _productRepository.GetAllAsync()).ToDictionary(p => p.Id, p => p);
        var machines = (await _machineRepository.GetAllAsync()).ToDictionary(m => m.Id, m => m);
        return workOrders.Select(w => ToDto(w, products, machines));
    }

    public async Task<WorkOrderDto?> GetByIdAsync(int id)
    {
        var workOrder = await _repository.GetByIdAsync(id);
        if (workOrder == null) return null;
        var product = await _productRepository.GetByIdAsync(workOrder.ProductId);
        var machine = await _machineRepository.GetByIdAsync(workOrder.MachineId);
        return ToDto(workOrder, product, machine);
    }

    public async Task<WorkOrderDto> CreateAsync(WorkOrderDto dto)
    {
        var entity = FromDto(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return ToDto(entity);
    }

    public async Task UpdateAsync(WorkOrderDto dto)
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

    private static WorkOrderDto ToDto(WorkOrder w, IDictionary<int, Product>? products = null, IDictionary<int, Machine>? machines = null)
    {
        var dto = new WorkOrderDto
        {
            Id = w.Id,
            ProductId = w.ProductId,
            MachineId = w.MachineId,
            Quantity = w.Quantity,
            StartDate = w.StartDate,
            EndDate = w.EndDate,
            Status = w.Status,
            ProductName = products != null && products.TryGetValue(w.ProductId, out var p) ? p.Name : null,
            MachineName = machines != null && machines.TryGetValue(w.MachineId, out var m) ? m.Name : null
        };
        return dto;
    }

    private static WorkOrderDto ToDto(WorkOrder w, Product? product, Machine? machine)
    {
        var dto = new WorkOrderDto
        {
            Id = w.Id,
            ProductId = w.ProductId,
            MachineId = w.MachineId,
            Quantity = w.Quantity,
            StartDate = w.StartDate,
            EndDate = w.EndDate,
            Status = w.Status,
            ProductName = product?.Name,
            MachineName = machine?.Name
        };
        return dto;
    }

    private static WorkOrder FromDto(WorkOrderDto dto) => new()
    {
        Id = dto.Id,
        ProductId = dto.ProductId,
        MachineId = dto.MachineId,
        Quantity = dto.Quantity,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        Status = dto.Status
    };
}