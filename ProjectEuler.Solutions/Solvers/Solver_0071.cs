using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0071 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var fraction = FindLargestReducedFractionSmallerThanOtherReducedFraction(new Fraction(3, 7), 1_000_000);
        return Task.FromResult<Answer>(fraction.Numerator);
    }

    private static Fraction FindLargestReducedFractionSmallerThanOtherReducedFraction(Fraction targetFraction, int maxDenominator)
    {
        var bestFraction = new Fraction(0, 1);

        for (var denominator = 2; denominator <= maxDenominator; denominator++)
        {
            var numerator = (denominator * targetFraction.Numerator - 1) / targetFraction.Denominator;
            if (numerator % 7 == 0)
            {
                continue;
            }

            var fraction = new Fraction(numerator, denominator);
            if (fraction.Value < bestFraction.Value)
            {
                continue;
            }

            bestFraction = fraction;
        }

        return bestFraction;
    }

    private readonly record struct Fraction(int Numerator, int Denominator)
    {
        public double Value { get; } = (double)Numerator / Denominator;
    }
}