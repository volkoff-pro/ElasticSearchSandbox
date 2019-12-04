using System;
using Nest;

namespace ElasticData.Documents
{
    public class ContactIndividual
    {
        [Date(Format = "MM/dd/yyyy")]
        public string AnotherDate { get; set;}
    }
}
