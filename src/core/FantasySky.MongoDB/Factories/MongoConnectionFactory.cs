using System.Collections.Concurrent;

using FantasySky.MongoDbCore.Options;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FantasySky.MongoDbCore.Factories;

public class MongoConnectionFactory
    {
        private readonly ConcurrentDictionary<IOptions<MongoOptions>, MongoConnection> _connections;
        private readonly ILogger<MongoConnection> _logger;

        public MongoConnectionFactory(
            ILogger<MongoConnection> logger)
        {
            _connections = new();
            _logger = logger;
        }

        public MongoConnection CreateConnection(IOptions<MongoOptions> options)
            => _connections.GetOrAdd(options, new MongoConnection(_logger, options));
    }

