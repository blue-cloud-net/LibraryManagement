using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FantasySky.MongoDbCore.Model;

public interface IEntity
{
    ObjectId Id { get; set; }
}