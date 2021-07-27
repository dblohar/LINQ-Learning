using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Learning
{
    internal class _3_FilteringOperators
    {
        internal static void Example1()
        {
            // Filters a sequence of values based on a predicate.

            List<string> fruits =
                new List<string> { "apple", "passionfruit", "banana", "mango",
                    "orange", "blueberry", "grape", "strawberry" };

            var result = fruits.Where(f => f.Length > 7);

            foreach (var fruit in result)
            {
                Console.WriteLine(fruit);
            }

            /*
                passionfruit
                blueberry
                strawberry

             */
        }

        internal static void Example2()
        {
            var numbers = Enumerable.Range(1, 10);
            foreach (var num in numbers)
            {
                Console.Write($"{num},");
            }

            Console.WriteLine("\n\nFind all even numbers");

            var evenNumbers = numbers.Where(n => n % 2 == 0);

            foreach (var evenNumber in evenNumbers)
            {
                Console.Write($"{evenNumber},");
            }

            Console.WriteLine("\n\nFind the square of all odd numbers");

            var numbersAndSquares = numbers.Where(n => n % 2 == 1)
                .Select(oddNumber => new { number = oddNumber, square = oddNumber * oddNumber });

            foreach (var item in numbersAndSquares)
            {
                Console.WriteLine($"{item.number} => {item.square},");
            }

            Console.WriteLine("\n\nFind the square of all odd numbers, select only square greather than 40");

            var numbersAndSquares2 = numbers.Where(n => n % 2 == 1)
                .Select(oddNumber => new { number = oddNumber, square = oddNumber * oddNumber })
                .Where(oddNumberAndSquare => oddNumberAndSquare.square > 40);

            foreach (var item in numbersAndSquares2)
            {
                Console.WriteLine($"{item.number} => {item.square},");
            }
        }

        internal static void Example3()
        {
            object[] values = { 1, 2, "Deepak", 1.3, 4.5, 2, };

            var integersValues = values.OfType<int>();
            var doubleValues = values.OfType<double>();
            var stringValues = values.OfType<string>();

            Console.WriteLine("Integer Values");
            foreach (var v in integersValues)
            {
                Console.Write($"{v}    ");
            }

            Console.WriteLine("\n\nDouble Values");
            foreach (var v in doubleValues)
            {
                Console.Write($"{v}    ");
            }

            Console.WriteLine("\n\nString Values");
            foreach (var v in stringValues)
            {
                Console.Write($"{v}    ");
            }
        }
    }
}