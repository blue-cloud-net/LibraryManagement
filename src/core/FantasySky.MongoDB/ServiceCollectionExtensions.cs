using Microsoft.Extensions.DependencyInjection;

namespace FantasySky.MongoDbCore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDBContext(this IServiceCollection services)
    {
        services.AddSingleton<MongoConnectionFactory>();
        services.AddSingleton<MongoDbContext>();

        //Microsoft.Extensions.DependencyInjection.
        return services;
    }
}