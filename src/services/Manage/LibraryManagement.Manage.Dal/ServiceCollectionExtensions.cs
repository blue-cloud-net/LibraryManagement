using AutoMapper;

using LibraryManagement.Manage.Dal.Mapping;

namespace LibraryManagement.Manage.Dal;

public static class ServiceCollectionExtensions
{
    public static void AddEntityMappingProfile(this IMapperConfigurationExpression config)
    {
        config.AddProfile<EntityProfile>();
    }
}
