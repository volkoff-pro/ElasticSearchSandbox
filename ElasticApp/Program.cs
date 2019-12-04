using System;
using System.Threading.Tasks;
using ElasticData.Bootstrap;
using ElasticData.Documents;
using Nest;

namespace ElasticApp
{
    class Program
    {
        static async Task Main(string[] _)
        {
            const string ContactsIndexName = "contacts";

            Console.WriteLine("Creating ElasticSearch indexes");

            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex(ContactsIndexName);
            var client = new ElasticClient(settings);

            // client.CreateIndex<Contact>(ContactsIndexName);

            // foreach (var contact in Documents.GetContacts())
            // {
            //     await client.IndexDocumentAsync(contact);
            // }

            // Console.WriteLine("Indexing finished");

            Console.WriteLine("Searching...\n");

            var searchResponse = await client.SearchAsync<Contact>(s => s
            .Query(
                q => q
                    .DateRange(
                        c => c
                            .Field(p => p.BirthDate)
                            .Format("MM/dd/yyyy")
                            .GreaterThanOrEquals("02/02/1991")
                            .LessThanOrEquals("02/03/1991")
                            .GreaterThanOrEquals("01/01/1940")
                            .LessThanOrEquals("01/01/1960")
                        )
                )
            );

            var contacts = searchResponse.Documents;

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName} - {contact.BirthDate}");
            }

            Console.WriteLine("\nFiltering...\n");

            var filterResponse = await client.SearchAsync<Contact>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Filter(bf => bf
                            .DateRange(r => r
                                .Field(f => f.BirthDate)
                                .Format("MM/dd/yyyy")
                                .GreaterThanOrEquals("02/02/1991")
                                .LessThanOrEquals("02/03/1991")
                                ))))
            );

            var filteredContacts = filterResponse.Documents;

            foreach (var filtered in filteredContacts)
            {
                Console.WriteLine($"{filtered.FirstName} {filtered.LastName} = {filtered.BirthDate}");
            }

            Console.WriteLine("\nTwo ranges filtering...\n");

            var filteredWithToRanges = await client.SearchAsync<Contact>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Filter(bf => bf
                            .Bool(bfs => bfs
                                .Should(sh => sh
                                    .DateRange(dr => dr
                                        .Field(f => f.BirthDate)
                                        .Format("MM/dd/yyyy")
                                        .GreaterThanOrEquals("01/01/1940")
                                        .LessThanOrEquals("01/01/1960")
                                    ), sh => sh                                  
                                    .DateRange(dr => dr
                                        .Field(f => f.BirthDate)
                                        .Format("MM/dd/yyyy")
                                        .GreaterThanOrEquals("02/02/1991")
                                        .LessThanOrEquals("02/03/1991")
                                    )
                                )
                            )
                        )
                    )
                )
            );

            var filteredWithTwoRangesContacts = filteredWithToRanges.Documents;

            foreach (var filteredTwoRanges in filteredContacts)
            {
                Console.WriteLine($"{filteredTwoRanges.FirstName} {filteredTwoRanges.LastName} = {filteredTwoRanges.BirthDate}");
            }

            Console.WriteLine("\nObject syntax filtering...\n");

            var dateRangeQuery = new DateRangeQuery
            {
                Field = "birthDate",
                Format = "MM/dd/yyyy",
                GreaterThanOrEqualTo = "01/01/1940",
                LessThanOrEqualTo = "01/01/1960"
            };

            var dateRangeQuery2 = new DateRangeQuery
            {
                Field = "birthDate",
                Format = "MM/dd/yyyy",
                GreaterThanOrEqualTo = "02/02/1991",
                LessThanOrEqualTo = "02/03/1991"
            };

            var queryContainer = new QueryContainer[] { dateRangeQuery, dateRangeQuery2 };

            var searchRequestObject = new SearchRequest<Contact>
            {
                Query = new BoolQuery
                {
                    Should = queryContainer
                }
            };

            var searchResponseWithObject = await client.SearchAsync<Contact>(searchRequestObject);

            var searchResponceObjectDocs = searchResponseWithObject.Documents;

            foreach (var searchResponceObjectDoc in searchResponceObjectDocs)
            {
                Console.WriteLine($"{searchResponceObjectDoc.FirstName} {searchResponceObjectDoc.LastName} = {searchResponceObjectDoc.BirthDate}");
            }

            Console.ReadKey();
        }
    }
}
