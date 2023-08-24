using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0002 : ISolver
{
    private const int LIMIT = 4000000;

    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sumOfEvenFibonacciNumbers = SumOfEvenFibonacciNumbers(LIMIT);
        return await Task.FromResult(sumOfEvenFibonacciNumbers);
    }

    private static long SumOfEvenFibonacciNumbers(int limit)
    {
        var first = 1;
        var second = 2;
        var sum = second;
        do
        {
            var secondCopy = second;
            second = first + second;
            first = secondCopy;
            if (second % 2 == 0)
            {
                sum += second;
            }
        } while (second <= limit);
        return sum;
    }
}