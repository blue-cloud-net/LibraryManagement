using AutoMapper;

using LibraryManagement.Manage.Abstractions.Models;
using LibraryManagement.Manage.Dal.Entity;

namespace LibraryManagement.Manage.Dal.Mapping;

public class EntityProfile : Profile
{
    public EntityProfile()
    {
        this.CreateMap<Book, BookModel>();
    }
}
