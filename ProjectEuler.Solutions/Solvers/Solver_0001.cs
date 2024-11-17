using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0001 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sumOfMultiples = SumOfMultiples(numbers: [3, 5], limit: 1000);
        return Task.FromResult<Answer>(sumOfMultiples);
    }

    private static int SumOfMultiples(int[] numbers, int limit)
    {
        var totalSum = 0;

        for (var i = 1; i < limit; i++)
        {
            if (numbers.Any(number => i % number == 0))
            {
                totalSum += i;
            }
        }

        return totalSum;
    }
}