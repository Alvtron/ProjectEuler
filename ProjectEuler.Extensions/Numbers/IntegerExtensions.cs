namespace ProjectEuler.Extensions.Numbers;

public static class IntegerExtensions
{
    public static int Length(this int number)
    {
        if (number is 0)
        {
            return 1;
        }

        var positiveNumber = Math.Abs(number);
        var numberOfDigits = Math.Log10(positiveNumber + 1);

        return (int)Math.Ceiling(numberOfDigits);
    }

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