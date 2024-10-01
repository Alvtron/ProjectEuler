namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// An octagonal number is the figure number that represent octagonal.
/// Octagonal numbers can be formed by placing triangular numbers on the four sides of a square.
/// Octagonal number is calculated by using the formula (3n2 – 2n).
/// </summary>
public static class OctagonalNumbers
{
    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is an octagonal number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is an octagonal number; <see langword="false"/> otherwise.</returns>
    public static bool IsOctagonal(int number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
                var n = (2 + Math.Sqrt(4 + 12 * number)) / 6;
                return double.IsInteger(n);
        }
    }

    /// <inheritdoc cref="IsOctagonal(int)"/>
    public static bool IsOctagonal(long number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
                var n = (2 + Math.Sqrt(4 + 12 * number)) / 6;
                return double.IsInteger(n);
        }
    }

    /// <summary>
    /// Gets the <paramref name="n"/>th octagonal number.
    /// </summary>
    /// <param name="n">The position of the octagonal number.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="n"/> is negative.</exception>
    public static long Get(long n)
    {
        if (n < 0L)
        {
            throw new ArgumentOutOfRangeException(nameof(n), n, "The argument was negative.");
        }

        return n * (3L * n - 2L);
    }

    /// <summary>
    /// Generates all octagonal numbers in ascending order.
    /// </summary>
    /// <remarks>
    /// Enumeration should be stopped using linq.
    /// </remarks>
    public static IEnumerable<long> Generate()
    {
        for (var n = 0L; n < long.MaxValue; n++)
        {
            yield return Get(n);
        }
    }

    /// <summary>
    /// Generates octagonal numbers between the <paramref name="start"/> position and <paramref name="end"/> position place (inclusive).
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