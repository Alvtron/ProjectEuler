using ProjectEuler.Extensions.Collections;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0050 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var terms = FindConsecutivePrimesThatAddsToPrime(1000000);
        return Task.FromResult<Answer>(terms.Sum());
    }

    private static ReadOnlySpan<long> FindConsecutivePrimesThatAddsToPrime(long limit)
    {
        var primes = new ReadOnlySpan<long>(PrimeNumbers.Between(0, limit).ToArray());
        var longestPrimes = ReadOnlySpan<long>.Empty;
        for (var sliceIndex = 0; sliceIndex < primes.Length; sliceIndex++)
        {
            if (longestPrimes.Length > primes.Length - sliceIndex)
            {
                return longestPrimes;
            }

            for (var sliceLength = longestPrimes.Length; sliceLength <= primes.Length - sliceIndex; sliceLength++)
            {
                var candidatePrimes = primes.Slice(sliceIndex, sliceLength);
                var candidateSum = candidatePrimes.Sum();
                if (candidateSum > limit)
                {
                    break;
                } 

                if (PrimeNumbers.IsPrime(candidateSum))
                {
                    longestPrimes = candidatePrimes;
                }
            }
        }

        return ReadOnlySpan<long>.Empty;
    }
}