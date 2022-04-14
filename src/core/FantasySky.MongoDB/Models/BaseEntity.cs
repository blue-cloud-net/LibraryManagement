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
    public string Creater { get; set; } = String.Empty;

    [BsonRequired]
    public DateTime ModifyTime { get; set; }

    public string Modifier { get; set; } = String.Empty;

    public bool IsDeleted { get; set; }

    public DateTime? DeleteTime { get; set; }

    public string? Deleter { get; set; }
}
