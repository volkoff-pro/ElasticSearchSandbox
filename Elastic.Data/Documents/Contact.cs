using System.Collections.Generic;
using Nest;

namespace Elastic.Data.Documents
{
    public class Contact : ElasticDocument
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Date(Format = "MM/dd/yyyy")]
        public string CreationDate { get; set; }
        public ContactIndividual Individual { get; set; }
        public List<CustomField> CustomFields { get; set; }
        [Date(Format = "MM/dd/yyyy")]
        public List<string> Dates { get; set; }
    }
}
