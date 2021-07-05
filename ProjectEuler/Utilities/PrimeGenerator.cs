using System;
using System.Collections.Generic;

namespace ProjectEuler.Utilities
{
    public class PrimeGenerator
    {
        public IEnumerable<int> GetPrimes()
        {
            for (var number = 1; true; number++)
            {
                if (!this.IsPrime(number))
                {
                    continue;
                }

                yield return number;
            }
        }

        private bool IsPrime(int number)
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