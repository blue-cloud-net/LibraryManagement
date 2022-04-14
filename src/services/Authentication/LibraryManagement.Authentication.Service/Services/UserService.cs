using FantasySky.Core.Operation;

using LibraryManagement.Authentication.Abstractions.DalServices;
using LibraryManagement.Authentication.Abstractions.Models;
using LibraryManagement.Authentication.Abstractions.Services;

namespace LibraryManagement.Authentication.Service.Services;

public class UserService : IUserService
{
    private readonly IDalUserService _dalUserService;

    public UserService(
        IDalUserService dalUserService)
    {
        _dalUserService = dalUserService;
    }

    public Task<OperationalResult> CreateAsync(Operational<UserModel> operational, CancellationToken cancellationToken = default)
    {
        var model = operational.Parameter;

        var password = model.PassWord;

        return _dalUserService.AddAsync(operational, cancellationToken);
    }

    public Task<OperationalResult> DeleteAsync(Operational<UserModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OperationalResult<UserModel>> GetAsync(Operational<UserQueryModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PageOperationalResult<UserModel>> GetPageAsync(PageOperational<UserQueryModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OperationalResult> ModifyPassWorkAsync(Operational<UserModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
