using AutoMapper;

using FantasySky.AspNetCore.Extensions;
using FantasySky.Core.Operation;

using LibraryManagement.Manage.Abstractions.Models;
using LibraryManagement.Manage.Abstractions.Services;
using LibraryManagement.Manage.Controller.ViewModel;

using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Manage.Controller.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BookController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IBookService _bookService;

    public BookController(
        IMapper mapper,
        IBookService bookService)
    {
        _mapper = mapper;
        _bookService = bookService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<OperationalResult<BookViewModel>> GetAsync(string id)
    {
        var operational = this.HttpContext.CreateOperational<BookQueryModel>(new()
        {
            BookNo = id
        });

        var result = await _bookService.GetAsync(operational, this.HttpContext.RequestAborted);

        if (result.IsSuccess)
        {
            var viewModel = _mapper.Map<BookModel, BookViewModel>(result.Data);

            return OperationalResult<BookViewModel>.Ok(viewModel);
        }

        return OperationalResult<BookViewModel>.NotSuccessLoad(result);
    }
}
