using FactoryX.Application.DTOs;
using FactoryX.Application.Services.Abstracts;
using FactoryX.Domain.Entities;
using FactoryX.Domain.Interfaces;

namespace FactoryX.Application.Services.Concretes;

public class ProductionRecordService : IProductionRecordService
{
    private readonly IRepository<ProductionRecord> _repository;
    private readonly IRepository<WorkOrder> _workOrderRepository;
    private readonly IRepository<Operator> _operatorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductionRecordService(IRepository<ProductionRecord> repository, IRepository<WorkOrder> workOrderRepository, IRepository<Operator> operatorRepository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _workOrderRepository = workOrderRepository;
        _operatorRepository = operatorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductionRecordDto>> GetAllAsync()
    {
        var records = await _repository.GetAllAsync();
        var workOrders = (await _workOrderRepository.GetAllAsync()).ToDictionary(w => w.Id, w => w);
        var operators = (await _operatorRepository.GetAllAsync()).ToDictionary(o => o.Id, o => o);
        return records.Select(r => ToDto(r, workOrders, operators));
    }

    public async Task<ProductionRecordDto?> GetByIdAsync(int id)
    {
        var record = await _repository.GetByIdAsync(id);
        if (record == null) return null;
        var workOrder = await _workOrderRepository.GetByIdAsync(record.WorkOrderId);
        var op = await _operatorRepository.GetByIdAsync(record.OperatorId);
        return ToDto(record, workOrder, op);
    }

    public async Task<ProductionRecordDto> CreateAsync(ProductionRecordDto dto)
    {
        var entity = FromDto(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return ToDto(entity);
    }

    public async Task UpdateAsync(ProductionRecordDto dto)
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

    private static ProductionRecordDto ToDto(ProductionRecord r, IDictionary<int, WorkOrder>? workOrders = null, IDictionary<int, Operator>? operators = null)
    {
        var dto = new ProductionRecordDto
        {
            Id = r.Id,
            WorkOrderId = r.WorkOrderId,
            OperatorId = r.OperatorId,
            QuantityProduced = r.QuantityProduced,
            Timestamp = r.Timestamp,
            WorkOrderName = workOrders != null && workOrders.TryGetValue(r.WorkOrderId, out var w) ? $"WO-{w.Id}" : null,
            OperatorName = operators != null && operators.TryGetValue(r.OperatorId, out var o) ? o.Name : null
        };
        return dto;
    }

    private static ProductionRecordDto ToDto(ProductionRecord r, WorkOrder? workOrder, Operator? op)
    {
        var dto = new ProductionRecordDto
        {
            Id = r.Id,
            WorkOrderId = r.WorkOrderId,
            OperatorId = r.OperatorId,
            QuantityProduced = r.QuantityProduced,
            Timestamp = r.Timestamp,
            WorkOrderName = workOrder != null ? $"WO-{workOrder.Id}" : null,
            OperatorName = op?.Name
        };
        return dto;
    }

    private static ProductionRecord FromDto(ProductionRecordDto dto) => new()
    {
        Id = dto.Id,
        WorkOrderId = dto.WorkOrderId,
        OperatorId = dto.OperatorId,
        QuantityProduced = dto.QuantityProduced,
        Timestamp = dto.Timestamp
    };
}