using System;
using System.Globalization;
using ProjectEuler.Library;
using Singulink.Numerics;

namespace ProjectEuler.Solvers;

public class Solver_0026 : ISolver
{
    private const int MAXIMUM_NUMBER_OF_FRACTALS = 2000;

    public Answer Solve()
    {
        return FindLongestRecurringFractionCycle(1000);
    }

    private static Answer FindLongestRecurringFractionCycle(int maxDenominator)
    {
        var denominatorWithLongestCycle = 0;
        var longestCycleLength = 0;

        for (var denominator = 2; denominator <= maxDenominator; denominator++)
        {
            var number = BigDecimal.Divide(BigDecimal.One, denominator, MAXIMUM_NUMBER_OF_FRACTALS);

            var fractional = number.ToString(CultureInfo.InvariantCulture).AsSpan()[2..];
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

        for (var cycleIndex = cycleLength; cycleIndex <= numbers.Length - cycleLength; cycleIndex += cycleLength)
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