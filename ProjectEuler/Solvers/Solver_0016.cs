using System.Linq;
using System.Numerics;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers;

public class Solver_0016 : ISolver
{
    public Answer Solve()
    {
        var number = BigInteger.Pow(2, 1000);
        return SumOfDigits(number);
    }

    private static int SumOfDigits(BigInteger number)
    {
        return number.ToString().Select(digit => (int)char.GetNumericValue(digit)).Sum();
    }
}