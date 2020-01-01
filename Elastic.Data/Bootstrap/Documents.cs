using System;
using System.Collections.Generic;
using Elastic.Data.Documents;

namespace Elastic.Data.Bootstrap
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
                    CreationDate = "01/01/1990",
                    Individual = new ContactIndividual
                    {
                        BirthDate = "01/01/1990"
                    },
                    CustomFields = new List<CustomField>
                    {
                        new CustomField
                        {
                            CustomFieldName = "CarMake",
                            CustomFieldValue = "Honda"
                        }
                    },
                    Dates = new List<string>
                    {
                        "01/01/2019",
                        "02/02/2019"
                    }
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    CreationDate = "02/02/1991",
                    Individual = new ContactIndividual
                    {
                        BirthDate = "02/02/1991"
                    }
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Petr",
                    LastName = "Petrov",
                    CreationDate = "02/03/1991",
                    Individual = new ContactIndividual
                    {
                        BirthDate = "02/03/1991"
                    }
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Semen",
                    LastName = "Semenov",
                    CreationDate = "02/03/1991",
                    Individual = new ContactIndividual
                    {
                        BirthDate = "02/03/1991"
                    }
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Ivan",
                    LastName = "Semenov",
                    CreationDate = "02/04/1989",
                    Individual = new ContactIndividual
                    {
                        BirthDate = "02/04/1989"
                    }
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Semen",
                    LastName = "Ivanov",
                    CreationDate = "02/05/1994",
                    Individual = new ContactIndividual
                    {
                        BirthDate = "02/05/1994"
                    }
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Maria",
                    LastName = "Petrenko",
                    CreationDate = "02/06/1990",
                    Individual = new ContactIndividual
                    {
                        BirthDate = "02/06/1990"
                    }
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Tatyana",
                    LastName = "Semenova",
                    CreationDate = "02/07/1981",
                    Individual = new ContactIndividual
                    {
                        BirthDate = "02/07/1981"
                    }
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Zinaida",
                    LastName = "Ivanova",
                    CreationDate = "02/08/1951",
                    Individual = new ContactIndividual
                    {
                        BirthDate = "02/08/1951"
                    }
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Alexander",
                    LastName = "Semenov",
                    CreationDate = "02/09/1943",
                    Individual = new ContactIndividual
                    {
                        BirthDate = "02/09/1943"
                    }
                }
            };
        }
    }
}
