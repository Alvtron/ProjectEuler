using ProjectEuler.Library;

namespace ProjectEuler.Solvers;

public class Solver_0002 : ISolver
{
    private const int LIMIT = 4000000;

    public Answer Solve()
    {
        return SumOfEvenFibonacciNumbers(LIMIT);
    }

    private static long SumOfEvenFibonacciNumbers(int limit)
    {
        var first = 1;
        var second = 2;
        var sum = second;
        do
        {
            var secondCopy = second;
            second = first + second;
            first = secondCopy;
            if (second % 2 == 0)
            {
                sum += second;
            }
        } while (second <= limit);
        return sum;
    }
}