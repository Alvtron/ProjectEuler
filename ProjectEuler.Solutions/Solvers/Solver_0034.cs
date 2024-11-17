using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0034: ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sum = FindCuriousNumbersBetween(3, 1_500_000).Sum();
        return Task.FromResult<Answer>(sum);
    }

    private static IEnumerable<int> FindCuriousNumbersBetween(int start, int end)
    {
        for (var number = start; number < end; number++)
        {
            var sumOfFactorials = number.Digits().Sum(Factorial);
            if (sumOfFactorials != number)
            {
                continue;
            }

            yield return number;
        }
    }

    private static int Factorial(int number)
    {
        var result = 1;
        for (var current = number; current > 0; current--)
        {
            result *= current;
        }

        return result;
    }
}