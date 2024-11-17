using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0030 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sumOfPowers = FindSumOfPowers(5).Sum();
        return Task.FromResult<Answer>(sumOfPowers);
    }

    private static IEnumerable<double> FindSumOfPowers(int power)
    {
        var maxSum = Math.Pow(10, power + 1);
        for (var targetSum = 2; targetSum < maxSum; targetSum++)
        {
            var actualSum = (int)targetSum.Digits().Sum(digit => Math.Pow(digit, power));

            if (actualSum == targetSum)
            {
                yield return actualSum;
            }
        }
    }
}