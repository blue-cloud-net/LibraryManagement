using System.Linq.Expressions;

using AutoMapper;

using FantasySky.Core.Persistence;
using FantasySky.Core.Tools;
using FantasySky.MongoDbCore.Models;

using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FantasySky.MongoDbCore.Stores;

public abstract class BaseStore<T> : IStore<T> where T : BaseEntity
{
    private readonly MongoDbContext _dbContext;
    private readonly IMapper _mapper;

    // 解决并发的信号量锁
    private readonly SemaphoreSlim _semaphore = new(1);

    public BaseStore(MongoDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public async Task<bool> SaveAsync(T entity, CancellationToken cancellationToken = default)
    {
        var set = _dbContext.Set<T>();

        entity.No ??= SC.GetGuid();

        var filter = this.GetFilter(entity);

        var result = await set.ReplaceOneAsync(filter, entity, new ReplaceOptions() { IsUpsert = true }, cancellationToken);

        return result.MatchedCount + result.ModifiedCount > 0;
    }

    public async Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        var set = _dbContext.Set<T>();

        await set.InsertOneAsync(entity, null, cancellationToken);

        return true;
    }

    public async Task<bool> AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        var set = _dbContext.Set<T>();

        await set.InsertManyAsync(entities, cancellationToken: cancellationToken);

        return true;
    }

    public async Task<bool> UpdateAsync(Expression<Func<T, bool>> expression, T entity, CancellationToken cancellationToken = default)
    {
        var set = _dbContext.Set<T>();

        var filter = this.GetFilter(expression);

        var result = await set.ReplaceOneAsync(filter, entity, new ReplaceOptions() { IsUpsert = false }, cancellationToken);

        return result.MatchedCount + result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        var set = _dbContext.Set<T>();

        var filter = this.GetFilter(expression);

        var result = await set.DeleteOneAsync(filter, cancellationToken);

        return result.DeletedCount > 0;
    }

    public async Task<long> DeleteManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        var set = _dbContext.Set<T>();

        var filter = this.GetFilter(expression);

        var result = await set.DeleteManyAsync(filter, cancellationToken);

        return result.DeletedCount;
    }

    public Task<long> CountAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        var set = _dbContext.Set<T>();

        var filter = this.GetFilter(expression);

        return set.CountDocumentsAsync(filter, cancellationToken: cancellationToken);
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        var set = _dbContext.Set<T>();

        var filter = this.GetFilter(expression);

        var data = await set.FindAsync(filter, cancellationToken: cancellationToken);

        return await data.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> expression, IOrderBy<T>? orderBy = null, IPaging? paging = null, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.AsQueryable<T>();

        query = query.Where(expression);

        if (orderBy is not null)
        {
            foreach (var descriptor in orderBy)
            {
                if (descriptor.SortDirection is Core.Persistence.SortDirection.Ascending)
                {
                    query = query.OrderBy(descriptor.OrderByExpression);
                }
                else
                {
                    query = query.OrderByDescending(descriptor.OrderByExpression);
                }
            }

            query = query.Where(expression);
        }

        if (paging is not null)
        {
            query = query.Skip(paging.Skip).Take(paging.Take);
        }

        var data = await query.ToListAsync(cancellationToken);

        return data;
    }

    protected FilterDefinition<T> GetFilter(Expression<Func<T, bool>> expression) => Builders<T>.Filter.Where(expression);
    protected FilterDefinition<T> GetFilter(T entity) => this.GetFilter(entity.No);
    protected FilterDefinition<T> GetFilter(string no) => Builders<T>.Filter.Where(x => x.No == no);
}
