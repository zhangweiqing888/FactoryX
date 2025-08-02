using FactoryX.Application.DTOs.Requests.WorkOrderRequests;
using FactoryX.Application.DTOs.Responses.WorkOrder;
using FactoryX.Application.DTOs.Responses.WorkOrderResponses;

namespace FactoryX.Application.Services.Abstracts;

public interface IWorkOrderService
{
	Task<IEnumerable<GetAllWorkOrderResponse>> GetAllAsync();
	Task<GetWorkOrderResponse?> GetByIdAsync(int id);
	Task<InsertWorkOrderResponse> CreateAsync(InsertWorkOrderRequest request);
	Task UpdateAsync(UpdateWorkOrderRequest request);
	Task DeleteAsync(DeleteWorkOrderRequest request);
}