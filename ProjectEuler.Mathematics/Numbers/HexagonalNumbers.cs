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
    /// Determines whether the specified <paramref name="number"/> is a hexagonal number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a hexagonal number; <see langword="false"/> otherwise.</returns>
    public static bool IsHexagonal(int number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
            {
                var n = (1 + Math.Sqrt(1 + 8 * number)) / 4;
                return double.IsInteger(n);
            }
        }
    }

    /// <inheritdoc cref="IsHexagonal(int)"/>
    public static bool IsHexagonal(long number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
            {
                var n = (1 + Math.Sqrt(1 + 8 * number)) / 4;
                return double.IsInteger(n);
            }
        }
    }

    /// <summary>
    /// Gets the <paramref name="n"/>th hexagonal number.
    /// </summary>
    /// <param name="n">The position of the hexagonal number.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="n"/> is negative.</exception>
    public static long Get(long n)
    {
        if (n < 0L)
        {
            throw new ArgumentOutOfRangeException(nameof(n), n, "The argument was negative.");
        }

        return n * (2L * n - 1L);
    }

    /// <summary>
    /// Generates all hexagonal numbers in ascending order.
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
            yield return Get(start++);
        }
    }
}