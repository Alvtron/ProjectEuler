namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// A pentagonal number is a figural number that extends the concept of triangular and square numbers to the pentagon,
/// but, unlike the first two, the patterns involved in the construction of pentagonal numbers are not rotationally symmetrical.
/// </summary>
public static class PentagonalNumbers
{
    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is a pentagonal number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a pentagonal number; <see langword="false"/> otherwise.</returns>
    public static bool IsPentagonal(int number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
                var n = (1 + Math.Sqrt(1 + 24 * number)) / 6;
                return double.IsInteger(n);
        }
    }

    /// <inheritdoc cref="IsPentagonal(int)"/>
    public static bool IsPentagonal(long number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
                var n = (1 + Math.Sqrt(1 + 24 * number)) / 6;
                return double.IsInteger(n);
        }
    }

    /// <summary>
    /// Gets the <paramref name="n"/>th pentagonal number.
    /// </summary>
    /// <param name="n">The position of the pentagonal number.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="n"/> is negative.</exception>
    public static long Get(long n)
    {
        if (n < 0L)
        {
            throw new ArgumentOutOfRangeException(nameof(n), n, "The argument was negative.");
        }

        return n * (3L * n - 1L) / 2L;
    }

    /// <summary>
    /// Generates all pentagonal numbers in ascending order.
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
    /// Generates pentagonal numbers between the <paramref name="start"/> position and <paramref name="end"/> position place (inclusive).
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