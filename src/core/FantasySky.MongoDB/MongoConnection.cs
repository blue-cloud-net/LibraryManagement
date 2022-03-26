using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace FantasySky.MongoDbCore;

public class MongoConnection
{
    private readonly MongoClient _client;
    private readonly ILogger<MongoConnection> _logger;

    public MongoOptions Options { get; private set; }

    public IMongoDatabase Database { get; }

    public MongoConnection(ILogger<MongoConnection> logger, IOptions<MongoOptions> options)
    {
        this.Options = options.Value;
        _logger = logger;

        if (this.Options.LogCommand)
        {
            _setLogger.Invoke(this.Options, logger);
        }

        _client = new MongoClient(this.Options.Settings);

        this.Options.DataBaseName = String.IsNullOrWhiteSpace(this.Options.DataBaseName) ?
            MongoUrl.Create(this.Options.ConnectionString).DatabaseName : this.Options.DataBaseName;

        if (String.IsNullOrWhiteSpace(this.Options.DataBaseName))
        {
            throw new Exception("Please specify a database name, either via the connection string or via the DatabaseName setting.");
        }

        this.Database = _client.GetDatabase(this.Options.DataBaseName);
    }

    private readonly Action<MongoOptions, ILogger<MongoConnection>> _setLogger = (options, logger) =>
     {
         options.Settings.ClusterConfigurator = action =>
          {
              action.Subscribe<CommandStartedEvent>(e =>
              {
                  logger.LogDebug($"MongoCommand: {e.CommandName} - {e.Command.ToJson()}");
              });
          };
     };
}
