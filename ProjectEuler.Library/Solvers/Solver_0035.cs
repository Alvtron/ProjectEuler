using ProjectEuler.Extensions.Extensions;
using ProjectEuler.Helpers.Numerics;
using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0035 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var count = FindCircularPrimesBetween(0, 1_000_000);

        return await Task.FromResult(count);
    }

    private static int FindCircularPrimesBetween(int start, int end)
    {
        var count = 0;
        for (var number = start; number <= end; number++)
        {
            if (IsCircularPrime(number))
            {
                count++;
            }
        }

        return count;
    }

    private static bool IsCircularPrime(int number)
    {
        var numberLength = number.Length();
        var digits = number.Digits().ToArray();
        for (var digitIndex = 0; digitIndex < numberLength; digitIndex++)
        {
            var cycledNumber = Cycle(digits, digitIndex);

            if (!PrimeNumbers.IsPrime(cycledNumber))
            {
                return false;
            }
        }

        return true;
    }

    private static int Cycle(ReadOnlySpan<int> digits, int digitIndex)
    {
        var sum = 0;
        var exponent = digits.Length - 1;
        foreach (var digit in digits[digitIndex..])
        {
            sum += digit * (int)Math.Pow(10, exponent--);
        }

        foreach (var digit in digits[..digitIndex])
        {
            sum += digit * (int)Math.Pow(10, exponent--);
        }

        return sum;
    }
}