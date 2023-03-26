namespace ProjectEuler.Mathematics.Numbers;

public static class PrimeFactors
{
    /// <summary>
    /// A prime factor is a prime that divides another number, leaving no remainder.
    /// </summary>
    public static IEnumerable<long> DistinctOf(long number)
    {
        return Of(number).Distinct();
    }

    /// <summary>
    /// Finds and returns the prime factors of the specified <paramref name="number"/>.
    /// </summary>
    /// <param name="number">The number.</param>
    public static IEnumerable<long> Of(long number)
    {
        if (number < 2L)
        {
            yield break;
        }

        if (PrimeNumbers.IsPrime(number))
        {
            yield return number;
            yield break;
        }

        foreach (var prime in PrimeNumbers.Generate())
        {
            while (number != prime)
            {
                var quotient = Math.DivRem(number, prime, out var remainder);
                if (remainder != 0)
                {
                    break;
                }

                yield return prime;
                number = quotient;
            }
            
            if (number != prime)
            {
                continue;
            }

            yield return prime;
            break;
        }
    }
}