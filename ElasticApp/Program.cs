using System;
using System.Threading.Tasks;
using ElasticData.Bootstrap;
using Nest;

namespace ElasticApp
{
    class Program
    {
        static async Task Main(string[] _)
        {
            Console.WriteLine("Creating ElasticSearch indexes");

            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("contacts");
            var client = new ElasticClient(settings);

            foreach (var contact in Documents.GetContacts())
            {
                await client.IndexDocumentAsync(contact);
            }
        }
    }
}
