using ProjectEuler.Extensions.Collections;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

public class Solver_0047 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var firstConsecutiveNumber = FindConsecutiveNumbersWithDistinctPrimeFactors(4, 4).First();
        return await Task.FromResult(firstConsecutiveNumber);
    }

    private static IEnumerable<int> FindConsecutiveNumbersWithDistinctPrimeFactors(int numberOfConsecutiveNumbers, int numberOfDistinctPrimes)
    {
        for (var number = 2*3*5*7; number < int.MaxValue; number++)
        {
            var startNumber = number; 
            var primeFactors = PrimeFactors.DistinctOf(number);
            while (primeFactors.CountEquals(numberOfDistinctPrimes))
            {
                number++;
                primeFactors = PrimeFactors.DistinctOf(number);
            }

            if (number - startNumber < numberOfConsecutiveNumbers)
            {
                continue;
            }

            return Enumerable.Range(startNumber, numberOfConsecutiveNumbers);
        }

        return Enumerable.Empty<int>();
    }
}