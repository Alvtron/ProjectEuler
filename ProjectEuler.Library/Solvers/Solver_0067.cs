using ProjectEuler.Library.Answers;
using ProjectEuler.Library.Resources;

namespace ProjectEuler.Library.Solvers;

public class Solver_0067 : ISolver
{
    private static readonly string NumbersFilePath = ResourcesHelper.GetResourcePath("problem_0067_triangle.txt");

    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var triangle = await CreateTriangle(cancellationToken);
        return GetMaximumPathSum(triangle);
    }

    private static async Task<int[][]> CreateTriangle(CancellationToken cancellationToken)
    {
        var lines = await File.ReadAllLinesAsync(NumbersFilePath, cancellationToken);

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
                triangle[i][j] += Math.Max(left, right);
            }
        }

        return triangle[0][0];
    }
}