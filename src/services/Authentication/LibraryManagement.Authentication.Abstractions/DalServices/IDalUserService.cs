using System;

using FantasySky.Core.Operation;

using LibraryManagement.Authentication.Abstractions.Models;

namespace LibraryManagement.Authentication.Abstractions.DalServices;

public interface IDalUserService
{
    Task<OperationalResult> AddAsync(Operational<UserModel> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult> UpdateAsync(Operational<UserModel> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult> DeleteAsync(Operational<string> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult<bool>> IsExist(Operational<UserQueryModel> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult<UserModel>> GetAsync(Operational<UserQueryModel> operational, CancellationToken cancellationToken = default);
    Task<PageOperationalResult<UserModel>> GetPageAsync(PageOperational<UserQueryModel> operational, CancellationToken cancellationToken = default);
}
