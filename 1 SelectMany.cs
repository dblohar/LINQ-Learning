using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Learning
{
    /*
     Projects each element of a sequence to an IEnumerable<T> and flattens the resulting sequences into one sequence.

     This method is implemented by using deferred execution.
     */

    internal class _1_SelectMany
    {
        public static void Example1()
        {
            PetOwner[] petOwners = {
                new PetOwner {
                    Name="Higa",
                    Pets = new List<string>{ "Scruffy", "Sam" }
                },
                new PetOwner {
                    Name="Ashkenazi",
                    Pets = new List<string>{ "Walker", "Sugar" }
                },
                new PetOwner {
                    Name="Price",
                    Pets = new List<string>{ "Scratches", "Diesel" }
                },
                new PetOwner {
                    Name="Hines",
                    Pets = new List<string>{ "Dusty" }
                }
            };

            // Project the pet owner's name and the pet's name.

            var query = petOwners.SelectMany
            (
                petOwner => petOwner.Pets,
                    (petOwner, petName) => new { petOwner, petName })
                        //.Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
                        .Select(ownerAndPet =>
                            new
                            {
                                Owner = ownerAndPet.petOwner.Name,
                                Pet = ownerAndPet.petName
                            }
            );

            var query2 = petOwners.SelectMany(petOwners => petOwners.Pets, (petOwner, petName) => new { petOwner, petName })
                .Select(ownerAndPet => new { Owner = ownerAndPet.petOwner.Name, Pet = ownerAndPet.petName });

            // Print the results.
            foreach (var obj in query)
            {
                Console.WriteLine(obj);
            }
        }

        public static void Example2()
        {
            //Here we wil learn cartesian product

            var objects = new[] { "car", "house", "mouse", "book" };
            var colors = new[] { "red", "green", "blue" };

            var pairs = objects.SelectMany(obj => colors, (o, c) => $"{c} {o}");

            foreach (var pair in pairs)
            {
                Console.WriteLine(pair);
            }
        }
    }

    internal class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }
}