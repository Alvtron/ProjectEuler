using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0003 : ISolver
    {
        public Answer Solve()
        {
            return FindPrimeFactors(600851475143).Max();
        }

        private static IEnumerable<int> FindPrimeFactors(long number)
        {
            var remainder = number;
            var primeFactors = new List<int>();
            var primeGenerator = new PrimeGenerator();

            using var primeEnumerator = primeGenerator.GetPrimes().GetEnumerator();
            primeEnumerator.MoveNext();
            while (remainder != 1)
            {
                var prime = primeEnumerator.Current;
                if (remainder % prime == 0L)
                {
                    primeFactors.Add(prime);
                    remainder /= prime;
                }
                else
                {
                    primeEnumerator.MoveNext();
                }
            }

            return primeFactors;
        }

        private class PrimeGenerator
        {
            private readonly SortedSet<int> KnownPrimes = new() { 2, 3, 5 };
            
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

                    yield return number;
                }
            }

            private bool IsPrime(int number)
            {
                if (this.KnownPrimes.Contains(number))
                {
                    return true;
                }

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

                var isPrime = this.KnownPrimes.Skip(3).All(prime => number % prime != 0);
                if (isPrime)
                {
                    this.KnownPrimes.Add(number);
                }

                return isPrime;
            }
        }
    }
}
