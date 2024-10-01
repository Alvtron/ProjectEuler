using ProjectEuler.Extensions.Numbers;

namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// A cyclic number is an integer in which cyclic permutations of the digits are successive multiples of the number.
/// </summary>
public static class CyclicNumbers
{
    /// <summary>
    /// Generates all cyclic numbers of a given number.
    /// </summary>
    /// <param name="number">The number to generate cyclic numbers.</param>
    public static IEnumerable<long> CycleLeft(long number)
    {
        yield return number;

        var numberLength = number.Length();
        for (var i = 1; i < numberLength; i++)
        {
            var rotatedNumber = RotateLeft(number);
            if (AreCyclic(number, rotatedNumber))
            {
                yield return rotatedNumber;
            }

            number = rotatedNumber;
        }
    }

    /// <summary>
    /// Generates all cyclic numbers of a given number.
    /// </summary>
    /// <param name="number">The number to generate cyclic numbers.</param>
    public static IEnumerable<long> CycleRight(long number)
    {
        yield return number;

        var numberLength = number.Length();
        for (var i = 1; i < numberLength; i++)
        {
            var rotatedNumber = RotateRight(number);
            if (AreCyclic(number, rotatedNumber))
            {
                yield return rotatedNumber;
            }

            number = rotatedNumber;
        }
    }

    /// <summary>
    /// Whether the two numbers are cyclic.
    /// </summary>
    /// <param name="firstNumber">The first number.</param>
    /// <param name="secondNumber">The second number.</param>
    /// <returns><see langword="true"/> if the numbers are cyclic; <see langword="false"/> otherwise.</returns>
    public static bool AreCyclic(long firstNumber, long secondNumber)
    {
        // If the numbers are the same, they can't be cyclic
        if (firstNumber == secondNumber)
        {
            return false;
        }

        var sign = long.Sign(firstNumber);
        if (sign != long.Sign(secondNumber))
        {
            return false;
        }

        firstNumber = long.Abs(firstNumber);
        secondNumber = long.Abs(secondNumber);

        // If the numbers have different lengths, they can't be cyclic
        var numberLength = firstNumber.Length();
        if (numberLength != secondNumber.Length())
        {
            return false;
        }

        // Check for cyclic rotations
        var rotatedNumber = firstNumber;
        for (var i = 0; i < numberLength; i++)
        {
            rotatedNumber = RotateLeft(rotatedNumber);
            if (rotatedNumber == secondNumber)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Rotates the number to the left. 1234 -> 2341
    /// </summary>
    /// <param name="number">The number to rotate.</param>
    public static long RotateLeft(long number)
    {
        var sign = long.Sign(number);
        number = long.Abs(number);

        // If the number has only one digit, return it as is
        if (number < 10)
        {
            return number * sign;
        }

        // Find the number of digits in the number
        long divisor = 1;
        var temp = number;
        while (temp >= 10)
        {
            temp /= 10;
            divisor *= 10;
        }

        // Rotate the number: move the first digit to the end
        var firstDigit = number / divisor;
        var remaining = number % divisor;

        return (remaining * 10 + firstDigit) * sign;
    }

    /// <summary>
    /// Rotates the number to the right. 1234 -> 4123
    /// </summary>
    /// <param name="number">The number to rotate.</param>
    public static long RotateRight(long number)
    {
        var sign = long.Sign(number);
        number = long.Abs(number);

        // If the number has only one digit, return it as is
        if (number < 10)
        {
            return number * sign;
        }

        // Find the number of digits in the number
        long divisor = 1;
        var temp = number;
        while (temp >= 10)
        {
            temp /= 10;
            divisor *= 10;
        }

        // Rotate the number: move the last digit to the beginning
        var lastDigit = number % 10;
        var remaining = number / 10;

        return (lastDigit * divisor + remaining) * sign;
    }
}