using FantasySky.Core.Persistence;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FantasySky.MongoDbCore.Models;

public abstract class BaseEntity : IEntity
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonRequired]
    public string No { get; set; } = String.Empty;

    [BsonRequired]
    public DateTime CreatedTime { get; set; }
    [BsonRequired]
    public DateTime ModifyTime { get; set; }
}
