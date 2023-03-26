namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// A composite number is a positive integer that can be formed by multiplying two smaller positive integers.
/// Equivalently, it is a positive integer that has at least one divisor other than 1 and itself.
/// </summary>
public static class CompositeNumbers
{
    /// <summary>
    /// Generates all composite numbers in ascending order.
    /// </summary>
    /// <remarks>Enumeration should be stopped using linq.</remarks>
    public static IEnumerable<long> Generate()
    {
        yield return 4L;
        for (var number = 6L; true; number++)
        {
            if (!IsComposite(number))
            {
                continue;
            }

            yield return number;
        }
    }

    /// <summary>
    /// Find all composite values between a <paramref name="start"/> and <paramref name="end"/>.
    /// </summary>
    /// <remarks>
    /// If <paramref name="start"/> is greater than <paramref name="end"/>,
    /// the composite values are generated in descending order.
    /// </remarks>
    /// <param name="start">The start number that defines one point in the search space.</param>
    /// <param name="end">The end number that defines another point in the search space.</param>
    public static IEnumerable<long> Between(long start, long end)
    {
        start = long.Max(start, 3L);
        end = long.Max(end, 3L);
        var step = start < end ? 1L  : -1L;

        for (var number = start; number <= end; number += step)
        {
            if (!IsComposite(number))
            {
                continue;
            }

            yield return number;
        }
    }

    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is considered a composite number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a composite number; <see langword="false"/> otherwise.</returns>
    public static bool IsComposite(long number)
    {
        if (number > 3L && (number % 2L == 0L || number % 3L == 0L))
        {
            return true;
        }

        for (var i = 5L; i * i <= number; i += 6L)
        {
            if (number % i == 0L || number % (i + 2L) == 0L)
            {
                return true;
            }
        }

        return false;
    }
}