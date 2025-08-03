using AutoMapper;
using FactoryX.Application.DTOs.Requests.WorkOrderRequests;
using FactoryX.Application.DTOs.Responses.WorkOrder;
using FactoryX.Application.DTOs.Responses.WorkOrderResponses;
using FactoryX.Application.Services.Abstracts;
using FactoryX.Domain.Entities;
using FactoryX.Infrastructure.Contracts;

namespace FactoryX.Application.Services.Concretes;

public class WorkOrderService : IWorkOrderService
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IMapper _mapper;

	public WorkOrderService(IRepositoryManager repositoryManager, IMapper mapper)
	{
		_repositoryManager = repositoryManager;
		_mapper = mapper;
	}

	public async Task<IEnumerable<GetAllWorkOrderResponse>> GetAllAsync()
	{
		var workOrders = await _repositoryManager.WorkOrderRepository.GetAllAsync();
		var products = (await _repositoryManager.ProductRepository.GetAllAsync()).ToDictionary(p => p.Id, p => p);
		var machines = (await _repositoryManager.MachineRepository.GetAllAsync()).ToDictionary(m => m.Id, m => m);
		return workOrders.Select(w => new GetAllWorkOrderResponse(
			w.Id,
			CreatedAt: w.CreatedAt,
			UpdatedAt: w.UpdatedAt,
			ProductId: w.ProductId,
			ProductName: products.TryGetValue(w.ProductId, out var productName) ? productName.ToString() : null,
			MachineId: w.MachineId,
			MachineName: machines.TryGetValue(w.MachineId, out var machineName) ? machineName.ToString() : null,
			Quantity: w.Quantity,
			StartDate: w.StartDate,
			EndDate: w.EndDate,
			Status: w.Status
		));
	}

	public async Task<GetWorkOrderResponse?> GetByIdAsync(int id)
	{
		var workOrder = await _repositoryManager.WorkOrderRepository.GetByIdAsync(id);
		if (workOrder == null) return null;
		var product = await _repositoryManager.ProductRepository.GetByIdAsync(workOrder.ProductId);
		var machine = await _repositoryManager.MachineRepository.GetByIdAsync(workOrder.MachineId);
		return new GetWorkOrderResponse(
		   Id: workOrder.Id,
		   CreatedAt: workOrder.CreatedAt,
		   UpdatedAt: workOrder.UpdatedAt,
		   ProductId: workOrder.ProductId,
		   ProductName: product?.Name,
		   MachineId: workOrder.MachineId,
		   MachineName: machine?.Name,
		   Quantity: workOrder.Quantity,
		   StartDate: workOrder.StartDate,
		   EndDate: workOrder.EndDate,
		   Status: workOrder.Status);
	}

	public async Task<InsertWorkOrderResponse> CreateAsync(InsertWorkOrderRequest request)
	{
		var workOrder = _mapper.Map<WorkOrder>(request);
		_repositoryManager.WorkOrderRepository.Create(workOrder);
		await _repositoryManager.SaveAsync();

		return _mapper.Map<InsertWorkOrderResponse>(workOrder);
	}

	public async Task UpdateAsync(UpdateWorkOrderRequest request)
	{
		WorkOrder? workOrder = await _repositoryManager.WorkOrderRepository.GetByIdAsync(request.Id);
		if (workOrder == null) return;

		_mapper.Map(request, workOrder);
		_repositoryManager.WorkOrderRepository.Update(workOrder);
		await _repositoryManager.SaveAsync();
	}

	public async Task DeleteAsync(DeleteWorkOrderRequest request)
	{
		WorkOrder? entity = await _repositoryManager.WorkOrderRepository.GetByIdAsync(request.Id);
		if (entity != null)
		{
			_repositoryManager.WorkOrderRepository.Remove(entity);
			await _repositoryManager.SaveAsync();
		}
	}
}