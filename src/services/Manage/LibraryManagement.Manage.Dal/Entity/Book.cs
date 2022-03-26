
using FantasySky.MongoDbCore.Model;

namespace LibraryManagement.Manage.Dal.Entity;

public class Book : BaseEntity
{
    public string BookNo { get; set; } = String.Empty;
    public string BookName { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;

    public bool IsDeleted { get; set; }
}
