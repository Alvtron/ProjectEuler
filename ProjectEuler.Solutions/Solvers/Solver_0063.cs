using System.Numerics;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0063 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var count = CountNthPowerDigits();
        return Task.FromResult<Answer>(count);
    }

    private static int CountNthPowerDigits()
    {
        var count = 0;

        for (var number = 1; number < 10; number++)
        {
            for (var exponent = 1; ; exponent++)
            {
                var result = BigInteger.Pow(number, exponent);
                var length = result.ToString().Length;
                if (length == exponent)
                {
                    count++;
                }
                else if (length < exponent)
                {
                    break;
                }
            }
        }

        return count;
    }   
}