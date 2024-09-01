using System.Numerics;

namespace ProjectEuler.Mathematics.Numbers;

public static class LychrelNumbers
{
    private const long FIRST_KNOWN_LYCHREL_NUMBER = 196;
    private const int DEFAULT_MAX_ITERATIONS = 50;

    public static IEnumerable<long> Generate(int maxIterations = DEFAULT_MAX_ITERATIONS)
    {
        ThrowIfInvalidMaxIterations(maxIterations);

        for (var number = new BigInteger(FIRST_KNOWN_LYCHREL_NUMBER);; number++)
        {
            if (IsLychrelNumber(number, maxIterations))
            {
                yield return (long)number;
            }
        }
    }

    public static IEnumerable<long> Between(long start, long end, int maxIterations = DEFAULT_MAX_ITERATIONS)
    {
        ThrowIfInvalidMaxIterations(maxIterations);

        if (start < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(start), start, "Start cannot be was negative.");
        }

        if (start > end)
        {
            throw new ArgumentOutOfRangeException(nameof(start), start, "Start cannot be greater than end.");
        }

        if (end < FIRST_KNOWN_LYCHREL_NUMBER)
        {
            yield break;
        }

        if (start < FIRST_KNOWN_LYCHREL_NUMBER)
        {
            start = FIRST_KNOWN_LYCHREL_NUMBER;
        }

        for (var number = start; number <= end; number++)
        {
            if (IsLychrelNumber(new BigInteger(number), maxIterations))
            {
                yield return number;
            }
        }
    }

    public static bool IsLychrelNumber(long number, int maxIterations = DEFAULT_MAX_ITERATIONS)
    {
        ThrowIfInvalidMaxIterations(maxIterations);

        return number >= FIRST_KNOWN_LYCHREL_NUMBER && IsLychrelNumber(new BigInteger(number), maxIterations);
    }

    private static bool IsLychrelNumber(BigInteger number, int maxIterations)
    {
        for (var i = 0; i < maxIterations; i++)
        {
            number += ReverseNumber(number);

            if (IsPalindrome(number))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsPalindrome(BigInteger number)
    {
        return number == ReverseNumber(number);
    }

    private static BigInteger ReverseNumber(BigInteger number)
    {
        var reversedNumber = BigInteger.Zero;

        while (number > 0)
        {
            reversedNumber = reversedNumber * 10 + number % 10;
            number /= 10;
        }

        return reversedNumber;
    }

    private static void ThrowIfInvalidMaxIterations(int maxIterations)
    {
        if (maxIterations < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(maxIterations), maxIterations, "Max iterations must be greater than zero.");
        }
    }
}
