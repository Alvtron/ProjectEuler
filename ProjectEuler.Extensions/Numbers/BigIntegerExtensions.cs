using System.Numerics;

namespace ProjectEuler.Extensions.Numbers;

public static class BigIntegerExtensions
{
    /// <summary>
    /// Returns the number of digits in the specified number.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static int Length(this BigInteger number)
    {
        if (number.IsZero)
        {
            return 1;
        }

        return (int)Math.Ceiling(BigInteger.Log10(BigInteger.Abs(number))) + 1;
    }

    /// <summary>
    /// Returns the digits of the specified number.
    /// </summary>
    public static IEnumerable<int> Digits(this BigInteger number)
    {
        if (number.IsZero)
        {
            yield return 0;
        }

        var sign = number.Sign;
        number = BigInteger.Abs(number);

        while (number > 0)
        {
            yield return (int)(sign * number % 10);
            number /= 10;
        }
    }

    /// <summary>
    /// Returns the first <paramref name="count"/> digits of the specified number as a new number.
    /// </summary>
    /// <param name="number">The number to get the first digits from.</param>
    /// <param name="count">The number of digits to get.</param>
    public static BigInteger FirstDigits(this BigInteger number, int count)
    {
        if (count < 1)
        {
            throw new ArgumentException("The count must at least be 1.", nameof(count));
        }

        if (number.IsZero)
        {
            return number;
        }

        var sign = number.Sign;
        number = BigInteger.Abs(number);

        var numberOfDigits = number.Length();

        return numberOfDigits < count
            ? sign * number
            : sign * BigInteger.Abs(number) / (int) Math.Pow(10, numberOfDigits - count - 1);
    }

    /// <summary>
    /// Returns the last <paramref name="count"/> digits of the specified number as a new number.
    /// </summary>
    /// <param name="number">The number to get the last digits from.</param>
    /// <param name="count">The number of digits to get.</param>
    public static BigInteger LastDigits(this BigInteger number, int count)
    {
        if (count < 1)
        {
            throw new ArgumentException("The count must at least be 1.", nameof(count));
        }

        if (number.IsZero)
        {
            return number;
        }

        var sign = number.Sign;

        return sign * BigInteger.Abs(number) % (int)Math.Pow(10, count);
    }
}