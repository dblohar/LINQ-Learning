using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LINQ_Learning
{
    internal class QuantifierOperations
    {
        public static void Example1_All()
        {
            //Determines whether all elements of a sequence satisfy a condition.

            int[] numbers = { 1, 2, 3, 4, 5, -1 };

            var IsAllNumbersAreGreatherThanZero = numbers.All(n => n > 0);
            Console.WriteLine($"All numbers are greather than zero :{IsAllNumbersAreGreatherThanZero}");

            Console.WriteLine($"Any number is less than zero : {numbers.Any(n => n < 0)}");

            Console.WriteLine($"Is number contains 0 : {numbers.Contains(-1)}");
        }

        public static void Example2_All()
        {
            Pet[] pets = { new Pet { Name="Barley", Age=10 },
new Pet { Name="Boots", Age=4 },
new Pet { Name="Whiskers", Age=6 } };

            // Determine whether all pet names
            // in the array start with 'B'.

            var isAllPetsStartWithB = pets.All(p => p.Name.StartsWith('B'));

            Console.WriteLine($"Is all pets name start with 'B' : {isAllPetsStartWithB}");
        }

        public static void Example3_All()
        {
            List<Person> people = new List<Person>
            {
                new Person
                {
                    LastName = "Haas",
                    Pets =  new Pet[]
                    {
                        new Pet { Name="Barley", Age=10 },
                        new Pet { Name="Boots", Age=14 },
                        new Pet { Name="Whiskers", Age=6 }
                    }
                },
                new Person
                {
                    LastName = "Fakhouri",
                    Pets =  new Pet[]
                    {
                        new Pet { Name = "Snowball", Age = 1}
                    }
                },
                new Person
                {
                    LastName = "Antebi",
                    Pets = new Pet[]
                    {
                        new Pet { Name = "Belle", Age = 8}
                    }
                },
                new Person
                {
                    LastName = "Philips",
                    Pets = new Pet[]
                    {
                        new Pet { Name = "Sweetie", Age = 2},
                        new Pet { Name = "Rover", Age = 13}
                    }
                }
            };

            // Determine which people have pets that are all older than 5.

            var names = from person in people
                        where person.Pets.All(pet => pet.Age > 5)
                        select person.LastName;

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static void Example4_Any()
        {
            //The following code example demonstrates how to use Any to determine whether a sequence contains any elements.
            int[] numbers1 = { 1, 2, 4, 5, 0 };
            int[] numbers2 = { };
            var isNumber1HasElements = numbers1.Any();
            Console.WriteLine($"Is Number1 has elements : {isNumber1HasElements}");

            var isNumber2HasElements = numbers2.Any();
            Console.WriteLine($"Is Number2 has elements : {isNumber2HasElements}");
        }

        private class Person
        {
            public string LastName { get; set; }
            public Pet[] Pets { get; set; }
        }

        private class Pet
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }

        public static void Example5_Contains()
        {
            List<Pet> pets = new List<Pet>() {
                new Pet(){Name="TOM",Age=14 },
                new Pet(){ Name="Jerry",Age=12}
            };

            Pet tom = new Pet() { Name = "TOM", Age = 14 };
            Pet doggy = new Pet() { Name = "jack", Age = 15 };

            PetComparator petComparator = new PetComparator();
            Console.WriteLine($"Is Pet List Contain TOM : {pets.Contains(tom, petComparator)}");
            Console.WriteLine($"Is Pet List Contain Jack : {pets.Contains(doggy, petComparator)}");
        }

        private class PetComparator : EqualityComparer<Pet>
        {
            public override bool Equals([AllowNull] Pet x, [AllowNull] Pet y)
            {
                //Check whether the compared objects reference the same data.
                if (ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null.
                if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

                //Check whether the pets' properties are equal.
                return x.Name == y.Name && x.Age == y.Age;
            }

            // If Equals() returns true for a pair of objects
            // then GetHashCode() must return the same value for these objects.
            public override int GetHashCode([DisallowNull] Pet obj)
            {
                //Check whether the object is null
                if (ReferenceEquals(obj, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashCodeOfName = obj.Name == null ? 0 : obj.Name.GetHashCode();

                //Get hash code for the Age field.
                int hashCodeOfAge = obj.Age;

                //Calculate the hash code for the pet.
                return hashCodeOfName ^ hashCodeOfAge;
            }
        }
    }
}