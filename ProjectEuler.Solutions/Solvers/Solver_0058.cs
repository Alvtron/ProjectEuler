using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0058 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sideLength = FindSideLengthWithPrimeRatio(0.1);
        return Task.FromResult<Answer>(sideLength);
    }

    private static int FindSideLengthWithPrimeRatio(double ratio)
    {
        var primeCount = 0;
        var totalCount = 1;
        var sideLength = 1;

        for (var spiralLevel = 2; ; spiralLevel += 2)
        {
            for (var corner = 0; corner < 4; corner++)
            {
                totalCount++;
                sideLength += spiralLevel;

                if (PrimeNumbers.IsPrime(sideLength))
                {
                    primeCount++;
                }
            }

            if (primeCount / (double)totalCount < ratio)
            {
                return spiralLevel + 1;
            }
        }
    }
}
