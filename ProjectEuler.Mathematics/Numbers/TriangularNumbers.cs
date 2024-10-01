namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// The triangular number sequence is the representation of the numbers in the form of equilateral triangle arranged in a series or sequence.
/// These numbers are in a sequence of 1, 3, 6, 10, 15, 21, 28, 36, 45, and so on.
/// The numbers in the triangular pattern are represented by dots.
/// </summary>
public static class TriangularNumbers
{
    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is considered a triangular number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a triangular number; <see langword="false"/> otherwise.</returns>
    public static bool IsTriangular(int number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
                var n = (-1 + Math.Sqrt(1 + 8 * number)) / 2;
                return double.IsInteger(n);
        }
    }

    /// <inheritdoc cref="IsTriangular(int)"/>
    public static bool IsTriangular(long number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
                var n = (-1 + Math.Sqrt(1 + 8 * number)) / 2;
                return double.IsInteger(n);
        }
    }

    /// <summary>
    /// Gets the <paramref name="n"/>th triangular number.
    /// </summary>
    /// <param name="n">The position of the triangular number.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="n"/> is negative.</exception>
    public static long Get(long n)
    {
        if (n < 0L)
        {
            throw new ArgumentOutOfRangeException(nameof(n), n, "The argument was negative.");
        }

        return n * (n + 1L) / 2L;
    }

    /// <summary>
    /// Generates all triangular numbers in ascending order.
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
    /// Generates triangular numbers between the <paramref name="start"/> position and <paramref name="end"/> position place (inclusive).
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