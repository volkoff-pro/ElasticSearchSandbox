using Nest;

namespace Elastic.Data.Documents
{
    public class ContactIndividual
    {
        [Date(Format = "MM/dd/yyyy")]
        public string BirthDate { get; set;}
    }

    public class CustomField
    {
        public string CustomFieldName { get; set; }
        public string CustomFieldValue { get; set; }
    }
}
