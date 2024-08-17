using System.Numerics;

namespace ProjectEuler.Mathematics.Combinatorics
{
    public static class Factorial
    {
        /// <summary>
        /// Returns the factorial of the specified <paramref name="n"/>.
        /// </summary>
        /// <param name="n">The number to calculate the factorial of.</param>
        public static BigInteger Of(int n)
        {
            var result = BigInteger.One;

            for (var i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        /// <summary>
        /// Returns the factorial of the specified <paramref name="n"/>.
        /// </summary>
        /// <param name="n">The number to calculate the factorial of.</param>
        public static BigInteger Of(long n)
        {
            var result = BigInteger.One;

            for (var i = 2L; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        /// <summary>
        /// Returns the factorial of the specified <paramref name="n"/>.
        /// </summary>
        /// <param name="n">The number to calculate the factorial of.</param>
        public static BigInteger Of(BigInteger n)
        {
            var result = BigInteger.One;

            for (var i = new BigInteger(2); i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
