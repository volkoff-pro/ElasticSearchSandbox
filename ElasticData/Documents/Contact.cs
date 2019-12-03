using System;

namespace ElasticData.Documents
{
    public class Contact : ElasticDocument
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
    }
}
