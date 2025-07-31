using FactoryX.Domain.Entities;
using FactoryX.Infrastructure.Contracts;

namespace FactoryX.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}

