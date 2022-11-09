using System.Linq;
using System.Numerics;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers;

public class Solver_0020 : ISolver
{
    public Answer Solve()
    {
        var number = new BigInteger(100);
        var factorial = CalculateFactorial(number);

        return SumOfDigitsOf(factorial);
    }

    private static int SumOfDigitsOf(BigInteger number)
    {
        return number.ToString().Select(digit => (int)char.GetNumericValue(digit)).Sum();
    }

    private static BigInteger CalculateFactorial(BigInteger number)
    {
        var factorial = BigInteger.One;

        for (var digit = number; digit > BigInteger.One; digit--)
        {
            factorial *= digit;
        }

        return factorial;
    }
}