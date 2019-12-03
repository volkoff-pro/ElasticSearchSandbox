using System;
using System.Collections.Generic;
using ElasticData.Documents;

namespace ElasticData.Bootstrap
{
    public static class Documents
    {
        public static List<Contact> GetContacts()
        {
            return new List<Contact>
            {
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Alex",
                    LastName = "Fedorov",
                    BirthDate = "01/01/1990"
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    BirthDate = "02/02/1991"
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Petr",
                    LastName = "Petrov",
                    BirthDate = "02/03/1991"
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Semen",
                    LastName = "Semenov",
                    BirthDate = "02/03/1991"
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Ivan",
                    LastName = "Semenov",
                    BirthDate = "02/04/1989"
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Semen",
                    LastName = "Ivanov",
                    BirthDate = "02/05/1994"
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Maria",
                    LastName = "Petrenko",
                    BirthDate = "02/06/1990"
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Tatyana",
                    LastName = "Semenova",
                    BirthDate = "02/07/1981"
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Zinaida",
                    LastName = "Ivanova",
                    BirthDate = "02/08/1951"
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Alexander",
                    LastName = "Semenov",
                    BirthDate = "02/09/1943"
                }
            };
        }
    }
}
