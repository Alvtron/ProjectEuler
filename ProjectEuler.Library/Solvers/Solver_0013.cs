using System.Numerics;
using ProjectEuler.Library.Answers;
using ProjectEuler.Library.Resources;

namespace ProjectEuler.Library.Solvers;

public class Solver_0013 : ISolver
{
    private static readonly string NumbersFilePath = ResourcesHelper.GetResourcePath("problem_0013_numbers.txt");

    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var numbersString = await File.ReadAllTextAsync(NumbersFilePath, cancellationToken);
        var numbers = GetNumbersFromString(numbersString);
        var sum = GetSumOf(numbers);

        return GetFirstDigitsOf(sum, 10);
    }

    private static IEnumerable<BigInteger> GetNumbersFromString(string numbers)
    {
        return numbers.Split(Environment.NewLine).Select(BigInteger.Parse);
    }

    private static BigInteger GetSumOf(IEnumerable<BigInteger> numbers)
    {
        var sum = new BigInteger();

        foreach (var number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    private static long GetFirstDigitsOf(BigInteger number, int count)
    {
        var firstNumbers = number.ToString().Substring(0, count);
        return long.Parse(firstNumbers);
    }
}