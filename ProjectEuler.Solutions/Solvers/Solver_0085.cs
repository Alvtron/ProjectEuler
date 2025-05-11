using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0085 : ISolver
{
    private const int Target = 2_000_000;
    private const int MaxSize = 2000;

    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var bestArea = 0;
        var smallestDifference = int.MaxValue;

        for (var rows = 1; rows <= MaxSize; rows++)
        {
            var rowCombinations = rows * (rows + 1) / 2;

            for (var cols = 1; cols <= MaxSize; cols++)
            {
                var totalRectangles = rowCombinations * (cols * (cols + 1) / 2);
                var difference = Math.Abs(totalRectangles - Target);

                if (difference < smallestDifference)
                {
                    smallestDifference = difference;
                    bestArea = rows * cols;
                }

                if (totalRectangles > Target)
                {
                    break;
                }
            }
        }

        return Task.FromResult<Answer>(bestArea);
    }
}