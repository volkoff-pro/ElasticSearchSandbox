using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticData.Bootstrap;
using ElasticData.Documents;
using Nest;

namespace ElasticApp
{
    class Program
    {
        static IEnumerable<Func<QueryContainerDescriptor<Contact>, QueryContainer>> GetDataRangeQuery(string[] dates) =>
            dates == null
                ? Array.Empty<Func<QueryContainerDescriptor<Contact>, QueryContainer>>()
                : dates.Select<string, Func<QueryContainerDescriptor<Contact>, QueryContainer>>(
                    value =>
                    {
                        if (value == "DateOne")
                        {
                            return m => m.DateRange(
                                t => t.Field(
                                    f => f.Individual.AnotherDate
                                ).Format("MM/dd/yyyy")
                                .GreaterThanOrEquals("01/01/1940")
                                .LessThanOrEquals("01/01/1960")
                            );
                        }

                        if (value == "DateTwo")
                        {
                            return m => m.DateRange(
                                t => t.Field(
                                    f => f.Individual.AnotherDate
                                ).Format("MM/dd/yyyy")
                                .GreaterThanOrEquals("02/02/1991")
                                .LessThanOrEquals("02/02/1991")
                            );
                        }

                        return null;
                    }
                );

        static async Task Main(string[] _)
        {
            const string ContactsIndexName = "contacts";

            Console.WriteLine("Creating ElasticSearch indexes\n");

            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex(ContactsIndexName);
            var client = new ElasticClient(settings);

            // client.CreateIndex<Contact>(ContactsIndexName);

            // foreach (var contact in Documents.GetContacts())
            // {
            //     await client.IndexDocumentAsync(contact);
            // }

            // Console.WriteLine("\nIndexing finished...\n");

            Console.WriteLine("Searching...\n");

            var searchRequest = await client.SearchAsync<Contact>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Should(GetDataRangeQuery(new string[] { "DateOne", "DateTwo" }))
                    )
                )
            );

            var searchResponceObjectDocs = searchRequest.Documents;

            foreach (var searchResponceObjectDoc in searchResponceObjectDocs)
            {
                Console.WriteLine($"{searchResponceObjectDoc.FirstName} {searchResponceObjectDoc.LastName} = {searchResponceObjectDoc.BirthDate}");
            }

            Console.ReadKey();
        }
    }
}
