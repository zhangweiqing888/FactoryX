using System.Linq.Expressions;
using FactoryX.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FactoryX.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;
    private DbSet<TEntity> _dbset; 

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbset = context.Set<TEntity>();
    }

    public void Create(TEntity entity)
    {
        _dbset.Add(entity);
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return Task.FromResult(_dbset.AsEnumerable());
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool trackChanges = false)
    {
        if (trackChanges)
        {
            return Task.FromResult(_dbset.Where(predicate).AsEnumerable());
        }
        return Task.FromResult(_dbset.AsNoTracking().Where(predicate).AsEnumerable());
    }

    public IQueryable<TEntity> GetAllQueryableAsync(bool trackChanges = false)
    {
        return trackChanges
            ? _dbset
            : _dbset.AsNoTracking();
    }
    public void Remove(TEntity entity)
    {
        _dbset.Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _dbset.Update(entity);
    }
}