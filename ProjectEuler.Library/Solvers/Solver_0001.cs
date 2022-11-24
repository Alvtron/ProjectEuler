using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0001 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var numbers = new[] { 3, 5 };
        const int LIMIT = 1000;

        return SumOfMultiples(numbers, LIMIT);
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