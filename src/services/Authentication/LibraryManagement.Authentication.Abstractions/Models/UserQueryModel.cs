
using FantasySky.Core.Models;

namespace LibraryManagement.Authentication.Abstractions.Models;

public class UserQueryModel : IQueryModel
{
    public string UserNo { get; set; } = String.Empty;
    public string UserName { get; set; } = String.Empty;
}
