using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0006 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var numbers = Enumerable.Range(1, 100).ToArray();
        var sumSquareDifference = DifferenceBetweenSumOfSquaresAndSquareOfSum(numbers);
        return Task.FromResult<Answer>(sumSquareDifference);
    }

    private static long SumOfSquares(IEnumerable<int> numbers)
    {
        return numbers.Sum(x => (long)Math.Pow(x, 2));
    }

    private static long SquareOfSum(IEnumerable<int> numbers)
    {
        long sum = numbers.Sum();
        return (long)Math.Pow(sum, 2);
    }

    private static long DifferenceBetweenSumOfSquaresAndSquareOfSum(IReadOnlyCollection<int> numbers)
    {
        var sumOfSquares = SumOfSquares(numbers);
        var squareOfSum = SquareOfSum(numbers);
        return squareOfSum - sumOfSquares;
    }
}