using System.Collections.Immutable;
using ProjectEuler.Mathematics.Combinatorics;

namespace ProjectEuler.Mathematics.Numbers
{
    /// <summary>
    /// A factor is a number that divides another number, leaving no remainder.
    /// </summary>
    public static class Factors
    {
        /// <summary>
        /// Finds and returns the factors of the specified <paramref name="number"/>.
        /// </summary>
        /// <param name="number">The number.</param>
        public static IEnumerable<long> Of(long number)
        {
            switch (number)
            {
                case <-1L:
                    number = -number;
                    break;
                case -1L:
                    yield return number;
                    yield break;
                case 0L:
                    yield break;
                case 1L:
                    yield return number;
                    yield break;
            }

            yield return +1L;
            yield return -1L;

            if (PrimeNumbers.IsPrime(number))
            {
                yield return +number;
                yield return -number;
                yield break;
            }

            var primeFactors = PrimeFactors.Of(number).ToArray();
            foreach (var factor in FindAllProductsOf(primeFactors).ToImmutableSortedSet())
            {
                yield return +factor;
                yield return -factor;
            }
        }

        private static IEnumerable<long> FindAllProductsOf(IReadOnlyCollection<long> primeFactors)
        {
            for (var length = 1; length <= primeFactors.Count; length++)
            {
                foreach (var combination in Combinations.Of(primeFactors, length))
                {
                    yield return combination.Aggregate(1L, (a, b) => a * b);
                }
            }
        }
    }
}
