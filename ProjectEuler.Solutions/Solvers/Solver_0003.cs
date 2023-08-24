using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0003 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var largestPrimeFactor = FindPrimeFactors(600851475143L).Max();
        return await Task.FromResult(largestPrimeFactor);
    }

    private static IEnumerable<long> FindPrimeFactors(long number)
    {
        var remainder = number;
        var primeFactors = new List<long>();

        using var primeEnumerator = PrimeNumbers.Generate().GetEnumerator();
        primeEnumerator.MoveNext();

        while (remainder != 1L)
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