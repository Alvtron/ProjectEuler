namespace ProjectEuler.Mathematics.Numbers;

public static class PrimeNumbers
{
    /// <summary>
    /// Generates all prime numbers in ascending order.
    /// </summary>
    /// <remarks>Enumeration should be stopped using linq.</remarks>
    public static IEnumerable<long> Generate()
    {
        yield return 2L;
        for (var number = 3L; true; number += 2L)
        {
            if (!IsPrime(number))
            {
                continue;
            }

            yield return number;
        }
    }

    /// <summary>
    /// Find all prime numbers between a <paramref name="start"/> and <paramref name="end"/>.
    /// </summary>
    /// <remarks>
    /// If <paramref name="start"/> is greater than <paramref name="end"/>,
    /// the prime numbers are generated in descending order.
    /// </remarks>
    /// <param name="start">The start number that defines one point in the search space.</param>
    /// <param name="end">The end number that defines another point in the search space.</param>
    public static IEnumerable<long> Between(long start, long end)
    {
        if (start < 2L && end < 2L)
        {
            yield break;
        }

        start = long.Max(start, 1L);
        end = long.Max(end, 1L);

        var step = start < end ? 2L : -2L;
        if (start <= 2L)
        {
            yield return 2L;

            if (start < end)
            {
                start = 3L;
            }
        }
        else if (long.IsEvenInteger(start))
        {
            start += step / 2L;
        }

        for (var number = start; number <= end; number += step)
        {
            if (!IsPrime(number))
            {
                continue;
            }

            yield return number;
        }
    }

    /// <summary>
    /// Determines whether the specified <paramref name="number"/> is considered a prime number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is a prime number; <see langword="false"/> otherwise.</returns>
    public static bool IsPrime(long number)
    {
        if (number is 2L or 3L)
        {
            return true;
        }

        if (number < 2L || number % 2L == 0L || number % 3L == 0L)
        {
            return false;
        }

        for (var i = 5L; i * i <= number; i += 6L)
        {
            if (number % i == 0L || number % (i + 2L) == 0L)
            {
                return false;
            }
        }

        return true;
    }
}