using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0045 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(FindNextTriangleNumber(286));
    }

    private static Answer FindNextTriangleNumber(long position)
    {
        foreach (var triangular in TriangularNumbers.Between(position, long.MaxValue))
        {
            if (PentagonalNumbers.IsPentagonal(triangular) && HexagonalNumbers.IsHexagonal(triangular))
            {
                return triangular;
            }
        }

        throw new InvalidOperationException("Unable to find the next triangle number");
    }
}