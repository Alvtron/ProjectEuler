using ProjectEuler.Solutions.Answers;
using System.Numerics;
using ProjectEuler.Extensions.Numbers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0065 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<Answer>(FindSumOfDigits());
    }

    private static long FindSumOfDigits()
    {
        var numerator = BigInteger.One;
        var denominator = BigInteger.Zero;

        for (var n = 100; n > 0; n--)
        {
            BigInteger term;
            if (n == 1)
            {
                term = 2;
            }
            else if (n % 3 == 0)
            {
                term = 2 * (n / 3);
            }
            else
            {
                term = 1;
            }

            (numerator, denominator) = (denominator, numerator);

            numerator += term * denominator;
        }

        return numerator.Digits().Sum();
    }
}