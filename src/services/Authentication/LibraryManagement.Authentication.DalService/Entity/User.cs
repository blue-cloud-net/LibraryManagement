
using FantasySky.MongoDbCore.Models;

namespace LibraryManagement.User.DalService.Entity;

public class User : BaseEntity
{
    public string Name { get; set; } = String.Empty;

    public string Password { get; set; } = String.Empty;
}
