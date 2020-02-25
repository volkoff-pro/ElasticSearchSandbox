using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;

namespace Elastic.App
{
    public class Host
    {
        private readonly IElasticClient _elasticClient;
        
        public Host(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task Run()
        {
            var response = await _elasticClient.Cluster.HealthAsync(new ClusterHealthRequest
            {
                WaitForStatus = WaitForStatus.Red
            });

            if (response.IsValid)
            {
                Console.WriteLine(response.Status.ToString());
            }
        }
    }
}