using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

public class Solver_0030 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sumOfPowers = FindSumOfPowers(5).Sum();
        return await Task.FromResult(sumOfPowers);
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