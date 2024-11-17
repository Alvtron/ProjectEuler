using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0044 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var smallestPentagonalDifference = FindSmallestPentagonalDifference();
        return Task.FromResult<Answer>(smallestPentagonalDifference);
    }

    private static long FindSmallestPentagonalDifference()
    {
        for (var index = 1; index < int.MaxValue; index++)
        {
            var firstPentagonal = PentagonalNumbers.Get(index);

            for (var secondIndex = 1; secondIndex < index; secondIndex++)
            {
                var secondPentagonal = PentagonalNumbers.Get(secondIndex);

                var difference = firstPentagonal - secondPentagonal;
                if (PentagonalNumbers.IsPentagonal(difference) && PentagonalNumbers.IsPentagonal(firstPentagonal + secondPentagonal))
                {
                    return difference;
                }
            }
        }

        throw new InvalidOperationException("Unable to find the smallest pentagonal difference.");
    }
}