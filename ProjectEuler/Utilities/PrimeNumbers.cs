using System;
using System.Collections.Generic;

namespace ProjectEuler.Utilities
{
    public static class PrimeNumbers
    {
        public static IEnumerable<int> Generate()
        {
            for (var number = 1; true; number++)
            {
                if (!IsPrime(number))
                {
                    continue;
                }

                yield return number;
            }
        }

        private static bool IsPrime(int number)
        {
            switch (number)
            {
                case 1:
                    return false;
                case 2:
                    return true;
            }

            var limit = Math.Ceiling(Math.Sqrt(number));

            for (var divisor = 2; divisor <= limit; ++divisor)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}