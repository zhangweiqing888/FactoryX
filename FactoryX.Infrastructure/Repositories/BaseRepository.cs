using System.Linq.Expressions;
using FactoryX.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FactoryX.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult(_context.Set<T>().AsEnumerable());
    }

    public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, bool trackChanges = false)
    {
        if (trackChanges)
        {
            return Task.FromResult(_context.Set<T>().Where(predicate).AsEnumerable());
        }
        return Task.FromResult(_context.Set<T>().AsNoTracking().Where(predicate).AsEnumerable());
    }

    public IQueryable<T> GetAllQueryableAsync(bool trackChanges = false)
    {
        return trackChanges
            ? _context.Set<T>()
            : _context.Set<T>().AsNoTracking();
    }
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}