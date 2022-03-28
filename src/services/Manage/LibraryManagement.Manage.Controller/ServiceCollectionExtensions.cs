using AutoMapper;

using LibraryManagement.Manage.Controller.Mapping;

namespace LibraryManagement.Manage.Controller;

public static class ServiceCollectionExtensions
{
    public static void AddViewModelMappingProfile(this IMapperConfigurationExpression config)
    {
        config.AddProfile<ViewModelProfile>();
    }
}
