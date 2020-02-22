namespace Elastic.Data.Documents
{
    public class ContactSimple : ElasticDocument
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}