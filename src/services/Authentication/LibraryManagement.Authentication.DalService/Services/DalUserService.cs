using System.Linq.Expressions;

using AutoMapper;

using FantasySky.Core.Operation;

using LibraryManagement.Authentication.Abstractions.DalServices;
using LibraryManagement.Authentication.Abstractions.Models;
using LibraryManagement.Authentication.DalService.Entity;
using LibraryManagement.Authentication.DalService.Store;

namespace LibraryManagement.Authentication.DalService.Services;

public class DalUserService : IDalUserService
{
    private readonly IMapper _mapper;
    private readonly UserStore _userStore;

    public DalUserService(
        IMapper mapper,
        UserStore userStore)
    {
        _mapper = mapper;
        _userStore = userStore;
    }

    public async Task<OperationalResult> AddAsync(Operational<UserModel> operational, CancellationToken cancellationToken = default)
    {
        var model = operational.Parameter;

        var entity = _mapper.Map<UserModel, User>(model);

        var result = await _userStore.AddAsync(entity, cancellationToken);

        return result ? OperationalResult.Ok() : OperationalResult.Failed("");
    }

    public async Task<OperationalResult> DeleteAsync(Operational<string> operational, CancellationToken cancellationToken = default)
    {
        var UserNo = operational.Parameter;

        Expression<Func<User, bool>> expression = p => p.No == UserNo;

        var result = await _userStore.DeleteAsync(expression, cancellationToken);

        return result ? OperationalResult.Ok() : OperationalResult.Failed("");
    }

    public async Task<OperationalResult<UserModel>> GetAsync(Operational<UserQueryModel> operational, CancellationToken cancellationToken = default)
    {
        var queryModel = operational.Parameter;

        Expression<Func<User, bool>> expression = p => p.No == queryModel.UserNo;

        var entity = await _userStore.FindAsync(expression, cancellationToken);

        if (entity is null)
        {
            return OperationalResult<UserModel>.Failed("");
        }

        var model = _mapper.Map<User, UserModel>(entity);

        return OperationalResult<UserModel>.Ok(model);
    }

    public Task<PageOperationalResult<UserModel>> GetPageAsync(PageOperational<UserQueryModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<OperationalResult<bool>> IsExist(Operational<UserQueryModel> operational, CancellationToken cancellationToken = default)
    {
        var queryModel = operational.Parameter;

        Expression<Func<User, bool>> expression = p => p.No == queryModel.UserNo;

        var count = await _userStore.CountAsync(expression, cancellationToken);

        return OperationalResult<bool>.Ok(count > 0);
    }

    public Task<OperationalResult> UpdateAsync(Operational<UserModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
