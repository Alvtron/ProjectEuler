﻿using ProjectEuler.Mathematics.Combinatorics;

namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// Pandigital numbers are numbers containing the digits 0-9 where each digit appears exactly once.
/// </summary>
public static class PandigitalNumbers
{
    /// <summary>
    /// The smallest pandigital number.
    /// </summary>
    public const long Smallest = 1023456789;

    /// <summary>
    /// The smallest zero-less pandigital number.
    /// </summary>
    public const long SmallestZeroLess = 123456789;

    /// <summary>
    /// The largest pandigital number.
    /// </summary>
    public const long Largest = 9876543210;

    /// <summary>
    /// The largest zero-less pandigital number.
    /// </summary>
    public const long LargestZeroLess = 987654321;

    /// <summary>
    /// Determines whether the number is pandigital in base 10.
    /// Pandigital numbers contains the digits 0-9, where each digit appears exactly once.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is pandigital; <see langword="false"/> otherwise.</returns>
    public static bool IsPandigital(long number)
    {
        if (number is < Smallest or > Largest)
        {
            return false;
        }

        long digits = 0;

        for (; number > 0; number /= 10)
        {
            digits |= 1L << (int)(number - number / 10L * 10L);
        }

        return digits == 1023;
    }

    /// <summary>
    /// Determines whether the number is a zero-less pandigital in base 10.
    /// Zero-less pandigital numbers contains the digits 1-9, where each digit appears exactly once.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> if the number is zero-less pandigital; <see langword="false"/> otherwise.</returns>
    public static bool IsZeroLessPandigital(long number)
    {
        if (number != 9 * (int)((0x1c71c71dL * number) >> 32))
            return false;

        var flags = 0;
        while (number > 0)
        {
            var q = (int)((0x1999999aL * number) >> 32);
            flags |= 1 << (int)(number - q * 10);
            number = q;
        }

        return flags == 0x3fe;
    }

    /// <summary>
    /// Generates all pandigital numbers containing the specified <paramref name="numberOfDigits"/>.
    /// </summary>
    /// <param name="numberOfDigits">The number of digits, or length, in the generated pandigital numbers.</param>
    /// <exception cref="ArgumentException">Thrown if the number of digits is below 1 or higher than 9.</exception>
    public static IEnumerable<long> Generate(int numberOfDigits)
    {
        return numberOfDigits switch
        {
            < 1 => throw new ArgumentException("The number of digits was lower than 1.", nameof(numberOfDigits)),
            > 9 => throw new ArgumentException("The number of digits was greater than 9.", nameof(numberOfDigits)),
            _ => Permutations.Of(Enumerable.Range(1, numberOfDigits)).Select(CombinedNumbers.Combine)
        };
    }

    /// <summary>
    /// Generates all pandigital numbers containing the specified <paramref name="numberOfDigits"/>, in reverse order.
    /// </summary>
    /// <param name="numberOfDigits">The number of digits, or length, in the generated pandigital numbers.</param>
    /// <exception cref="ArgumentException">Thrown if the number of digits is below 1 or higher than 9.</exception>
    public static IEnumerable<long> GenerateReverse(int numberOfDigits)
    {
        return numberOfDigits switch
        {
            < 1 => throw new ArgumentException("The number of digits was lower than 1.", nameof(numberOfDigits)),
            > 9 => throw new ArgumentException("The number of digits was greater than 9.", nameof(numberOfDigits)),
            _ => Permutations.Of(Enumerable.Range(1, numberOfDigits).Reverse()).Select(CombinedNumbers.Combine)
        };
    }
}