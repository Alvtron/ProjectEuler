using System;

namespace ProjectEuler.Extensions;

public static class IntegerExtensions
{
    public static int Length(this int number)
    {
        if (number == 0)
        {
            return 1;
        }

        return (int)Math.Ceiling(Math.Log10(Math.Abs(number)));
    }

    public static int FirstDigits(this int number, int count)
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

        var numberOfDigits = number.Length();
            
        return numberOfDigits < count
            ? sign * number
            : sign * (int)Math.Truncate(number / Math.Pow(10, numberOfDigits - count));
    }

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