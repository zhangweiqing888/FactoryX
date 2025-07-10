using System.Linq.Expressions;

namespace FactoryX.Infrastructure.Contracts;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, bool trackChanges = false);
    IQueryable<T> GetAllQueryableAsync(bool trackChanges = false);
    void Create(T entity);
    void Update(T entity);
    void Remove(T entity);
}