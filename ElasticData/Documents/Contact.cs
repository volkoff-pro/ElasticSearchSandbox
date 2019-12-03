using System;
using Nest;

namespace ElasticData.Documents
{
    public class Contact : ElasticDocument
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Date(Format = "MM/dd/yyyy")]
        public string BirthDate { get; set; }
    }
}
