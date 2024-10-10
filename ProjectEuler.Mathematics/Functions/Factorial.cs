using System.Numerics;

namespace ProjectEuler.Mathematics.Functions;

/// <summary>
/// The factorial of a non-negative integer n, denoted by n!, is the product of all positive integers less than or equal to n.
/// </summary>
public static class Factorial
{
    private static readonly int[] Factorials = [1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880];

    /// <summary>
    /// Returns the factorial of the specified <paramref name="number"/>.
    /// </summary>
    /// <param name="number">The number to calculate the factorial of.</param>
    public static BigInteger Of(int number)
    {
        var result = BigInteger.One;

        for (var n = 2; n <= number; n++)
        {
            result *= n;
        }

        return result;
    }

    /// <inheritdoc cref="Of(int)"/>
    public static BigInteger Of(long number)
    {
        var result = BigInteger.One;

        for (var n = 2L; n <= number; n++)
        {
            result *= n;
        }

        return result;
    }

    /// <inheritdoc cref="Of(int)"/>
    public static BigInteger Of(BigInteger number)
    {
        var result = BigInteger.One;

        for (var n = new BigInteger(2); n <= number; n++)
        {
            result *= n;
        }

        return result;
    }

    /// <summary>
    /// Calculates the sum of the factorials of the digits of the specified <paramref name="number"/>.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns>The sum of the factorials of the digits of the specified <paramref name="number"/>.</returns>
    public static int Sum(int number)
    {
        var sum = 0;
        while (number > 0)
        {
            var digit = number % 10;
            sum += Factorials[digit];
            number /= 10;
        }

        return sum;
    }

    /// <inheritdoc cref="Sum(int)"/>
    public static long Sum(long number)
    {
        var sum = 0L;
        while (number > 0)
        {
            var digit = (int)(number % 10L);
            sum += Factorials[digit];
            number /= 10L;
        }

        return sum;
    }

    /// <inheritdoc cref="Sum(int)"/>
    public static BigInteger Sum(BigInteger number)
    {
        var sum = BigInteger.Zero;
        var ten = new BigInteger(10);
        while (number > 0)
        {
            var digit = (int)(number % ten);
            sum += Factorials[digit];
            number /= ten;
        }

        return sum;
    }
}