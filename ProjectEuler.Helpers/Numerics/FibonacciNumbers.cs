using System.Numerics;

namespace ProjectEuler.Helpers.Numerics;

/// <summary>
/// The Fibonacci sequence is a series of numbers where a number is the addition of the last two numbers, starting with 0 and 1.
/// </summary>
public static class FibonacciNumbers
{
    /// <summary>
    /// Generates a sequence of Fibonacci numbers until explicitly stopped, starting from zero.
    /// </summary>
    public static IEnumerable<BigInteger> Generate()
    {
        var previous = BigInteger.Zero;
        var current = BigInteger.One;

        yield return previous;
        yield return current;

        while (true)
        {
            var next = previous + current;

            previous = current;
            current = next;

            yield return next;
        }
    }
}