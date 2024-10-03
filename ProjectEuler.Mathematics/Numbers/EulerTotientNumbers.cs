namespace ProjectEuler.Mathematics.Numbers;

/// <summary>
/// A totient number is a value of Euler's totient function.
/// The Euler totient function, also known as Euler's totient function or Euler's phi function,
/// counts the positive integers up to a given integer n that are relatively prime to n.
/// </summary>
public static class EulerTotientNumbers
{
    /// <summary>
    /// Generates Euler totient numbers for all integers between 1 up to the specified limit.
    /// </summary>
    /// <param name="limit">The limit.</param>
    /// <returns>The Euler totient numbers for all integers between 1 up to the specified limit.</returns>
    public static long[] Generate(long limit)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(limit);

        var phis = new long[limit];
        for (var n = 1; n <= limit; n++)
        {
            phis[n - 1] = n;
        }

        for (var p = 2L; p <= limit; p++)
        {
            if (phis[p - 1] != p)
            {
                continue;
            }

            // p is prime
            for (var k = p; k <= limit; k += p)
            {
                phis[k - 1] -= phis[k - 1] / p;
            }
        }

        return phis;
    }
}