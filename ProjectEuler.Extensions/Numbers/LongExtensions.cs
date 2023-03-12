namespace ProjectEuler.Extensions.Numbers;

public static class LongExtensions
{
    /// <summary>
    /// Returns the length of the number (i.e. the number of digits).
    /// </summary>
    /// <param name="number">The number.</param>
    public static int Length(this long number)
    {
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

        return number < 0L ? LengthOfNegativeNumber(number) : LengthOfPositiveNumber(number);
    }
}