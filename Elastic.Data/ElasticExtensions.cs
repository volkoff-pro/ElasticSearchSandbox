using System.Threading.Tasks;
using Elastic.Data.Documents;
using Nest;

namespace Elastic.Data
{
    public static class ElasticExtensions
    {
        public static async Task<long> GetDocumentsCount<T>(this IElasticClient client) where T : ElasticDocument 
            => (await client.CountAsync<T>()).Count;
    }
}