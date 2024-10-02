using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;
using System.Numerics;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0066 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<Answer>(FindDWithLargestPellSolution(2, 1000));
    }

    private static int FindDWithLargestPellSolution(int minD, int maxD)
    {
        if (minD < 2)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(minD, 2);
        }

        if (maxD < minD)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(maxD, minD);
        }

        var bestD = 0;
        var largestX = BigInteger.Zero;

        for (var d = minD; d <= maxD; d++)
        {
            if (SquareNumbers.IsSquare(d))
            {
                continue;
            }

            var (x, _) = SolvePellEquation(d);
            if (x <= largestX)
            {
                continue;
            }

            largestX = x;
            bestD = d;
        }

        return bestD;
    }

    private static (BigInteger, BigInteger) SolvePellEquation(int number)
    {
        var m = 0;
        var d = 1;
        var a0 = (int)Math.Sqrt(number);
        var a = a0;

        var previousNumerator = BigInteger.One;
        var currentNumerator = new BigInteger(a0);
        var previousDenominator = BigInteger.Zero;
        var currentDenominator = BigInteger.One;

        while (currentNumerator * currentNumerator - number * currentDenominator * currentDenominator != 1)
        {
            m = d * a - m;
            d = (number - m * m) / d;
            a = (a0 + m) / d;

            var nextNumerator = a * currentNumerator + previousNumerator;
            var nextDenominator = a * currentDenominator + previousDenominator;

            previousNumerator = currentNumerator;
            currentNumerator = nextNumerator;
            previousDenominator = currentDenominator;
            currentDenominator = nextDenominator;
        }

        return (currentNumerator, currentDenominator);

    }
}