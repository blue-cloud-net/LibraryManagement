using FantasySky.MongoDbCore.Models;

namespace LibraryManagement.Manage.Dal.Entity;

public class Book : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;

    public bool IsDeleted { get; set; }
}
