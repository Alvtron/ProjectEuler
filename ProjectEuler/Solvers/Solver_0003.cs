using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Library;
using ProjectEuler.Utilities;

namespace ProjectEuler.Solvers
{
    public partial class Solver_0003 : ISolver
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
    }
}
