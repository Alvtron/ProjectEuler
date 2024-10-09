using ProjectEuler.Mathematics.Functions;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0073 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var lower = new Fraction(1, 3);
        var upper = new Fraction(1, 2);

        var count = FindReducedProperFractionsBetween(lower, upper, 12_000);
        return Task.FromResult<Answer>(count);
    }

    private static int FindReducedProperFractionsBetween(Fraction lower, Fraction upper, int maxDenominator)
    {
        var count = 0;

        for (var denominator = 1; denominator <= maxDenominator; denominator++)
        {
            var lowerNumerator = lower.Numerator * denominator / lower.Denominator + 1;
            var upperNumerator = upper.Numerator * denominator / upper.Denominator;

            // Ensure lower numerator and upper numerator are within valid bounds
            if (lowerNumerator > upperNumerator)
            {
                continue;
            }

            // Count fractions in the simplest form
            for (var numerator = lowerNumerator; numerator <= upperNumerator; numerator++)
            {
                if (GreatestCommonDivisor.Of(numerator, denominator) != 1)
                {
                    continue;
                }

                count++;
            }
        }

        return count - 1;
    }

    private readonly record struct Fraction(int Numerator, int Denominator);
}