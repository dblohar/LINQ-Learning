using System;
using System.Linq;

namespace LINQ_Learning
{
    internal class _0_Select
    {
        public static void SelectExample()
        {
            var numbers = Enumerable.Range(1, 10);

            var squares = numbers.Select(n => n * n);

            foreach (int num in squares)
            {
                Console.WriteLine(num);
            }

            string sentence = "This is long sentence to find the lenght";

            var worldLength = sentence.Split().Select(w => new { word = w, Length = w.Length });

            foreach (var wl in worldLength)
            {
                Console.WriteLine($"Word = { wl.word}\t Length = {wl.Length}");
            }

            Random rand = new Random();
            var randomNumbers = numbers.Select(_ => rand.Next(20));

            Console.WriteLine("\nRandom Numbers");

            foreach (var num in randomNumbers)
            {
                Console.Write($"{num},");
            }

            ///Using SelectMany
            ///

            Console.WriteLine("\n\nMergin multiple sequences in single sequence");

            var sequences = new[] { "red,green,blue", "orange", "white,pink" };

            var allWords = sequences.SelectMany(s => s.Split(','));

            foreach (var w in allWords)
            {
                Console.WriteLine(w);
            }
        }
    }
}