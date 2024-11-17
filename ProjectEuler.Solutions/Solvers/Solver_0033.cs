using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Mathematics.Functions;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0033: ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var curiousFractions = FindCuriousFractions(10, 99);

        var product = curiousFractions.Aggregate(
            (1, 1),
            (current, fraction) => (current.Item1 * fraction.numerator, current.Item2 * fraction.denominator));

        var commonDivisor = GreatestCommonDivisor.Of(product.Item1, product.Item2);

        return Task.FromResult<Answer>(product.Item2 / commonDivisor);
    }

    private static IEnumerable<(int numerator, int denominator)> FindCuriousFractions(int start, int end)
    {
        for (var denominator = start; denominator <= end; denominator++)
        {
            for (var numerator = start; numerator < denominator; numerator++)
            {
                var lastNumeratorDigit = numerator.LastDigits(1);
                if (lastNumeratorDigit == 0)
                {
                    continue;
                }

                var lastDenominatorDigit = denominator.LastDigits(1);
                if (lastDenominatorDigit == 0)
                {
                    continue;
                }

                var firstDenominatorDigit = denominator.FirstDigits(1);
                if (lastNumeratorDigit != firstDenominatorDigit)
                {
                    continue;
                }

                var firstNumeratorDigit = numerator.FirstDigits(1);

                var fraction = (decimal)numerator / denominator;
                var commonDigitFraction = (decimal)firstNumeratorDigit / lastDenominatorDigit;
                if (fraction != commonDigitFraction)
                {
                    continue;
                }

                yield return (numerator, denominator);
            }
        }
    }
}