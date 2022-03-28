using FantasySky.Core.Operation;

using LibraryManagement.Manage.Abstractions.Models;

namespace LibraryManagement.Manage.Abstractions.Services;

public interface IBookService
{
    Task<OperationalResult> AddAsync(Operational<BookModel> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult> UpdateAsync(Operational<BookModel> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult> DeleteAsync(Operational<BookModel> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult<BookModel>> GetAsync(Operational<BookQueryModel> operational, CancellationToken cancellationToken = default);
    Task<PageOperationalResult<BookModel>> GetPageAsync(PageOperational<BookQueryModel> operational, CancellationToken cancellationToken = default);
}
