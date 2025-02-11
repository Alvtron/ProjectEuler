using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0082 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var matrix = CreateMatrix();
        var height = matrix.GetLength(0);
        var width = matrix.GetLength(1);
        var path = new int[height, width];

        // Copy the last column directly
        for (var row = 0; row < height; row++)
        {
            path[row, width - 1] = matrix[row, width - 1];
        }

        // Process from right to left
        for (var column = width - 2; column >= 0; column--)
        {
            // Start by considering rightward movement
            for (var row = 0; row < height; row++)
            {
                path[row, column] = matrix[row, column] + path[row, column + 1];
            }

            // Move downward to propagate the minimum values
            for (var row = 1; row < height; row++)
            {
                path[row, column] = Math.Min(path[row, column], matrix[row, column] + path[row - 1, column]);
            }

            // Move upward to ensure all minimums are considered
            for (var row = height - 2; row >= 0; row--)
            {
                path[row, column] = Math.Min(path[row, column], matrix[row, column] + path[row + 1, column]);
            }
        }

        // Find the minimum path sum starting from any row in the first column
        var minimumPathSum = int.MaxValue;
        for (var row = 0; row < height; row++)
        {
            minimumPathSum = Math.Min(minimumPathSum, path[row, 0]);
        }

        return Task.FromResult<Answer>(minimumPathSum);
    }

    private static int[,] CreateMatrix()
    {
        var matrixData = Resource_0082.Matrix.AsSpan();
        var matrix = new int[Resource_0082.MatrixHeight, Resource_0082.MatrixWidth];
        var lineIndex = 0;
        foreach (var line in matrixData.EnumerateLines())
        {
            var numbers = line.Split(',');
            var numberIndex = 0;
            while (numbers.MoveNext())
            {
                var numberString = line[numbers.Current];
                var number = int.Parse(numberString);
                matrix[lineIndex, numberIndex++] = number;
            }

            lineIndex++;
        }

        return matrix;
    }
}
