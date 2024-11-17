using System.Numerics;
using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0013 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var numbers = GetNumbersFromString(Resource_0013.Numbers);
        var sum = GetSumOf(numbers);

        var largestSum = GetFirstDigitsOf(sum, 10);
        return Task.FromResult<Answer>(largestSum);
    }

    private static IEnumerable<BigInteger> GetNumbersFromString(string numbers)
    {
        return numbers.Split(Environment.NewLine).Select(BigInteger.Parse);
    }

    private static BigInteger GetSumOf(IEnumerable<BigInteger> numbers)
    {
        var sum = new BigInteger();

        return numbers.Aggregate(sum, (current, number) => current + number);
    }

    private static long GetFirstDigitsOf(BigInteger number, int count)
    {
        var firstNumbers = number.ToString()[..count];
        return long.Parse(firstNumbers);
    }
}