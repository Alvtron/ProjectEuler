using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0027 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var quadraticPrimeProduct = FindQuadraticPrimeProduct(-1000, 999, -1000, 1000);
        return Task.FromResult<Answer>(quadraticPrimeProduct);
    }

    private static long FindQuadraticPrimeProduct(long aMin, long aMax, long bMin, long bMax)
    {
        var highestNumberOfPrimes = 0L;
        var coefficients = (0L, 0L);

        for (var a = aMin; a <= aMax; a++)
        {
            for (var b = bMin; b <= bMax; b++)
            {
                var n = 0L;
                while (PrimeNumbers.IsPrime(Quadratic(n, a, b)))
                {
                    n++;
                }

                if (n < highestNumberOfPrimes)
                {
                    continue;
                }

                highestNumberOfPrimes = n;
                coefficients = (a, b);
            }
        }

        return coefficients.Item1 * coefficients.Item2;
    }

    private static long Quadratic(long n, long a, long b)
    {
        return n*n + a*n + b;
    }
}