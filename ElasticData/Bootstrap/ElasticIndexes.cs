using System;
using ElasticData.Documents;
using Nest;

namespace ElasticApp.Bootstrap
{
    public static class ElasticIndexes
    {
        public static void CreateIndex<T>(this IElasticClient client) where T : ElasticDocument
        {
            
        }
    }
}
