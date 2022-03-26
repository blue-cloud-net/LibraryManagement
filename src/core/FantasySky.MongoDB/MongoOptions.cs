using Microsoft.Extensions.Configuration;

using MongoDB.Driver;

namespace FantasySky.MongoDbCore;

public class MongoOptions
{
    public MongoOptions()
    {
        this.Settings = new MongoClientSettings();
    }

    public MongoClientSettings Settings { get; private set; }

    public string? ConnectionString { get; set; } 
    public string? DataBaseName { get; set; }
    public bool LogCommand { get; set; }

    public void ConfigureMongoDB(IConfiguration configuration)
    {
        Settings.LinqProvider =  MongoDB.Driver.Linq.LinqProvider.V3;
    }
}
