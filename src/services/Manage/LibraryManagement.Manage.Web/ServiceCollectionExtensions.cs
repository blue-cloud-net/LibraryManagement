using LibraryManagement.Manage.Controller;
using LibraryManagement.Manage.Dal;

namespace LibraryManagement.Manage.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddManagerService(this IServiceCollection services)
    {
        services.AddAutoMapper();

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddEntityMappingProfile();
            config.AddViewModelMappingProfile();

        });

        return services;
    }
}
