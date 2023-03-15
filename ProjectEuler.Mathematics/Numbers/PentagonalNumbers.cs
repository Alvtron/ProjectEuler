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
        for (var n = 1; n <= count; n++)
        {
            yield return GetNumber(n);
        }
    }

    /// <summary>
    /// Gets the <paramref name="n"/>th pentagonal number.
    /// </summary>
    /// <param name="n">The position of the pentagonal number.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="n"/> is lower than 1.</exception>
    public static long GetNumber(long n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        return n * (3 * n - 1) / 2;
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