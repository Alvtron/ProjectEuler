using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0033: ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var curiousFractions = FindCuriousFractions(10, 99);

        var product = curiousFractions.Aggregate(
            (1, 1),
            (current, fraction) => (current.Item1 * fraction.numerator, current.Item2 * fraction.denominator));

        var commonDivisor = FinGreatestCommonDivisor(product.Item1, product.Item2);

        return await Task.FromResult(product.Item2 / commonDivisor);
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

    private static int FinGreatestCommonDivisor(int first, int second)
    {
        if (int.IsNegative(first))
        {
            throw new ArgumentException("The first number was negative.", nameof(first));
        }

        if (int.IsNegative(second))
        {
            throw new ArgumentException("The second number was negative.", nameof(second));
        }

        while (first != 0 && second != 0)
        {
            if (first > second)
            {
                first %= second;
            }
            else
            {
                second %= first;
            }
        }

        return first | second;
    }
}