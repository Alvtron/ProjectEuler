using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0060 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var primeSet = FindPrimeSet(5);
        return Task.FromResult<Answer>(primeSet.Sum());
    }

    private readonly record struct Pair(long A, long B);

    private static HashSet<long> FindPrimeSet(int setSize)
    {
        var primeSets = new List<HashSet<long>> { new() };
        var cache = new Dictionary<Pair, bool>();

        foreach (var nextPrime in PrimeNumbers.Generate())
        {
            var newSets = new List<HashSet<long>>();
            foreach (var set in primeSets)
            {
                if (!set.All(pairedPrime => AreConcatenationsPrime(new Pair(pairedPrime, nextPrime))))
                {
                    continue;
                }

                var newSet = new HashSet<long>(set) { nextPrime };
                if (newSet.Count == setSize)
                {
                    return newSet;
                }

                newSets.Add(newSet);
            }

            primeSets.AddRange(newSets);
        }

        throw new InvalidOperationException("No prime set found");

        bool AreConcatenationsPrime(Pair pair)
        {
            if (cache.TryGetValue(pair, out var result))
            {
                return result;
            }

            var isPrimePair = IsConcatenationPrime(pair.A, pair.B) && IsConcatenationPrime(pair.B, pair.A);
            return cache[pair] = isPrimePair;
        }

        bool IsConcatenationPrime(long a, long b)
        {
            return PrimeNumbers.IsPrime(CombinedNumbers.Combine(a, b));
        }
    }
}
