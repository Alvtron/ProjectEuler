using ProjectEuler.Solutions.Answers;
using System.Numerics;
using ProjectEuler.Mathematics.Functions;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0053 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var result = FindCombinatoricSelectionsBetween(1, 100).Count(n => n > 1_000_000);

        return Task.FromResult<Answer>(result);
    }

    private static IEnumerable<BigInteger> FindCombinatoricSelectionsBetween(int start, int end)
    {
        for (var n = start; n <= end; n++)
        {
            for (var r = 1; r <= n; r++)
            {
                yield return Factorial.Of(n) / (Factorial.Of(r) * Factorial.Of(n - r));
            }
        }
    }
}