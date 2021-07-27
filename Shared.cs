using System;

namespace LINQ_Learning
{
    internal class Shared
    {
        public static void Seperator()
        {
            Console.WriteLine();
            for (int i = 1; i <= 100; i++)
                Console.Write("-");
            Console.WriteLine();
        }
    }
}