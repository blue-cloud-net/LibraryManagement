using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FantasySky.Core.Operation;

using LibraryManagement.Authentication.Abstractions.Models;

namespace LibraryManagement.Authentication.Abstractions.Services;

public interface IUserService
{
    Task<OperationalResult> CreateAsync(Operational<UserModel> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult> ModifyPassWorkAsync(Operational<UserModel> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult> DeleteAsync(Operational<UserModel> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult<UserModel>> GetAsync(Operational<UserQueryModel> operational, CancellationToken cancellationToken = default);
    Task<PageOperationalResult<UserModel>> GetPageAsync(PageOperational<UserQueryModel> operational, CancellationToken cancellationToken = default);
}
