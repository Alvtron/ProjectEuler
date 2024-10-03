using ProjectEuler.Mathematics.Combinatorics;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0070 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var number = FindNumberThatPermutesWithSmallestPhiRatio(2, 10_000_000);
        return Task.FromResult<Answer>(number);
    }

    private static int FindNumberThatPermutesWithSmallestPhiRatio(int start, int end)
    {
        var maxNumber = int.MinValue;
        var minPhiRatio = double.MaxValue;

        var phis = EulerTotientNumbers.Generate(end);
        for (var index = start - 1; index < end; index++)
        {
            var n = index + 1;
            var phi = phis[index];
            if (!Permutations.ArePermutations(n, phi))
            {
                continue;
            }

            var ratio = (double)n / phi;
            if (ratio > minPhiRatio)
            {
                continue;
            }

            minPhiRatio = ratio;
            maxNumber = n;
        }

        return maxNumber;
    }
}