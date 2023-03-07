using System.Numerics;
using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

public class Solver_0013 : ISolver
{
    private static readonly string NumbersFilePath = ResourcesHelper.GetResourcePath("problem_0013_numbers.txt");

    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var numbersString = await File.ReadAllTextAsync(NumbersFilePath, cancellationToken);
        var numbers = GetNumbersFromString(numbersString);
        var sum = GetSumOf(numbers);

        var largestSum = GetFirstDigitsOf(sum, 10);
        return await Task.FromResult(largestSum);
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