using System;

using FantasySky.MongoDbCore;

using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

namespace LibraryManagement.UnitTest;

public class MongoConnectTest
{
    private readonly IServiceProvider _serviceProvider;

    public MongoConnectTest()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddMongoDBContext();
        services.AddLogging();

        _serviceProvider = services.BuildServiceProvider();
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var context = _serviceProvider.GetRequiredService<MongoDbContext>();

        var db = context.Database;

        Assert.IsNotNull(db);
    }
}