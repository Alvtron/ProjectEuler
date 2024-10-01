namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// A heptagonal number is a figurative number that represents a heptagon.
/// Heptagonal has seven angles, seven vertices, and seven-sided polygon.
/// </summary>
public static class HeptagonalNumbers
{
    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is a heptagonal number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a heptagonal number; <see langword="false"/> otherwise.</returns>
    public static bool IsHeptagonal(int number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
                var n = (3 + Math.Sqrt(9 + 40 * number)) / 10;
                return double.IsInteger(n);
        }
    }

    /// <inheritdoc cref="IsHeptagonal(int)"/>
    public static bool IsHeptagonal(long number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
                var n = (3 + Math.Sqrt(9 + 40 * number)) / 10;
                return double.IsInteger(n);
        }
    }

    /// <summary>
    /// Gets the <paramref name="n"/>th heptagonal number.
    /// </summary>
    /// <param name="n">The position of the heptagonal number.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="n"/> is negative.</exception>
    public static long Get(long n)
    {
        if (n < 0L)
        {
            throw new ArgumentOutOfRangeException(nameof(n), n, "The argument was negative.");
        }

        return n * (5L * n - 3L) / 2L;
    }

    /// <summary>
    /// Generates all heptagonal numbers in ascending order.
    /// </summary>
    /// <remarks>Enumeration should be stopped using linq.</remarks>
    public static IEnumerable<long> Generate()
    {
        for (var n = 0L; n < long.MaxValue; n++)
        {
            yield return Get(n);
        }
    }

    /// <summary>
    /// Generates heptagonal numbers between the <paramref name="start"/> position and <paramref name="end"/> position place (inclusive).
    /// </summary>
    /// <param name="start">The starting position.</param>
    /// <param name="end">The ending position.</param>
    public static IEnumerable<long> Between(long start, long end)
    {
        if (start > end)
        {
            throw new ArgumentOutOfRangeException(nameof(start), start, "The start position was higher than the end position.");
        }

        while (start <= end)
        {
            yield return Get(start++);
        }
    }
}