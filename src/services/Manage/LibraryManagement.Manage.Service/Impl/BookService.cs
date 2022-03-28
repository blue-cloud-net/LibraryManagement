using FantasySky.Core.Operation;

using LibraryManagement.Manage.Abstractions.DalServices;
using LibraryManagement.Manage.Abstractions.Models;
using LibraryManagement.Manage.Abstractions.Services;

namespace LibraryManagement.Manage.Service;

public class BookService : IBookService
{
    private readonly IDalBookService _dalBookService;

    public BookService(
        IDalBookService dalBookService)
    {
        _dalBookService = dalBookService;
    }

    public Task<OperationalResult> AddAsync(
        Operational<BookModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OperationalResult> DeleteAsync(
        Operational<BookModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OperationalResult<BookModel>> GetAsync(
        Operational<BookQueryModel> operational, CancellationToken cancellationToken = default)
    {
        return _dalBookService.GetAsync(operational, cancellationToken);
    }

    public Task<PageOperationalResult<BookModel>> GetPageAsync(
        PageOperational<BookQueryModel> operational, CancellationToken cancellationToken = default)
    {
        return _dalBookService.GetPageAsync(operational, cancellationToken);
    }

    public Task<OperationalResult> UpdateAsync(
        Operational<BookModel> operational, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
