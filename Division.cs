using System;
using System.Linq;

namespace Closures
{
    [Run(1)]
    public class Division
    {
        public Division()
        {
            Enumerable
                .Range(1, 15)
                .Where(predicate: IsDivisible(3))
                .Output();
        }

        private static bool IsDivisibleBy2(int number) =>
            number % 2 == 0;

        private static bool IsDivisibleBy3(int number) =>
            number % 3 == 0;

        private static Func<int, bool> IsDivisible(int divisor) =>
            number => number % divisor == 0;
    }
}