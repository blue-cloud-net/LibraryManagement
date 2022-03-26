using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasySky.MongoDbCore;

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

