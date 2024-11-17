using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0041 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var largestPandigitalPrime = FindLargestPandigitalPrimeBetween();
        return Task.FromResult<Answer>(largestPandigitalPrime);
    }

    private static long FindLargestPandigitalPrimeBetween()
    {
        for (var numberOfDigits = 9; numberOfDigits > 0; numberOfDigits--)
        {
            var pandigitalNumbers = PandigitalNumbers.GenerateReverse(numberOfDigits);
            var pandigitalPrimeNumbers = pandigitalNumbers.Where(PrimeNumbers.IsPrime);
            
            var highestPandigitalNumber = pandigitalPrimeNumbers.FirstOrDefault();
            if (highestPandigitalNumber == 0)
            {
                continue;
            }

            return highestPandigitalNumber;
        }

        throw new InvalidOperationException("It appears the largest pandigital prime does not exist.");
    }
}