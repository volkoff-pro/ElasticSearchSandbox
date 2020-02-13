using System;
using Nest;

namespace Elastic.Data
{
    public class ElasticClientBuilder
    {
        private readonly ConnectionSettings _settings;

        private ElasticClientBuilder(string connectionString) => _settings = new ConnectionSettings(new Uri(connectionString));
        
        public static ElasticClientBuilder Create(string connectionString) => new ElasticClientBuilder(connectionString);

        public ElasticClientBuilder Configure(Action<ConnectionSettings> configure)
        {
            configure?.Invoke(_settings);
            return this;
        }

        public IElasticClient Build() => new ElasticClient(_settings);
    }
}