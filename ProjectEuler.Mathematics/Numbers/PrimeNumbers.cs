namespace ProjectEuler.Mathematics.Numbers;

public static class PrimeNumbers
{
    /// <summary>
    /// Generates prime numbers indefinitely, in ascending order.
    /// </summary>
    /// <remarks>Enumeration must be stopped using linq.</remarks>
    public static IEnumerable<long> Generate()
    {
        yield return 2;

        for (var number = 3;; number += 2)
        {
            if (!IsPrime(number))
            {
                continue;
            }

            yield return number;
        }
    }

    /// <summary>
    /// Find all prime values between a <paramref name="minimum"/> and <paramref name="maximum"/>, in ascending order.
    /// </summary>
    /// <param name="minimum">The minimum number that defines the lower bound of the search space.</param>
    /// <param name="maximum">The maximum number that defines the upper bound of the search space.</param>
    public static IEnumerable<long> Between(long minimum, long maximum)
    {
        if (minimum > maximum)
        {
            throw new ArgumentException("The minimum was greater than the maximum.", nameof(minimum));
        }

        if (minimum == maximum && IsPrime(maximum))
        {
            yield return maximum;
            yield break;
        }

        if (minimum <= 2)
        {
            yield return 2;
            minimum = 3;
        }
        else if (long.IsEvenInteger(minimum))
        {
            minimum++;
        }

        for (var number = minimum; number <= maximum; number += 2L)
        {
            if (!IsPrime(number))
            {
                continue;
            }

            yield return number;
        }
    }

    /// <summary>
    /// Find all prime values between a <paramref name="maximum"/> and <paramref name="minimum"/>, in descending order.
    /// </summary>
    /// <param name="minimum">The minimum number that defines the lower bound of the search space.</param>
    /// <param name="maximum">The maximum number that defines the upper bound of the search space.</param>
    public static IEnumerable<long> BetweenReversed(long maximum, long minimum)
    {
        if (maximum < minimum)
        {
            throw new ArgumentException("The maximum was less than the minimum.", nameof(maximum));
        }

        if (maximum == 2)
        {
            yield return 2;
            yield break;
        }

        if (minimum == maximum && IsPrime(maximum))
        {
            yield return maximum;
            yield break;
        }

        if (long.IsEvenInteger(maximum))
        {
            maximum--;
        }

        for (var number = maximum; number >= minimum; number -= 2L)
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
        if (number is 2 or 3)
        {
            return true;
        }

        if (number < 2 || number % 2 == 0 || number % 3 == 0)
        {
            return false;
        }

        for (var i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }
}