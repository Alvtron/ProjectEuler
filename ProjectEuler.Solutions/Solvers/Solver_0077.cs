using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0077 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var number = FindSmallestNumberWithPrimeSumWays(targetWays: 5000, maxNumber: 100);
        return Task.FromResult<Answer>(number);
    }

    private static int FindSmallestNumberWithPrimeSumWays(int targetWays, int maxNumber)
    {
        var ways = new int[maxNumber + 1];
        ways[0] = 1; // One way to sum to 0

        var primes = PrimeNumbers.Between(2, maxNumber);
        foreach (var prime in primes)
        {
            for (var i = (int)prime; i <= maxNumber; i++)
            {
                ways[i] += ways[i - (int)prime];
            }
        }

        // Find the first number with more than `targetWays` sums
        for (var n = 2; n <= maxNumber; n++)
        {
            if (ways[n] > targetWays)
            {
                return n;
            }
        }

        throw new InvalidOperationException("No number found with the specified condition.");
    }
}