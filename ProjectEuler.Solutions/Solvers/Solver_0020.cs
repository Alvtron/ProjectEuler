using System.Numerics;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0020 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var number = new BigInteger(100);
        var factorial = CalculateFactorial(number);

        var factorialDigitSum = SumOfDigitsOf(factorial);
        return await Task.FromResult(factorialDigitSum);
    }

    private static int SumOfDigitsOf(BigInteger number)
    {
        return number.ToString().Select(digit => (int)char.GetNumericValue(digit)).Sum();
    }

    private static BigInteger CalculateFactorial(BigInteger number)
    {
        var factorial = BigInteger.One;

        for (var digit = number; digit > BigInteger.One; digit--)
        {
            factorial *= digit;
        }

        return factorial;
    }
}