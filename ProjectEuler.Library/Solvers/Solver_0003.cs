using ProjectEuler.Helpers.Numerics;
using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public partial class Solver_0003 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        return FindPrimeFactors(600851475143).Max();
    }

    private static IEnumerable<int> FindPrimeFactors(long number)
    {
        var remainder = number;
        var primeFactors = new List<int>();

        using var primeEnumerator = PrimeNumbers.Generate().GetEnumerator();
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