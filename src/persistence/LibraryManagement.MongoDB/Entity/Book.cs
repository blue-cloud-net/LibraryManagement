
using FantasySky.MongoDbCore.Model;

namespace LibraryManagement.MongoDB.Entity;

public class Book : AbstractEntity
{

    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;

    public bool IsDeleted { get; set; }
}
