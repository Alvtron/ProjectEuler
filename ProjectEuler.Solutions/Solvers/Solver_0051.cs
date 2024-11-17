using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;
using System.Collections;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0051 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<Answer>(FindFirstPrimeValueFamily(8));
    }

    private static long FindFirstPrimeValueFamily(int targetFamilySize)
    {
        foreach (var prime in PrimeNumbers.Generate())
        {
            var digits = prime.Digits().ToList();
            var patterns = BinaryNumbers.OfLength(digits.Count);

            foreach (var pattern in patterns)
            {
                var familyCount = 0;
                var smallestPrime = long.MaxValue;

                for (var digit = 0; digit <= 9; digit++)
                {
                    var candidate = ApplyPattern(digits, pattern, digit);

                    if (candidate < prime || !PrimeNumbers.IsPrime(candidate))
                    {
                        continue;
                    }

                    if (candidate < smallestPrime)
                    {
                        smallestPrime = candidate;
                    }

                    familyCount++;
                }

                if (familyCount == targetFamilySize)
                {
                    return smallestPrime;
                }
            }
        }

        throw new InvalidOperationException("No solution found.");
    }

    private static long ApplyPattern(List<int> digits, BitArray pattern, int digit)
    {
        var result = 0L;
        for (var i = 0; i < digits.Count; i++)
        {
            var d = pattern[i] ? digit : digits[i];
            result = result * 10 + d;
        }

        return result;
    }
}