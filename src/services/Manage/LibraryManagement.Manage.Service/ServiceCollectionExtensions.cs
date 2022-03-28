using LibraryManagement.Manage.Abstractions.Services;

using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Manage.Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}
