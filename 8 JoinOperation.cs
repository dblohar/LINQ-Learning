using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LINQ_Learning
{
    internal class JoinOperation
    {
        public static void Example1_Join()
        {
            var people = new List<Person>() {
                new Person(){Name = "Deepak",Email="deepak@email.com" },
                  new Person(){Name = "Suraj",Email="suraj@email.com" },
                    new Person(){Name = "Omkar",Email="deepak@home.com" }
            };

            var SkypeIds = new List<SkypeId>() {
                new SkypeId(){ Email = "deepak@email.com",Id="D1023" },
                new SkypeId(){ Email = "deepak@email.com",Id="HomeSkype" },
                new SkypeId(){ Email = "suraj@email.com",Id="SL-Suraj" },
                new SkypeId(){ Email = "shivaji@email.com",Id="SJ_123" },
                new SkypeId(){ Email = "ram@email.com",Id="ram98" }
            };

            var query = people.Join(SkypeIds,
                x => x.Email,
                y => y.Email,
                (person, skpyid) => new { person.Name, skpyid.Id });

            people.Add(new Person() { Name = "Amar", Email = "amar@email.com" });
            SkypeIds.Add(new SkypeId() { Email = "amar@email.com", Id = "AMAR_007" });

            foreach (var obj in query)
            {
                Console.WriteLine("{0} - {1}", obj.Name, obj.Id);
            }
        }

        private class Person
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        private class SkypeId
        {
            public string Email { get; set; }
            public string Id { get; set; }
        }
    }
}