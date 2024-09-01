using System.Numerics;
using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0057 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var count = FindSquareRootConvergents(1000);
        return Task.FromResult<Answer>(count);
    }

    private static int FindSquareRootConvergents(int expansions)
    {
        var count = 0;
        var numerator = new BigInteger(3);
        var denominator = new BigInteger(2);

        for (var i = 1; i < expansions; i++)
        {
            numerator += 2 * denominator;
            denominator = numerator - denominator;

            if (numerator.Digits().Count() > denominator.Digits().Count())
            {
                count++;
            }
        }

        return count;
    }
}