namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// A pentagonal number is a figural number that extends the concept of triangular and square numbers to the pentagon,
/// but, unlike the first two, the patterns involved in the construction of pentagonal numbers are not rotationally symmetrical.
/// </summary>
public static class PentagonalNumbers
{
    /// <summary>
    /// Generates pentagonal numbers until a specified <paramref name="count"/> is met.
    /// </summary>
    /// <param name="count">The number of pentagonal numbers to generate.</param>
    public static IEnumerable<long> Generate(long count)
    {
        for (var n = 1L; n <= count; n++)
        {
            yield return GetNumber(n);
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
            yield return GetNumber(start++);
        }
    }

    /// <summary>
    /// Gets the <paramref name="n"/>th pentagonal number.
    /// </summary>
    /// <param name="n">The position of the pentagonal number.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="n"/> is lower than 1.</exception>
    public static long GetNumber(long n)
    {
        if (n <= 0L)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        return n * (3L * n - 1L) / 2L;
    }

    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is a pentagonal number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a pentagonal number; <see langword="false"/> otherwise.</returns>
    public static bool IsPentagonalNumber(long number)
    {
        var n = (1.0 + Math.Sqrt(1.0 + 24.0 * number)) / 6.0;

        return double.IsPositive(n) && double.IsInteger(n);
    }
}