using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Learning
{
    internal class GroupingData
    {
        public static void Example1_GroupBy()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person() { Name = "Deepak", Age = 28 });
            people.Add(new Person() { Name = "Suraj", Age = 25 });
            people.Add(new Person() { Name = "Omkar", Age = 14 });
            people.Add(new Person() { Name = "Omkar", Age = 7 });
            people.Add(new Person() { Name = "Deepak", Age = 17 });
            people.Add(new Person() { Name = "Ashwini", Age = 26 });
            people.Add(new Person() { Name = "Ashwini", Age = 26 });
            people.Add(new Person() { Name = "Deepak", Age = 8 });

            var GroupByName = people.GroupBy(p => p.Name);

            IEnumerable<IGrouping<string, Person>> GroupByName2 = people.GroupBy(p => p.Name);

            IEnumerable<IGrouping<int, Person>> GroupByAge = people.GroupBy(p => p.Age);

            Console.WriteLine("Group By Name");
            foreach (var group in GroupByName)
            {
                Console.Write($"\n{group.Key} =>");
                foreach (var person in group)
                {
                    Console.Write($" [{person.Name} - {person.Age}]");
                }
            }

            Shared.Seperator();

            Console.WriteLine("\n\nGroup By Age");
            foreach (var group in GroupByAge)
            {
                Console.Write($"{group.Key}=>");
                foreach (var person in group)
                {
                    Console.Write($" [{person.Name} - {person.Age}]");
                }
                Console.WriteLine();
            }
        }

        public static void Example1_GroupBy_ConditionalGrouping()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person() { Name = "Deepak", Age = 28, Id = 1 });
            people.Add(new Person() { Name = "Suraj", Age = 25, Id = 2 });
            people.Add(new Person() { Name = "Omkar", Age = 14, Id = 3 });
            people.Add(new Person() { Name = "Omkar", Age = 7, Id = 4 });
            people.Add(new Person() { Name = "Deepak", Age = 17, Id = 5 });
            people.Add(new Person() { Name = "Ashwini", Age = 26, Id = 6 });
            people.Add(new Person() { Name = "Ashwini", Age = 26, Id = 7 });
            people.Add(new Person() { Name = "Deepak", Age = 8, Id = 8 });

            IEnumerable<IGrouping<int, Person>> conditionalGrouping = people.GroupBy(p => p.Age);

            Console.WriteLine("Group By Conditional Grouping");
            foreach (var group in conditionalGrouping)
            {
                Console.Write($"\nThese People are {group.Key} years old:");
                foreach (var person in group)
                {
                    Console.Write($" [{person.Name} - {person.Age}]");
                }
            }

            Shared.Seperator();

            // What if we want to select only few values from collection

            var selectOnlyName = people.GroupBy(p => p.Age, p => new { p.Id, p.Name });

            Console.WriteLine("Group By: Get only specified fields");
            foreach (var group in selectOnlyName)
            {
                Console.Write($"\n{group.Key} =>");
                foreach (var person in group)
                {
                    Console.Write($" [{person.Id}-{person.Name}]");
                }
            }

            Shared.Seperator();
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public int Id { get; set; }
        }
    }
}