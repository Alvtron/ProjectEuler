using System.Numerics;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

public class Solver_0025 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        const int NUMBER_OF_DIGITS = 1000;
        var index = 0;

        foreach (var fibonacciNumber in FibonacciNumbers.Generate())
        {
            if (NumberOfDigitsOf(fibonacciNumber) == NUMBER_OF_DIGITS)
            {
                return await Task.FromResult(index);
            }

            index++;
        }

        return await Task.FromResult(Answer.Empty);
    }

    private static int NumberOfDigitsOf(BigInteger number)
    {
            
        return (int)BigInteger.Log10(number) + 1;
    }
}