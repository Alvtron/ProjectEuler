using ProjectEuler.Mathematics.Functions;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0069 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var number = FindNumberWithLargestPhiRatio(2, 1_000_000);
        return Task.FromResult<Answer>(number);
    }

    private static int FindNumberWithLargestPhiRatio(int start, int end)
    {
        var maxNumber = 0;
        var maxPhiRatio = 0.0;

        for (var n = start; n <= end; n++)
        {
            var phi = EulerTotientFunction.Calculate(n);
            var ratio = (double)n / phi;
            if (ratio <= maxPhiRatio)
            {
                continue;
            }

            maxPhiRatio = ratio;
            maxNumber = n;
        }

        return maxNumber;
    }
}