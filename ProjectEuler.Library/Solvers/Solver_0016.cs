using System.Numerics;
using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0016 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var number = BigInteger.Pow(2, 1000);
        var powerDigitSum = SumOfDigits(number);
        return await Task.FromResult(powerDigitSum);
    }

    private static int SumOfDigits(BigInteger number)
    {
        return number.ToString().Select(digit => (int)char.GetNumericValue(digit)).Sum();
    }
}