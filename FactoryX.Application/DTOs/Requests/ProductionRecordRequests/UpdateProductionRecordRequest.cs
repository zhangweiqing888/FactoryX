namespace FactoryX.Application.DTOs.Requests.ProductionRecordRequests;

public sealed record UpdateProductionRecordRequest(
	int WorkOrderId,
	int OperatorId,
	int QuantityProduced,
	DateTime Timestamp);
