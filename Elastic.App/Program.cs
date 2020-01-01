using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Elastic.Data;
using Elastic.Data.Bootstrap;
using Elastic.Data.Documents;
using Nest;

namespace Elastic.App
{
    internal static class Program
    {
        private static IEnumerable<Func<QueryContainerDescriptor<Contact>, QueryContainer>> GetDataRangeQuery(string[] dates) =>
            dates == null
                ? Array.Empty<Func<QueryContainerDescriptor<Contact>, QueryContainer>>()
                : dates.Select<string, Func<QueryContainerDescriptor<Contact>, QueryContainer>>(
                    value =>
                    {
                        switch (value)
                        {
                            case "DateOne":
                                return m => m.DateRange(
                                    t => t.Field(
                                            f => f.Individual.BirthDate
                                        ).Format("MM/dd/yyyy")
                                        .GreaterThanOrEquals("01/01/1940")
                                        .LessThanOrEquals("01/01/1960")
                                );
                            case "DateTwo":
                                return m => m.DateRange(
                                    t => t.Field(
                                            f => f.Individual.BirthDate
                                        ).Format("MM/dd/yyyy")
                                        .GreaterThanOrEquals("02/02/1991")
                                        .LessThanOrEquals("02/02/1991")
                                );
                            default:
                                return null;
                        }
                    }
                );

        public static async Task Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetRequiredService<Host>().Run();
            
            // const string contactsIndexName = "contacts";
            //
            // Console.WriteLine("Creating ElasticSearch indexes\n");
            //
            // var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            // var client = new ElasticClient(settings);
            // client.CreateDocumentDefaultIndex<Contact>(contactsIndexName);
            //
            // if (await client.GetDocumentsCount<Contact>() == 0)
            // {
            //     var documents = Documents.GetContacts();
            //
            //     var bulkIndexResponse = await client.BulkAsync(b => b
            //         .Index(contactsIndexName)
            //         .IndexMany(documents)
            //     );
            // }
            //
            // Console.WriteLine("Searching...\n");
            //
            // var searchRequest = await client.SearchAsync<Contact>(s => s
            //     .Query(q => q
            //         .Bool(b => b
            //             .Should(GetDataRangeQuery(new[] {"DateOne", "DateTwo"}))
            //         )
            //     )
            // );
            //
            // var searchResponseObjectDocs = searchRequest.Documents;
            //
            // foreach (var searchResponseObjectDoc in searchResponseObjectDocs)
            // {
            //     Console.WriteLine(
            //         $"{searchResponseObjectDoc.FirstName} {searchResponseObjectDoc.LastName} = {searchResponseObjectDoc.CreationDate}");
            // }

            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<ElasticOptions>(configuration.GetSection("Elastic"));

            serviceCollection.AddTransient<Host>();
        }
    }
}