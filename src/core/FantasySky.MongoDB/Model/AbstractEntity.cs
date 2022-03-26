
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FantasySky.MongoDbCore.Model;

public abstract class AbstractEntity : IEntity
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonRequired]
    public DateTime CreatedTime { get; set; }
    [BsonRequired]
    public DateTime ModifyTime { get; set; }
}
