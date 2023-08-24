using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0044 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var smallestPentagonalDifference = FindSmallestPentagonalDifference();
        return await Task.FromResult(smallestPentagonalDifference);
    }

    private static long FindSmallestPentagonalDifference()
    {
        for (var index = 1; index < int.MaxValue; index++)
        {
            var firstPentagonal = PentagonalNumbers.GetNumber(index);

            for (var secondIndex = 1; secondIndex < index; secondIndex++)
            {
                var secondPentagonal = PentagonalNumbers.GetNumber(secondIndex);

                var difference = firstPentagonal - secondPentagonal;
                if (PentagonalNumbers.IsPentagonalNumber(difference) && PentagonalNumbers.IsPentagonalNumber(firstPentagonal + secondPentagonal))
                {
                    return difference;
                }
            }
        }

        throw new InvalidOperationException("Unable to find the smallest pentagonal difference.");
    }
}