using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticData.Documents;
using Nest;

namespace ElasticApp
{
    static class Program
    {
        static IEnumerable<Func<QueryContainerDescriptor<Contact>, QueryContainer>> GetDataRangeQuery(string[] dates) =>
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
                                            f => f.Individual.AnotherDate
                                        ).Format("MM/dd/yyyy")
                                        .GreaterThanOrEquals("01/01/1940")
                                        .LessThanOrEquals("01/01/1960")
                                );
                            case "DateTwo":
                                return m => m.DateRange(
                                    t => t.Field(
                                            f => f.Individual.AnotherDate
                                        ).Format("MM/dd/yyyy")
                                        .GreaterThanOrEquals("02/02/1991")
                                        .LessThanOrEquals("02/02/1991")
                                );
                            default:
                                return null;
                        }
                    }
                );

        static async Task Main()
        {
            const string contactsIndexName = "contacts";

            Console.WriteLine("Creating ElasticSearch indexes\n");

            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex(contactsIndexName);
            var client = new ElasticClient(settings);
            
            Console.WriteLine("Searching...\n");

            var searchRequest = await client.SearchAsync<Contact>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Should(GetDataRangeQuery(new[] {"DateOne", "DateTwo"}))
                    )
                )
            );

            var searchResponseObjectDocs = searchRequest.Documents;

            foreach (var searchResponseObjectDoc in searchResponseObjectDocs)
            {
                Console.WriteLine(
                    $"{searchResponseObjectDoc.FirstName} {searchResponseObjectDoc.LastName} = {searchResponseObjectDoc.BirthDate}");
            }

            Console.ReadKey();
        }
    }
}