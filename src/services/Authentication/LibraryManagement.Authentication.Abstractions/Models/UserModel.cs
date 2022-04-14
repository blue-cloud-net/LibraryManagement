using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Authentication.Abstractions.Models;

public class UserModel
{
    public string Name { get; set; } = String.Empty;

    public string DisplayName { get; set; } = String.Empty;

    public string PassWord { get; set; } = String.Empty;
}
