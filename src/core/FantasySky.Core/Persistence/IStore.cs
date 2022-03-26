using System.Linq.Expressions;

namespace FantasySky.Core.Persistence;
public interface IStore<T> where T : IEntity
{
    Task<bool> SaveAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Expression<Func<T, bool>> expression, T entity, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<long> DeleteManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<long> CountAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T?> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> expression, IOrderBy<T>? orderBy = default, IPaging? paging = default, CancellationToken cancellationToken = default);
}