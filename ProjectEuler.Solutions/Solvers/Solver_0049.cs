using ProjectEuler.Solutions.Answers;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Extensions.Numbers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0049 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var permutations = FindPrimePermutations(1000, 9999, 3330);
        var permutation = permutations.FirstOrDefault(p => p.Item1 != 1487);
        var concatenation = string.Concat(permutation.Item1, permutation.Item2, permutation.Item3);
        return Task.FromResult<Answer>(concatenation);
    }

    private static IEnumerable<(int, int, int)> FindPrimePermutations(int start, int end, int increase)
    {
        foreach (int firstPrime in PrimeNumbers.Between(start, end - increase))
        {
            var secondPrime = firstPrime + increase;
            if (!PrimeNumbers.IsPrime(secondPrime))
            {
                continue;
            }

            var thirdPrime = secondPrime + increase;
            if (!PrimeNumbers.IsPrime(thirdPrime))
            {
                continue;
            }

            var digits = firstPrime.Digits().ToHashSet();
            if (!digits.SetEquals(secondPrime.Digits()) || !digits.SetEquals(thirdPrime.Digits()))
            {
                continue;
            }

            yield return (firstPrime, secondPrime, thirdPrime);
        }
    }
}
