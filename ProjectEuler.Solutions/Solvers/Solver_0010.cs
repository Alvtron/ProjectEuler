using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0010 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var summationOfPrimes = SumOfPrimesBelow(2_000_000);
        return await Task.FromResult(summationOfPrimes);
    }

    private static long SumOfPrimesBelow(long limit)
    {
        var sum = 0L;

        foreach (var prime in PrimeNumbers.Generate())
        {
            if (prime >= limit)
            {
                break;
            }

            sum += prime;
        }

        return sum;
    }
}