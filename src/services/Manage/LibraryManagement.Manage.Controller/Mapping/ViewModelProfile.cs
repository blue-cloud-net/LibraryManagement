using AutoMapper;

using LibraryManagement.Manage.Abstractions.Models;
using LibraryManagement.Manage.Controller.ViewModel;

namespace LibraryManagement.Manage.Controller.Mapping;

public class ViewModelProfile : Profile
{
    public ViewModelProfile()
    {
        this.CreateMap<BookModel, BookViewModel>();
    }
}
