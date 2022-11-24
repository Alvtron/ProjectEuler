using ProjectEuler.Helpers.Numerics;
using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0010 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        return SumOfPrimesBelow(2_000_000);
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