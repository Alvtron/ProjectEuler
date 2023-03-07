namespace ProjectEuler.Mathematics.Numbers;

public static class PrimeNumbers
{
    public static IEnumerable<long> Generate()
    {
        for (var number = 1L; true; number++)
        {
            if (!IsPrime(number))
            {
                continue;
            }

            yield return number;
        }
    }

    public static bool IsPrime(long number)
    {
        if (long.IsNegative(number))
        {
            return false;
        }

        switch (number)
        {
            case 0:
                return false;
            case 1:
                return false;
            case 2:
                return true;
        }

        var limit = (long)Math.Ceiling(Math.Sqrt(number));

        for (var divisor = 2L; divisor <= limit; ++divisor)
        {
            if (number % divisor == 0L)
            {
                return false;
            }
        }

        return true;
    }
}