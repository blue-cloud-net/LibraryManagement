using System.Linq.Expressions;

using AutoMapper;

using FantasySky.Core.Operation;

using LibraryManagement.Manage.Abstractions.DalServices;
using LibraryManagement.Manage.Abstractions.Models;
using LibraryManagement.Manage.Dal.Entity;
using LibraryManagement.Manage.Dal.Stores;

namespace LibraryManagement.Manage.Dal.Services;

public class DalBookService : IDalBookService
{
    private readonly IMapper _mapper;
    private readonly BookStore _bookStore;

    public DalBookService(
        IMapper mapper,
        BookStore bookStore)
    {
        _mapper = mapper;
        _bookStore = bookStore;
    }

    public Task<OperationalResult> AddAsync(Operational operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OperationalResult> DeleteAsync(Operational<string> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<OperationalResult<BookModel>> GetAsync(Operational<BookQueryModel> operational, CancellationToken cancellationToken = default)
    {
        var queryModel = operational.Parameter;

        Expression<Func<Book, bool>> expression = p => p.No == queryModel.BookNo;

        var entity = await _bookStore.FindAsync(expression, cancellationToken);

        if (entity is null)
        {
            return OperationalResult<BookModel>.Failed("");
        }

        var model = _mapper.Map<Book, BookModel>(entity);

        return OperationalResult<BookModel>.Ok(model);
    }

    public Task<PageOperationalResult<BookModel>> GetPageAsync(PageOperational<BookQueryModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OperationalResult> UpdateAsync(Operational<BookModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
