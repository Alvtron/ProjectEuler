namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// A square number is a positive integer that can be formed by multiplying two smaller positive integers.
/// Equivalently, it is a positive integer that has at least one divisor other than 1 and itself.
/// </summary>
public static class SquareNumbers
{
    /// <summary>
    /// Generates all perfect squares in ascending order.
    /// </summary>
    /// <remarks>Enumeration should be stopped using linq.</remarks>
    public static IEnumerable<long> Generate()
    {
        for (var number = 0L;; number++)
        {
            yield return number * number;
        }
    }

    /// <summary>
    /// Find all perfect square between a <paramref name="start"/> and <paramref name="end"/>.
    /// </summary>
    /// <remarks>
    /// If <paramref name="start"/> is greater than <paramref name="end"/>,
    /// the square values are generated in descending order.
    /// </remarks>
    /// <param name="start">The start number that defines one point in the search space.</param>
    /// <param name="end">The end number that defines another point in the search space.</param>
    public static IEnumerable<long> Between(long start, long end)
    {
        start = Math.Max(start, 0L);
        end = Math.Max(end, 0L);
        var step = start < end ? 1L : -1L;

        for (var number = start; number <= end; number += step)
        {
            if (!IsSquare(number))
            {
                continue;
            }

            yield return number;
        }
    }

    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is considered a perfect square.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a perfect square; <see langword="false"/> otherwise.</returns>
    public static bool IsSquare(long number)
    {
        if (long.IsNegative(number))
        {
            return false;
        }

        var root = Math.Sqrt(number);
        if (!double.IsInteger(root))
        {
            return false;
        }

        var longRoot = (long)root;
        
        return longRoot * longRoot == number;
    }
}