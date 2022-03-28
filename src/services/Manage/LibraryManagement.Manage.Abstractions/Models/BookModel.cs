using FantasySky.Core.Models;

namespace LibraryManagement.Manage.Abstractions.Models;

public class BookModel : IModel
{
    public string No { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}