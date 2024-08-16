namespace ProjectEuler.Extensions.Numbers;

public static class LongExtensions
{
    /// <summary>
    /// Returns the length of the number (i.e. the number of digits).
    /// </summary>
    /// <param name="number">The number.</param>
    public static int Length(this long number)
    {
        return number < 0L ? LengthOfNegativeNumber(number) : LengthOfPositiveNumber(number);

        static int LengthOfPositiveNumber(long number)
        {
            return number switch
            {
                < 10L => 1,
                < 100L => 2,
                < 1000L => 3,
                < 10000L => 4,
                < 100000L => 5,
                < 1000000L => 6,
                < 10000000L => 7,
                < 100000000L => 8,
                < 1000000000L => 9,
                < 10000000000L => 10,
                < 100000000000L => 11,
                < 1000000000000L => 12,
                < 10000000000000L => 13,
                < 100000000000000L => 14,
                < 1000000000000000L => 15,
                < 10000000000000000L => 16,
                < 100000000000000000L => 17,
                < 1000000000000000000L => 18,
                _ => 19
            };
        }

        static int LengthOfNegativeNumber(long number)
        {
            return number switch
            {
                > -10L => 1,
                > -100L => 2,
                > -1000L => 3,
                > -10000L => 4,
                > -100000L => 5,
                > -1000000L => 6,
                > -10000000L => 7,
                > -100000000L => 8,
                > -1000000000L => 9,
                > -10000000000L => 10,
                > -100000000000L => 11,
                > -1000000000000L => 12,
                > -10000000000000L => 13,
                > -100000000000000L => 14,
                > -1000000000000000L => 15,
                > -10000000000000000L => 16,
                > -100000000000000000L => 17,
                > -1000000000000000000L => 18,
                _ => 19
            };
        }
    }

    /// <summary>
    /// Returns each digit in the number.
    /// </summary>
    /// <param name="number">The number that contains digits.</param>
    public static IEnumerable<int> Digits(this long number)
    {
        if (number == 0)
        {
            yield return 0;
            yield break;
        }

        number = Math.Abs(number);

        var divisor = 1L;
        while (number / divisor >= 10)
        {
            divisor *= 10;
        }

        while (divisor > 0)
        {
            yield return (int)(number / divisor);
            number %= divisor;
            divisor /= 10;
        }
    }
}