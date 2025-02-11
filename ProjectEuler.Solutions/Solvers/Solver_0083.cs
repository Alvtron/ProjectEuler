using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0083 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var matrix = CreateMatrix();
        var height = matrix.GetLength(0);
        var width = matrix.GetLength(1);
        var directions = new (int Row, int Col)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        var cost = new int[height, width];
        for (var row = 0; row < height; row++)
        {
            for (var col = 0; col < width; col++)
            {
                cost[row, col] = int.MaxValue;
            }
        }

        var priorityQueue = new SortedSet<(int Cost, int Row, int Col)>(Comparer<(int Cost, int Row, int Col)>.Create((a, b) =>
            a.Cost != b.Cost ? a.Cost.CompareTo(b.Cost) :
            (a.Row != b.Row ? a.Row.CompareTo(b.Row) : a.Col.CompareTo(b.Col))));

        cost[0, 0] = matrix[0, 0];
        priorityQueue.Add((matrix[0, 0], 0, 0));

        while (priorityQueue.Count > 0)
        {
            var (currentCost, row, col) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);

            // Stop early if we reach bottom-right
            if (row == height - 1 && col == width - 1)
            {
                return Task.FromResult<Answer>(currentCost);
            }

            foreach (var (deltaRow, deltaCol) in directions)
            {
                var newRow = row + deltaRow;
                var newCol = col + deltaCol;

                if (newRow >= 0 && newRow < height && newCol >= 0 && newCol < width)
                {
                    var newCost = currentCost + matrix[newRow, newCol];

                    if (newCost < cost[newRow, newCol])
                    {
                        priorityQueue.Remove((cost[newRow, newCol], newRow, newCol));
                        cost[newRow, newCol] = newCost;
                        priorityQueue.Add((newCost, newRow, newCol));
                    }
                }
            }
        }

        throw new InvalidOperationException("Solution not found.");
    }

    private static int[,] CreateMatrix()
    {
        var matrixData = Resource_0083.Matrix.AsSpan();
        var matrix = new int[Resource_0083.MatrixHeight, Resource_0083.MatrixWidth];
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
