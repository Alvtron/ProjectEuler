using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0023 : ISolver
    {

        public Answer Solve()
        {
            const int LIMIT = 28123;
            
            var sumsOfAbundantNumbers = GetSumsOfAbundantNumbers(LIMIT);

            var positiveIntegers = Enumerable.Range(1, LIMIT)
                .Where(number => !sumsOfAbundantNumbers.Contains(number));

            return positiveIntegers.Sum();
        }

        private static ISet<int> GetSumsOfAbundantNumbers(int limit)
        {
            var abundantNumbers = new HashSet<int>();
            var sumsOfAbundantNumbers = new HashSet<int>();

            for (var number = 1; number <= limit; number++)
            {
                var divisors = GetProperDivisorsOf(number);
                if (divisors.Sum() <= number)
                {
                    // number is not abundant
                    continue;
                }

                abundantNumbers.Add(number);

                foreach (var abundantNumber in abundantNumbers)
                {
                    sumsOfAbundantNumbers.Add(abundantNumber + number);
                }
            }

            return sumsOfAbundantNumbers;
        }

        private static IEnumerable<int> GetProperDivisorsOf(int number)
        {
            var limit = number / 2;

            for (var divisor = 1; divisor <= limit; divisor++)
            {
                if (number % divisor == 0)
                {
                    yield return divisor;
                }
            }
        }
    }
}
