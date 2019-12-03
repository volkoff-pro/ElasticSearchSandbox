using System;
using ElasticData.Documents;
using Nest;

namespace ElasticApp
{
    public static class ElasticIndexes
    {
        public static void CreateIndex<T>(this IElasticClient client, string indexName) where T : ElasticDocument
        {
            var response = client.Indices.Create(indexName, create => create.Map<T>(map => map.AutoMap()));
        }
    }
}
