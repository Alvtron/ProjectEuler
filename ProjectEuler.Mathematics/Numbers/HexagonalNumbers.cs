namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// A hexagonal number is a figurative number.
/// The n-th hexagonal number is the number of distinct dots in a pattern of dots
/// consisting of the outlines of regular hexagons with sides up to n dots,
/// when the hexagons are overlaid so that they share one vertex.
/// </summary>
public static class HexagonalNumbers
{
    /// <summary>
    /// Generates hexagonal numbers until a specified <paramref name="count"/> is met.
    /// </summary>
    /// <param name="count">The number of hexagonal numbers to generate.</param>
    public static IEnumerable<long> Generate(long count)
    {
        for (var n = 1L; n <= count; n++)
        {
            yield return GetNumber(n);
        }
    }

    /// <summary>
    /// Generates hexagonal numbers between the <paramref name="start"/> position and <paramref name="end"/> position place (inclusive).
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
            yield return GetNumber(start++);
        }
    }

    /// <summary>
    /// Gets the <paramref name="n"/>th hexagonal number.
    /// </summary>
    /// <param name="n">The position of the hexagonal number.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="n"/> is lower than 1.</exception>
    public static long GetNumber(long n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        return n * (2L * n - 1L);
    }

    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is a hexagonal number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a hexagonal number; <see langword="false"/> otherwise.</returns>
    public static bool IsHexagonalNumber(long number)
    {
        var n = (1 + Math.Sqrt(1.0 + 8.0 * number)) / 4.0;
        return double.IsPositive(n) && double.IsInteger(n);
    }
}