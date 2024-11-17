using System.Numerics;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0016 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var number = BigInteger.Pow(2, 1000);
        var powerDigitSum = SumOfDigits(number);
        return Task.FromResult<Answer>(powerDigitSum);
    }

    private static int SumOfDigits(BigInteger number)
    {
        return number.ToString().Select(digit => (int)char.GetNumericValue(digit)).Sum();
    }
}