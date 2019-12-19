using System;
using System.Threading;
using System.Threading.Tasks;
using ElasticData.Documents;
using Elasticsearch.Net;
using Nest;

namespace ElasticData
{
    public static class ElasticIndexes
    {
        static void CreateIndex<T>(this IElasticClient client, string indexName) where T : ElasticDocument
        {
            var response = client.Indices.Create(indexName, create => create.Map<T>(map => map.AutoMap()));

            if (response.OriginalException != null && 
                (response.OriginalException is ElasticsearchClientException e && e.Message.Contains("already exists")))
                throw response.OriginalException;
            
            client.ConnectionSettings.DefaultIndices.Add(typeof(T), indexName);
        }

        public static IElasticClient CreateDocumentDefaultIndex<T>(this IElasticClient client, string indexName) where T : ElasticDocument
        {
            if (client.ConnectionSettings.DefaultIndices.TryGetValue(typeof(T), out _))
                return client;

            var isExists = client.Indices.Exists(indexName).Exists;

            if (isExists)
            {
                client.ConnectionSettings.DefaultIndices.Add(typeof(T), indexName);

                return client;
            }

            CreateIndex<T>(client, indexName);

            return client;
        }

        public static Task CreateDocumentDefaultIndex<T>(this IElasticClient client, string indexName,
            CancellationToken cancellationToken)
            where T : ElasticDocument 
            => client.CreateDocumentIndex<T>(indexName, create => create.Map<T>(map => map.AutoMap()), cancellationToken);

        public static async Task CreateDocumentIndex<T>(this IElasticClient client, string indexName,
            Func<CreateIndexDescriptor, ICreateIndexRequest> configure, CancellationToken cancellationToken)
            where T : ElasticDocument
        {
            var isExists = (await client.Indices.ExistsAsync(indexName, ct: cancellationToken)).Exists;

            if (isExists)
            {
                client.ConnectionSettings.DefaultIndices.Add(typeof(T), indexName);

                return;
            }

            var response = await client.Indices.CreateAsync(indexName, configure, cancellationToken);

            if (response.OriginalException != null && 
                (response.OriginalException is ElasticsearchClientException e && e.Message.Contains("already exists")))
                throw response.OriginalException;

            client.ConnectionSettings.DefaultIndices.Add(typeof(T), indexName);
        }

        public static void CreateDocumentIndex<T>(this IElasticClient client, string indexName, 
            Func<CreateIndexDescriptor, ICreateIndexRequest> configure) where T : ElasticDocument
        {
            var isExists = client.Indices.Exists(indexName).Exists;

            if (isExists)
            {
                client.ConnectionSettings.DefaultIndices.Add(typeof(T), indexName);

                return;
            }

            var response = client.Indices.Create(indexName, configure);

            if (response.OriginalException != null && 
                (response.OriginalException is ElasticsearchClientException e && e.Message.Contains("already exists")))
                throw response.OriginalException;

            client.ConnectionSettings.DefaultIndices.Add(typeof(T), indexName);
        }
    }
}
