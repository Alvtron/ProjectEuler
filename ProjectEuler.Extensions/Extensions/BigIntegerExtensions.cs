using System.Numerics;

namespace ProjectEuler.Extensions.Extensions;

public static class BigIntegerExtensions
{
    public static int Length(this BigInteger number)
    {
        if (number.IsZero)
        {
            return 1;
        }

        return (int)Math.Ceiling(BigInteger.Log10(BigInteger.Abs(number))) + 1;
    }

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