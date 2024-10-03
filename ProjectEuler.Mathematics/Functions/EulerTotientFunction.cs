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
    /// <param name="number">The number to calculate the Euler totient function for.</param>
    /// <returns>The Euler totient function of the specified number.</returns>
    public static int Calculate(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        var result = number;
        var p = 2;

        // Loop over potential factors
        while (p * p <= number)
        {
            // Check if p is a factor of n
            if (number % p == 0)
            {
                // Divide n by p as long as it's divisible
                while (number % p == 0)
                {
                    number /= p;
                }

                // Update the result by removing the factor p
                result -= result / p;
            }

            p++;
        }

        // If n is still greater than 1, it must be prime
        if (number > 1)
        {
            result -= result / number;
        }

        return result;
    }
}