using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0067 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var triangle = CreateTriangle();
        var maximumPathSum = GetMaximumPathSum(triangle);
        return Task.FromResult<Answer>(maximumPathSum);
    }

    private static int[][] CreateTriangle()
    {
        var lines = Resource_0067.Triangle.Split(Environment.NewLine);

        var triangle = new int[lines.Length][];

        for (var i = 0; i < lines.Length; i++)
        {
            var digits = lines[i].Split(' ');
            triangle[i] = new int[digits.Length];

            for (var j = 0; j < digits.Length; j++)
            {
                triangle[i][j] = int.Parse(digits[j]);
            }
        }

        return triangle;
    }

    private static int GetMaximumPathSum(int[][] triangle)
    {
        for (var i = triangle.GetUpperBound(0) - 1; i >= 0; i--)
        {
            for (var j = 0; j < triangle[i].Length; j++)
            {
                var left = triangle[i + 1][j];
                var right = triangle[i + 1][j + 1];
                triangle[i][j] += int.Max(left, right);
            }
        }

        return triangle[0][0];
    }
}