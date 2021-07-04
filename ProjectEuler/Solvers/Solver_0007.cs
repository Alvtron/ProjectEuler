using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0007 : ISolver
    {
        public Answer Solve()
        {
            var primeGenerator = new PrimeGenerator();
            return primeGenerator.GetPrimes().ElementAt(10_001);
        }

        private class PrimeGenerator
        {
            private readonly List<int> KnownPrimes = new() { 2, 3, 5 };

            public IEnumerable<int> GetPrimes()
            {
                foreach (var prime in this.KnownPrimes)
                {
                    yield return prime;
                }

                for (var number = KnownPrimes.Last() + 1; true; number++)
                {
                    if (!this.IsPrime(number))
                    {
                        continue;
                    }

                    this.KnownPrimes.Add(number);
                    yield return number;
                }
            }

            private bool IsPrime(int number)
            {
                if (number == 2 || number == 3 || number == 5)
                {
                    return true;
                }

                if (number % 2 == 0)
                {
                    return false;
                }

                if (number % 5 == 0 && number % 10 != 0)
                {
                    return false;
                }

                return this.KnownPrimes.Skip(3).All(prime => number % prime != 0);
            }
        }
    }
}
