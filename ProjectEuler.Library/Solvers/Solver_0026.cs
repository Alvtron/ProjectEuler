using System.Globalization;
using ProjectEuler.Helpers.Numerics;
using ProjectEuler.Library.Answers;
using Singulink.Numerics;

namespace ProjectEuler.Library.Solvers;

public class Solver_0026 : ISolver
{
    private const int MAXIMUM_NUMBER_OF_FRACTALS = 2000;

    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var denominator = FindDenominatorWithLongestRecurringFractionCycle(1, 2, 1000);
        return await Task.FromResult(denominator);
    }

    private static int FindDenominatorWithLongestRecurringFractionCycle(int numerator, int startDenominator, int endDenominator)
    {
        var denominatorWithLongestCycle = 0;
        var longestCycleLength = 0;

        // only need to check prime denominators because cycle length would be identical for multiples
        var primeDenominators = PrimeNumbers.Generate()
            .TakeWhile(prime => prime >= startDenominator && prime <= endDenominator);

        foreach (var denominator in primeDenominators)
        {
            var decimalNumber = BigDecimal.Divide(numerator, denominator, MAXIMUM_NUMBER_OF_FRACTALS);

            var fractional = decimalNumber.ToString(CultureInfo.InvariantCulture).AsSpan()[2..];
            var currentLongestCycleLength = GetShortestCycleFrom(fractional);

            if (currentLongestCycleLength <= longestCycleLength)
            {
                continue;
            }

            denominatorWithLongestCycle = denominator;
            longestCycleLength = currentLongestCycleLength;
        }

        return denominatorWithLongestCycle;
    }

    private static int GetShortestCycleFrom(ReadOnlySpan<char> numbers)
    {
        var shortestCycleLength = 0;
        for (var cycleLength = numbers.Length / 2; cycleLength > 1; cycleLength--)
        {
            if (!HasCycle(numbers, cycleLength))
            {
                continue;
            }

            shortestCycleLength = cycleLength;
        }

        return shortestCycleLength;
    }

    private static bool HasCycle(ReadOnlySpan<char> numbers, int cycleLength)
    {
        var firstPart = numbers[..cycleLength];

        var maxCycleIndex = numbers.Length - cycleLength;
        for (var cycleIndex = cycleLength; cycleIndex <= maxCycleIndex; cycleIndex += cycleLength)
        {
            var nextPart = numbers.Slice(cycleIndex, cycleLength);

            if (firstPart.SequenceEqual(nextPart))
            {
                continue;
            }

            return false;
        }

        return true;
    }
}