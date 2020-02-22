using System;
using System.Collections.Generic;
using Elastic.Data.Documents;

namespace Elastic.Data.Bootstrap
{
    public class SimpleDocuments
    {
        public static IEnumerable<ContactSimple> GetContactsSimple()
        {
            return new List<ContactSimple>
            {
                new ContactSimple
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Alex",
                    LastName = "Alexandrov",
                    Email = "a.alex@aol.com"
                },
                new ContactSimple
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Email = "ivan.ivanov@gmail.com"
                },
                new ContactSimple
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Petr",
                    LastName = "Petrov",
                    Email = "petr.petrov@mail.ru"
                },
                new ContactSimple
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Zoe",
                    LastName = "Zonder",
                    Email = "z.zonder@yahoo.com"
                }
            };
        }
    }
}