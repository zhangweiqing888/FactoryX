namespace FactoryX.Application.DTOs.Requests.ProductRequests;

public sealed record UpdateProductRequest(
	string Name,
	string Code,
	string Description);
