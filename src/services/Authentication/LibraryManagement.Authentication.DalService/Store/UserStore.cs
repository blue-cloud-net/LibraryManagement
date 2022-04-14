
using AutoMapper;

using FantasySky.MongoDbCore;
using FantasySky.MongoDbCore.Stores;

using LibraryManagement.Authentication.DalService.Entity;

namespace LibraryManagement.Authentication.DalService.Store;

public class UserStore : BaseStore<User>
{
    public UserStore(
        MongoDbContext context,
        IMapper mapper) : base(context, mapper)
    {
    }
}
