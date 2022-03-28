using FantasySky.Core.Operation;

using LibraryManagement.Manage.Abstractions.Models;

namespace LibraryManagement.Manage.Abstractions.DalServices;

public interface IDalBookService
{
    Task<OperationalResult> AddAsync(Operational operational, CancellationToken cancellationToken = default);
    Task<OperationalResult> UpdateAsync(Operational<BookModel> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult> DeleteAsync(Operational<string> operational, CancellationToken cancellationToken = default);
    Task<OperationalResult<BookModel>> GetAsync(Operational<BookQueryModel> operational, CancellationToken cancellationToken = default);
    Task<PageOperationalResult<BookModel>> GetPageAsync(PageOperational<BookQueryModel> operational, CancellationToken cancellationToken = default);
}
