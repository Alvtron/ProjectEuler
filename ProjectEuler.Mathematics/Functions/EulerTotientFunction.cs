namespace ProjectEuler.Mathematics.Functions;

/// <summary>
/// The Euler totient function, also known as Euler's totient function or Euler's phi function,
/// counts the positive integers up to a given integer n that are relatively prime to n.
/// </summary>
public static class EulerTotientFunction
{
    /// <summary>
    /// Calculates the Euler totient function of the specified number.
    /// </summary>
    /// <param name="n">The number to calculate the Euler totient function for.</param>
    /// <returns>The Euler totient function of the specified number.</returns>
    public static long Calculate(long n)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(n);

        if (n == 1)
        {
            return 1;
        }

        var result = n;
        // Check for the factor 2
        if (n % 2 == 0)
        {
            result -= result / 2;
            while (n % 2 == 0)
            {
                n /= 2;
            }
        }

        // Check for odd factors starting from 3
        for (long p = 3; p * p <= n; p += 2)
        {
            if (n % p == 0)
            {
                result -= result / p;
                while (n % p == 0)
                {
                    n /= p;
                }
            }
        }

        // If n is still greater than 1, it is prime
        if (n > 1)
        {
            result -= result / n;
        }

        return result;
    }
}