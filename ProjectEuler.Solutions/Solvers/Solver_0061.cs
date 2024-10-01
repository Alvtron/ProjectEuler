using ProjectEuler.Mathematics.Combinatorics;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0061 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
       var solution = FindCyclicalFiguratesSum();
       return Task.FromResult<Answer>(solution.Sum());
    }

    private static long[] FindCyclicalFiguratesSum()
    {
        var figurateNumbers = new Dictionary<long, long[]>
        {
            { 3, TriangularNumbers.Generate().SkipWhile(n => n < 1000).TakeWhile(n => n <= 10000).ToArray() },
            { 4, SquareNumbers.Generate().SkipWhile(n => n < 1000).TakeWhile(n => n <= 10000).ToArray() },
            { 5, PentagonalNumbers.Generate().SkipWhile(n => n < 1000).TakeWhile(n => n <= 10000).ToArray() },
            { 6, HexagonalNumbers.Generate().SkipWhile(n => n < 1000).TakeWhile(n => n <= 10000).ToArray() },
            { 7, HeptagonalNumbers.Generate().SkipWhile(n => n < 1000).TakeWhile(n => n <= 10000).ToArray() },
            { 8, OctagonalNumbers.Generate().SkipWhile(n => n < 1000).TakeWhile(n => n <= 10000).ToArray() },
        };

        // We need a combination from all sets where the numbers are cyclic
        var sets = figurateNumbers.Keys.ToArray();
        foreach (var permutation in Permutations.Of(sets).Select(p => p.ToArray()))
        {
            foreach (var first in figurateNumbers[permutation[0]])
            {
                var result = FindCyclicSet([first], permutation.Skip(1).ToArray(), figurateNumbers);
                if (result.Length == 0)
                {
                    continue;
                }

                return result.ToArray();
            }
        }

        throw new InvalidOperationException("No solution found.");
    }

    private static Span<long> FindCyclicSet(Span<long> currentSet, Span<long> remainingSets, IReadOnlyDictionary<long, long[]> figurateNumbers)
    {
        var last = currentSet[^1];

        if (remainingSets.Length == 0)
        {
            var first = currentSet[0];
            return IsCyclic(last, first) ? currentSet : [];
        }

        var remainingSet = remainingSets[0];
        foreach (var number in figurateNumbers[remainingSet].Where(n => IsCyclic(last, n)))
        {
            var newSet = new long[currentSet.Length + 1];
            currentSet.CopyTo(newSet);
            newSet[^1] = number;
            var result = FindCyclicSet(newSet, remainingSets[1..], figurateNumbers);
            if (result.Length == 0)
            {
                continue;
            }

            return result;
        }

        return [];
    }

    private static bool IsCyclic(long a, long b)
    {
        return a % 100 == b / 100;
    }
}