namespace ProjectEuler.Mathematics.Numbers;

public static class CombinedNumbers
{
    /// <summary>
    /// Combines (concatenates) two integers into one.
    /// </summary>
    /// <param name="first">The first integer.</param>
    /// <param name="second">The second integer.</param>
    /// <exception cref="ArgumentException">Thrown if the numbers are a mix of positive and negative integers.</exception>
    public static long Combine(int first, int second)
    {
        var firstIsPositive = int.IsPositive(first);
        var secondIsPositive = int.IsPositive(second);
        if (firstIsPositive != secondIsPositive && (first != 0 && second != 0))
        {
            throw new ArgumentException("Cannot combine positive and negative numbers.");
        }

        return firstIsPositive 
            ? CombinePositiveIntegers(first, second)
            : CombineNegativeIntegers(first, second);
    }

    /// <summary>
    /// Combines (concatenates) three integers into one.
    /// </summary>
    /// <param name="first">The first integer.</param>
    /// <param name="second">The second integer.</param>
    /// <param name="third">The third integer.</param>
    /// <exception cref="ArgumentException">Thrown if the numbers are a mix of positive and negative integers.</exception>
    public static long Combine(int first, int second, int third)
    {
        return Combine(Combine(first, second), third);
    }

    /// <summary>
    /// Combines (concatenates) four integers into one.
    /// </summary>
    /// <param name="first">The first integer.</param>
    /// <param name="second">The second integer.</param>
    /// <param name="third">The third integer.</param>
    /// <param name="fourth">The fourth integer.</param>
    /// <exception cref="ArgumentException">Thrown if the numbers are a mix of positive and negative integers.</exception>
    public static long Combine(int first, int second, int third, int fourth)
    {
        return Combine(Combine(Combine(first, second), third), fourth);
    }

    /// <summary>
    /// Combines (concatenates) multiple integers into one.
    /// </summary>
    /// <param name="numbers">The numbers to combine.</param>
    /// <exception cref="ArgumentException">Thrown if the numbers are a mix of positive and negative integers.</exception>
    public static long Combine(IEnumerable<int> numbers)
    {
        return numbers.Aggregate(0L, (current, number) => Combine(current, number));
    }

    /// <summary>
    /// Combines (concatenates) two longs into one.
    /// </summary>
    /// <param name="first">The first long.</param>
    /// <param name="second">The second long.</param>
    /// <exception cref="ArgumentException">Thrown if the numbers are a mix of positive and negative longs.</exception>
    public static long Combine(long first, long second)
    {
        var firstIsPositive = long.IsPositive(first);
        var secondIsPositive = long.IsPositive(second);
        if (firstIsPositive != secondIsPositive && (first != 0 && second != 0))
        {
            throw new ArgumentException("Cannot combine positive and negative numbers.");
        }

        return firstIsPositive
            ? CombinePositiveLongs(first, second)
            : CombineNegativeLongs(first, second);
    }

    /// <summary>
    /// Combines (concatenates) three longs into one.
    /// </summary>
    /// <param name="first">The first long.</param>
    /// <param name="second">The second long.</param>
    /// <param name="third">The third long.</param>
    /// <exception cref="ArgumentException">Thrown if the numbers are a mix of positive and negative longs.</exception>
    public static long Combine(long first, long second, long third)
    {
        return Combine(Combine(first, second), third);
    }

    /// <summary>
    /// Combines (concatenates) four longs into one.
    /// </summary>
    /// <param name="first">The first long.</param>
    /// <param name="second">The second long.</param>
    /// <param name="third">The third long.</param>
    /// <param name="fourth">The fourth long.</param>
    /// <exception cref="ArgumentException">Thrown if the numbers are a mix of positive and negative longs.</exception>
    public static long Combine(long first, long second, long third, long fourth)
    {
        return Combine(Combine(Combine(first, second), third), fourth);
    }

    /// <summary>
    /// Combines (concatenates) multiple longs into one.
    /// </summary>
    /// <param name="numbers">The numbers to combine.</param>
    /// <exception cref="ArgumentException">Thrown if the numbers are a mix of positive and negative longs.</exception>
    public static long Combine(IEnumerable<long> numbers)
    {
        return numbers.Aggregate(0L, Combine);
    }

    private static long CombinePositiveIntegers(int first, int second)
    {
        return second switch
        {
            < 10 => 10L * first + second,
            < 100 => 100L * first + second,
            < 1000 => 1000L * first + second,
            < 10000 => 10000L * first + second,
            < 100000 => 100000L * first + second,
            < 1000000 => 1000000L * first + second,
            < 10000000 => 10000000L * first + second,
            < 100000000 => 100000000L * first + second,
            _ => 1000000000L * first + second
        };
    }

    private static long CombineNegativeIntegers(int first, int second)
    {
        return second switch
        {
            > -10 => 10L * first + second,
            > -100 => 100L * first + second,
            > -1000 => 1000L * first + second,
            > -10000 => 10000L * first + second,
            > -100000 => 100000L * first + second,
            > -1000000 => 1000000L * first + second,
            > -10000000 => 10000000L * first + second,
            > -100000000 => 100000000L * first + second,
            _ => 1000000000L * first + second
        };
    }

    private static long CombinePositiveLongs(long first, long second)
    {
        return second switch
        {
            < 10L => 10L * first + second,
            < 100L => 100L * first + second,
            < 1000L => 1000L * first + second,
            < 10000L => 10000L * first + second,
            < 100000L => 100000L * first + second,
            < 1000000L => 1000000L * first + second,
            < 10000000L => 10000000L * first + second,
            < 100000000L => 100000000L * first + second,
            < 1000000000L => 1000000000L * first + second,
            < 10000000000L => 10000000000L * first + second,
            < 100000000000L => 100000000000L * first + second,
            < 1000000000000L => 1000000000000L * first + second,
            < 10000000000000L => 10000000000000L * first + second,
            < 100000000000000L => 100000000000000L * first + second,
            < 1000000000000000L => 1000000000000000L * first + second,
            < 10000000000000000L => 10000000000000000L * first + second,
            < 100000000000000000L => 100000000000000000L * first + second,
            _ => 1000000000000000000L * first + second
        };
    }

    private static long CombineNegativeLongs(long first, long second)
    {
        return second switch
        {
            > -10L => 10L * first + second,
            > -100L => 100L * first + second,
            > -1000L => 1000L * first + second,
            > -10000L => 10000L * first + second,
            > -100000L => 100000L * first + second,
            > -1000000L => 1000000L * first + second,
            > -10000000L => 10000000L * first + second,
            > -100000000L => 100000000L * first + second,
            > -1000000000L => 1000000000L * first + second,
            > -10000000000L => 10000000000L * first + second,
            > -100000000000L => 100000000000L * first + second,
            > -1000000000000L => 1000000000000L * first + second,
            > -10000000000000L => 10000000000000L * first + second,
            > -100000000000000L => 100000000000000L * first + second,
            > -1000000000000000L => 1000000000000000L * first + second,
            > -10000000000000000L => 10000000000000000L * first + second,
            > -100000000000000000L => 100000000000000000L * first + second,
            _ => 1000000000000000000L * first + second
        };
    }
}