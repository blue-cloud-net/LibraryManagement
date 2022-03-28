using FantasySky.MongoDbCore.Models;

namespace LibraryManagement.Manage.Dal.Entity;

public class Category : BaseEntity
{
    public string CategoryNo { get; set; } = String.Empty;
    public string CategoryName { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}
