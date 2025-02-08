using System.Numerics;
using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0080 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var overallDigitSum = FindTotalDigitSumOfIrrationalSquareRoots(
            maxNumber: 100,
            totalDigitsToKeep: 100);

        return Task.FromResult<Answer>(overallDigitSum);
    }

    private static long FindTotalDigitSumOfIrrationalSquareRoots(int maxNumber, int totalDigitsToKeep)
    {
        var overallDigitSum = 0L;

        for (var number = 1; number <= maxNumber; number++)
        {
            if (SquareNumbers.IsSquare(number))
            {
                continue;
            }

            // Determine how many digits the integer part of sqrt(n) has.
            var integerPart = (int)Math.Floor(Math.Sqrt(number));
            var integerDigitCount = integerPart.Digits().Count();
            var fractionalDigitsNeeded = totalDigitsToKeep - integerDigitCount;

            // Compute floor( sqrt(n) * 10^(fractionalDigitsNeeded) )
            // by calculating floor( sqrt(n * 10^(2 * fractionalDigitsNeeded)) ).
            var scaledNumber = new BigInteger(number) * BigInteger.Pow(10, 2 * fractionalDigitsNeeded);
            var sqrtScaled = IntegerSquareRoot(scaledNumber);

            // Sum the digits without converting to a string.
            overallDigitSum += sqrtScaled.Digits().Sum();
        }

        return overallDigitSum;
    }

    /// <summary>
    /// Computes the integer square root (floor of the square root) of a nonnegative BigInteger using Newton's method.
    /// </summary>
    private static BigInteger IntegerSquareRoot(BigInteger n)
    {
        if (n < 0)
            throw new ArgumentException("Cannot compute the square root of a negative number.");

        if (n < 2)
            return n;

        var guess = BigInteger.One << ((GetBitLength(n) + 1) / 2);
        while (true)
        {
            var nextGuess = (guess + n / guess) >> 1;
            if (nextGuess >= guess)
                return guess;
            guess = nextGuess;
        }
    }

    /// <summary>
    /// Returns the number of bits required to represent the BigInteger n.
    /// </summary>
    private static int GetBitLength(BigInteger n)
    {
        var bytes = n.ToByteArray();
        var msb = bytes[^1];
        var bitsInMsb = 0;
        while (msb != 0)
        {
            bitsInMsb++;
            msb >>= 1;
        }
        return (bytes.Length - 1) * 8 + bitsInMsb;
    }
}
