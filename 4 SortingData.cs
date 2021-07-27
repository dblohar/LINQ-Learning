using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Learning
{
    internal class SortingData
    {
        public static void Example1_OrderBy()
        {
            var rand = new Random();

            var randomValues = Enumerable.Range(1, 10).Select(_ => rand.Next(10) - 5).ToList();

            Console.WriteLine($"Numbers");
            foreach (var n in randomValues)
            {
                Console.Write($"{n}\t");
            }

            var ascendingOrder = randomValues.OrderBy(n => n);

            Console.WriteLine($"\n\nAscending Order");
            foreach (var n in ascendingOrder)
            {
                Console.Write($"{n}\t");
            }

            var descendingOrder = randomValues.OrderByDescending(n => n);

            Console.WriteLine($"\n\nDescending Order");
            foreach (var n in descendingOrder)
            {
                Console.Write($"{n}\t");
            }
        }

        public static void Example2_TheyBy()
        {
            var fruits = new[] { "grape", "passionfruit", "banana", "mango",
                      "orange", "raspberry", "apple", "blueberry" };

            Console.WriteLine("Available fruits");

            foreach (var fruit in fruits)
            {
                Console.WriteLine($"\t{fruit}");
            }

            Console.WriteLine("Order By Alphabetically and Length");

            var query = fruits.OrderBy(fruit => fruit.Length).ThenBy(fruit => fruit);
            foreach (var fruit in query)
            {
                Console.WriteLine($"\t{fruit}");
            }
        }

        public static void Example3_ThenBy_SortingByPersonNameAndAge()
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

            var query = people.OrderBy(p => p.Name).ThenBy(p => p.Age);

            IOrderedEnumerable<Person> query2 = people.OrderBy(p => p.Name).ThenBy(p => p.Age);

            Console.WriteLine("Sort by Name and Age");
            foreach (var person in query)
            {
                Console.WriteLine($"\t{person.Name}\t{person.Age}");
            }
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}