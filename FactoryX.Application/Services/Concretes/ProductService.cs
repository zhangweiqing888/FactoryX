using AutoMapper;
using FactoryX.Application.DTOs.Requests.ProductRequests;
using FactoryX.Application.DTOs.Responses.Product;
using FactoryX.Application.DTOs.Responses.ProductResponses;
using FactoryX.Application.Services.Abstracts;
using FactoryX.Domain.Entities;
using FactoryX.Infrastructure.Contracts;

namespace FactoryX.Application.Services.Concretes;

public class ProductService : IProductService
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IMapper _mapper;

	public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
	{
		_repositoryManager = repositoryManager;
		_mapper = mapper;
	}

	public async Task<IEnumerable<GetAllProductResponse>> GetAllAsync()
	{
		var products = await _repositoryManager.ProductRepository.GetAllAsync();
		return _mapper.Map<IEnumerable<GetAllProductResponse>>(products);
	}

	public async Task<GetProductResponse?> GetByIdAsync(int id)
	{
		var product = await _repositoryManager.ProductRepository.GetByIdAsync(id);
		return product == null ? null : _mapper.Map<GetProductResponse>(product);
	}

	public async Task<InsertProductResponse> CreateAsync(InsertProductRequest request)
	{
		var entity = _mapper.Map<Product>(request);
		_repositoryManager.ProductRepository.Create(entity);
		await _repositoryManager.SaveAsync();
		return _mapper.Map<InsertProductResponse>(entity);
	}

	public async Task UpdateAsync(UpdateProductRequest request)
	{
		var entity = _mapper.Map<Product>(request);
		_repositoryManager.ProductRepository.Update(entity);
		await _repositoryManager.SaveAsync();
	}

	public async Task DeleteAsync(DeleteProductRequest request)
	{
		var entity = await _repositoryManager.ProductRepository.GetByIdAsync(request.Id, trackChanges: true);
		if (entity != null)
		{
			_repositoryManager.ProductRepository.Remove(entity);
			await _repositoryManager.SaveAsync();
		}
	}
}