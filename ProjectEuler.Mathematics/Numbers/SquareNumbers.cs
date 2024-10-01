namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// A square number is a positive integer that can be formed by multiplying two smaller positive integers.
/// Equivalently, it is a positive integer that has at least one divisor other than 1 and itself.
/// </summary>
public static class SquareNumbers
{
    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is considered a perfect square.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a perfect square; <see langword="false"/> otherwise.</returns>
    public static bool IsSquare(int number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
                var sqrt = (long)Math.Sqrt(number);
                return sqrt * sqrt == number;
        }
    }

    /// <inheritdoc cref="IsSquare(int)"/>
    public static bool IsSquare(long number)
    {
        switch (number)
        {
            case < 0:
                return false;
            case 0:
                return true;
            default:
                var sqrt = (long)Math.Sqrt(number);
                return sqrt * sqrt == number;
        }
    }

    /// <summary>
    /// Gets the <paramref name="n"/>th square number.
    /// </summary>
    /// <param name="n">The position of the square number.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="n"/> is negative.</exception>
    public static long Get(long n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), n, "The argument was negative.");
        }

        return n * n;
    }

    /// <summary>
    /// Generates all perfect squares in ascending order.
    /// </summary>
    /// <remarks>Enumeration should be stopped using linq.</remarks>
    public static IEnumerable<long> Generate()
    {
        for (var number = 0L; number < long.MaxValue; number++)
        {
            yield return Get(number);
        }
    }

    /// <summary>
    /// Generates perfect square numbers between the <paramref name="start"/> position and <paramref name="end"/> position place (inclusive).
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