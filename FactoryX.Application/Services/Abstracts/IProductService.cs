using FactoryX.Application.DTOs.Requests.ProductRequests;
using FactoryX.Application.DTOs.Responses.Product;
using FactoryX.Application.DTOs.Responses.ProductResponses;

namespace FactoryX.Application.Services.Abstracts;

public interface IProductService
{
	Task<IEnumerable<GetAllProductResponse>> GetAllAsync();
	Task<GetProductResponse?> GetByIdAsync(int id);
	Task<InsertProductResponse> CreateAsync(InsertProductRequest request);
	Task UpdateAsync(UpdateProductRequest request);
	Task DeleteAsync(DeleteProductRequest request);
}