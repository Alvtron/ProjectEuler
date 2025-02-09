using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0081 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var matrix = CreateMatrix();
        var height = matrix.GetLength(0);
        var width = matrix.GetLength(1);
        var path = new int[height, width];
        for (var rowIndex = 0; rowIndex < height; rowIndex++)
        {
            for (var columnIndex = 0; columnIndex < width; columnIndex++)
            {
                path[rowIndex, columnIndex] = matrix[rowIndex, columnIndex];
                switch (rowIndex)
                {
                    case > 0 when columnIndex > 0:
                        path[rowIndex, columnIndex] += Math.Min(
                            path[rowIndex - 1, columnIndex],
                            path[rowIndex, columnIndex - 1]);
                        break;
                    case > 0:
                        path[rowIndex, columnIndex] += path[rowIndex - 1, columnIndex];
                        break;
                    default:
                    {
                        if (columnIndex > 0)
                        {
                            path[rowIndex, columnIndex] += path[rowIndex, columnIndex - 1];
                        }

                        break;
                    }
                }
            }
        }
        return Task.FromResult<Answer>(path[height - 1, width - 1]);
    }

    private static int[,] CreateMatrix()
    {
        var matrixData = Resource_0081.Matrix.AsSpan();
        var matrix = new int[Resource_0081.MatrixHeight, Resource_0081.MatrixWidth];
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