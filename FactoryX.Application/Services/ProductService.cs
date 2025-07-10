using FactoryX.Application.DTOs;
using FactoryX.Domain.Entities;
using FactoryX.Domain.Interfaces;

namespace FactoryX.Application.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        return products.Select(ToDto);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product == null ? null : ToDto(product);
    }

    public async Task<ProductDto> CreateAsync(ProductDto dto)
    {
        var entity = FromDto(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return ToDto(entity);
    }

    public async Task UpdateAsync(ProductDto dto)
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

    private static ProductDto ToDto(Product p) => new()
    {
        Id = p.Id,
        Name = p.Name,
        Code = p.Code,
        Description = p.Description
    };

    private static Product FromDto(ProductDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Code = dto.Code,
        Description = dto.Description
    };
}