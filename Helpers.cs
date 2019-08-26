using System;
using System.Collections.Generic;

namespace Closures
{
    public static class Helpers
    {
        public static int[] StoryPoints
        {
            get { return new[] {0, 1, 2, 3, 5, 8, 13, 20, 40, 100}; }
        }

        public static void Output(this IEnumerable<int> sequence)
        {
            foreach (var item in sequence)
                Console.WriteLine($"  {item}");
        }
    }
}