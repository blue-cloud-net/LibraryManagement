using AutoMapper;

using FantasySky.MongoDbCore;
using FantasySky.MongoDbCore.Stores;

using LibraryManagement.Manage.Dal.Entity;

namespace LibraryManagement.Manage.Dal.Stores;

public class BookStore : BaseStore<Book>
{
    public BookStore(
        MongoDbContext dbContext,
        IMapper mapper) : base(dbContext, mapper)
    {

    }
}
