using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

public class Solver_0037 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sumOfTrunctablePrimes = Enumerable
            .Range(10, int.MaxValue - 10)
            .Where(IsTrunctable)
            .Take(11)
            .Sum();
        
        return await Task.FromResult(sumOfTrunctablePrimes);
    }

    private static bool IsTrunctable(int number)
    {
        if (!PrimeNumbers.IsPrime(number))
        {
            return false;
        }
        
        var numberLength = number.Length();

        for (var truncateLength = 1; truncateLength < numberLength; truncateLength++)
        {
            var firstDigits = number.FirstDigits(truncateLength);
            if (!PrimeNumbers.IsPrime(firstDigits))
            {
                return false;
            }

            var lastDigits = number.LastDigits(truncateLength);
            if (!PrimeNumbers.IsPrime(lastDigits))
            {
                return false;
            }
        }

        return true;
    }
}