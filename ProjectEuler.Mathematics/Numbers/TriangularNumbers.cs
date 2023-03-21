namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// A triangular number or triangle number counts objects arranged in an equilateral triangle.
/// Triangular numbers are a type of figurative number, other examples being square numbers and cube numbers.
/// </summary>
public static class TriangularNumbers
{
    /// <summary>
    /// Generates triangular numbers until a specified <paramref name="count"/> is met.
    /// </summary>
    /// <param name="count">The number of triangular numbers to generate.</param>
    public static IEnumerable<long> Generate(long count)
    {
        for (var n = 1L; n <= count; n++)
        {
            yield return GetNumber(n);
        }
    }

    /// <summary>
    /// Generates Triangular numbers between the <paramref name="start"/> position and <paramref name="end"/> position place (inclusive).
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
    /// Gets the <paramref name="n"/>th triangular number.
    /// </summary>
    /// <param name="n">The position of the triangular number.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="n"/> is lower than 1.</exception>
    public static long GetNumber(long n)
    {
        if (n <= 0L)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        return n * (n + 1L) / 2L;
    }

    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is a triangular number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a triangular number; <see langword="false"/> otherwise.</returns>
    public static bool IsTriangularNumber(long number)
    {
        var n = (Math.Sqrt(8.0 * number + 1.0) - 1.0) / 2.0;
        return double.IsPositive(n) && double.IsInteger(n);
    }
}