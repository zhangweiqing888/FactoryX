using System.Linq.Expressions;

namespace FactoryX.Infrastructure.Contracts;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool trackChanges = false);
    IQueryable<TEntity> GetAllQueryableAsync(bool trackChanges = false);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}