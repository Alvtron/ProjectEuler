namespace ProjectEuler.Extensions.Numbers;

public static class IntegerExtensions
{
    /// <summary>
    /// Returns the length of the number (i.e. the number of digits).
    /// </summary>
    /// <param name="number">The number.</param>
    public static int Length(this int number)
    {
        static int LengthOfPositiveNumber(int number)
        {
            return number switch
            {
                < 10 => 1,
                < 100 => 2,
                < 1000 => 3,
                < 10000 => 4,
                < 100000 => 5,
                < 1000000 => 6,
                < 10000000 => 7,
                < 100000000 => 8,
                < 1000000000 => 9,
                _ => 10
            };
        }

        static int LengthOfNegativeNumber(int number)
        {
            return number switch
            {
                > -10 => 1,
                > -100 => 2,
                > -1000 => 3,
                > -10000 => 4,
                > -100000 => 5,
                > -1000000 => 6,
                > -10000000 => 7,
                > -100000000 => 8,
                > -1000000000 => 9,
                _ => 10
            };
        }

        return number < 0 ? LengthOfNegativeNumber(number) : LengthOfPositiveNumber(number);
    }

    /// <summary>
    /// Returns each digit in the number.
    /// </summary>
    /// <param name="number">The number that contains digits.</param>
    public static IEnumerable<int> Digits(this int number)
    {
        if (number == 0)
        {
            yield return 0;
            yield break;
        }

        number = Math.Abs(number);

        var numberLength = number.Length();

        for (var index = numberLength; index > 0; index--)
        {
            yield return number / (int)Math.Pow(10, index - 1) % 10;
        }
    }

    /// <summary>
    /// Returns the first digits in the number.
    /// </summary>
    /// <param name="number">The number that contains digits.</param>
    /// <param name="count">The number of digits to return.</param>
    public static int FirstDigits(this int number, int count)
    {
        if (count < 1)
        {
            return number;
        }

        var sign = Math.Sign(number);
        number = Math.Abs(number);

        var numberOfDigits = number.Length();
            
        return numberOfDigits < count
            ? sign * number
            : sign * (int)Math.Truncate(number / Math.Pow(10, numberOfDigits - count));
    }

    /// <summary>
    /// Returns the last digits in the number.
    /// </summary>
    /// <param name="number">The number that contains digits.</param>
    /// <param name="count">The number of digits to return.</param>
    public static int LastDigits(this int number, int count)
    {
        if (count < 1)
        {
            throw new ArgumentException("The count must at least be 1.", nameof(count));
        }

        if (number == 0)
        {
            return number;
        }

        var sign = Math.Sign(number);
        number = Math.Abs(number);

        return sign * number % (int)Math.Pow(10, count);
    }
}