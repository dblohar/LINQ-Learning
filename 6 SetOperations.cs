using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LINQ_Learning
{
    internal class SetOperations
    {
        /*  Returns distinct elements from a sequence.
         *  This method is implemented by using deferred execution. */

        public static void Example1_Distinct()
        {
            /*
             Distinct<TSource>(IEnumerable<TSource>)

            Returns distinct elements from a sequence by using the default equality comparer to compare values.
             */

            List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };

            Console.WriteLine("Ages");
            foreach (var age in ages)
            {
                Console.Write($"{age}, ");
            }

            Console.WriteLine("\n\nDistinct Ages");
            var distinctAges = ages.Distinct();

            foreach (var age in distinctAges)
            {
                Console.Write($"{age}, ");
            }
        }

        public static void Example2_Distinct()
        {
            /*
             If you want to return distinct elements from sequences of objects of some custom data type,
            you have to implement the IEquatable<T> generic interface in the class.
            The following code example shows how to implement this interface in a
            custom data type and provide GetHashCode and Equals methods.
             */

            Product[] products = { new Product { Name = "apple", Code = 9 },
                       new Product { Name = "orange", Code = 4 },
                       new Product { Name = "apple", Code = 9 },
                       new Product { Name = "lemon", Code = 12 } };

            var distinctProducts = products.Distinct();

            foreach (var product in distinctProducts)
            {
                Console.WriteLine($"Code = {product.Code}, Name = {product.Name}");
            }
        }

        public static void Example3_Distinct()
        {
            string word1 = "hellooooo";
            string word2 = "hello";
            Console.WriteLine($"word1 = {word1} | word2 = {word2}\n ");

            Console.WriteLine("Distinct Characters from word1");
            Console.Write("\t");
            var distinctChar = word1.Distinct();

            foreach (var ch in distinctChar)
            {
                Console.Write($"{ch}, ");
            }
        }

        public static void Example4_Intersect()
        {
            string word1 = "hellooooo";
            string word2 = "help";
            Console.WriteLine($"word1 = {word1} | word2 = {word2}\n ");

            Console.WriteLine("Common Word in word1 and word2");
            var commonLettersInBoth = word1.Intersect(word2);
            foreach (var ch in commonLettersInBoth)
            {
                Console.Write($"{ch}, ");
            }

            Shared.Seperator();

            Console.WriteLine($@"The following code example demonstrates how to use
    Intersect<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)
to return the elements that appear in each of two sequences of integers.");

            int[] id1 = { 44, 26, 92, 30, 71, 38 };
            int[] id2 = { 39, 59, 83, 47, 26, 4, 30 };

            Console.Write("\nId1 => ");
            foreach (var id in id1)
            {
                Console.Write($"{id}, ");
            }

            Console.Write("\nId2 => ");
            foreach (var id in id2)
            {
                Console.Write($"{id}, ");
            }

            Console.WriteLine("\nCommon Ids in both");
            IEnumerable<int> both = id1.Intersect(id2);

            foreach (int id in both)
                Console.WriteLine(id);
        }

        internal static void Example4_Union()
        {
            int[] ints1 = { 5, 3, 9, 7, 5, 9, 3, 7 };
            int[] ints2 = { 8, 3, 6, 4, 4, 9, 1, 0 };

            IEnumerable<int> union = ints1.Union(ints2);

            Console.Write("\nCollection 1=> ");
            foreach (var n in ints1) { Console.Write($"{n}, "); }

            Console.Write("\nCollection 2=> ");
            foreach (var n in ints2) { Console.Write($"{n}, "); }

            Console.Write("\nUnion => ");
            foreach (var n in union) { Console.Write($"{n}, "); }
        }

        public static void Example5_Except()
        {
            //return the unique items  collection 1 which are not present in collection 2

            double[] numbers1 = { 2.0, 2.0, 2.1, 2.2, 2.3, 2.3, 2.4, 2.5 };
            double[] numbers2 = { 2.2 };

            Console.Write("\nCollection 1=> ");
            foreach (var n in numbers1) { Console.Write($"\n{n}"); }

            Console.Write("\nCollection 2=> ");
            foreach (var n in numbers2) { Console.Write($"\n{n}"); }

            var elementFromFirstCollection = numbers1.Except(numbers2);

            Console.Write("\nUnique Element only from first collection => ");
            foreach (var n in elementFromFirstCollection) { Console.Write($"\n{n}"); }
        }

        public class Product : IEquatable<Product>
        {
            public string Name { get; set; }
            public int Code { get; set; }

            public bool Equals([AllowNull] Product other)
            {
                //Check whether the compared object in null
                if (Object.ReferenceEquals(this, null)) return false;

                //Check whether the compared object references the same data.
                if (Object.ReferenceEquals(this, other)) return true;

                //Check whether the products' properties are equal.
                return Code.Equals(other.Code) && Name.Equals(Name);
            }

            public override int GetHashCode()
            {
                //Get hash code for the Name field if it is not null.

                int hashCodeOfName = Name == null ? 0 : Name.GetHashCode();

                int hashCodeOfCodeField = Code.GetHashCode();

                return hashCodeOfName ^ hashCodeOfCodeField;
            }
        }
    }
}