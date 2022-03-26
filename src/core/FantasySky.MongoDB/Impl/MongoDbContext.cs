
using FantasySky.MongoDbCore.Factory;
using FantasySky.MongoDbCore.Options;

using Microsoft.Extensions.Options;

using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FantasySky.MongoDbCore;

public class MongoDbContext
{
    private readonly MongoConnection _connection;

    public MongoDbContext(MongoConnectionFactory mongoDBFactory, IOptions<MongoOptions> options)
    {
        options.Value.ConnectionString ??= "mongodb://localhost:27017/FantasySky";

        _connection = mongoDBFactory.CreateConnection(options);
    }

    public IMongoDatabase Database => _connection.Database;

    public IMongoCollection<TDocument> Set<TDocument>(string? collectName = null)
    {
        return _connection.Database.GetCollection<TDocument>(collectName ?? typeof(TDocument).Name);
    }

    public IMongoQueryable<TDocument> AsQueryable<TDocument>(string? collectName = null)
    {
        return this.Set<TDocument>(collectName).AsQueryable();
    }
}
