using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0076 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var result = CountWaysToSum(target: 100);
        return Task.FromResult<Answer>(result);
    }

    private static long CountWaysToSum(int target)
    {
        var ways = new long[target + 1];
        ways[0] = 1;
        for (var i = 1; i < target; i++)
        {
            for (var j = i; j <= target; j++)
            {
                ways[j] += ways[j - i];
            }
        }

        return ways[target];
    }
}