using AutoMapper;

using FantasySky.MongoDbCore;
using FantasySky.MongoDbCore.Store;

using LibraryManagement.Manage.Dal.Entity;

namespace LibraryManagement.Manage.Dal.Store;

public class BookStore : BaseStore<Book>
{
    public BookStore(
        MongoDbContext dbContext,
        IMapper mapper) : base(dbContext, mapper)
    {

    }
}
