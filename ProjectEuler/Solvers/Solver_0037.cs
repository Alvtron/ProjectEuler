using System.Linq;
using ProjectEuler.Extensions;
using ProjectEuler.Library;
using ProjectEuler.Numerics;

namespace ProjectEuler.Solvers;

public class Solver_0037 : ISolver
{
    public Answer Solve()
    {
        return Enumerable
            .Range(10, int.MaxValue - 10)
            .Where(IsTrunctable)
            .Take(11)
            .Sum();
    }

    private bool IsTrunctable(int number)
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