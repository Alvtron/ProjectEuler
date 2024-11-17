using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0039 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var perimeter = FindPerimeterWithMaximumRightAngleTriangles(3, 1000);
        return Task.FromResult<Answer>(perimeter);
    }

    private static int FindPerimeterWithMaximumRightAngleTriangles(int minimumPerimeter, int maximumPerimeter)
    {
        if (minimumPerimeter < 3)
        {
            throw new ArgumentException("The minimum perimeter must be at least 3.", nameof(minimumPerimeter));
        }

        if (minimumPerimeter > maximumPerimeter)
        {
            throw new ArgumentException("The minimum perimeter must be lower than the maximum perimeter.", nameof(minimumPerimeter));
        }

        var maximizedPerimeter = 0;
        var maximizedNumberOfSolutions = 0;

        for (var perimeter = minimumPerimeter; perimeter <= maximumPerimeter; perimeter++)
        {
            var numberOfSolutions = 0;

            // a, b and c represents the length of each integral side of the triangle
            for (var c = 1; c <= perimeter - 2; c++)
            {
                for (var b = 1; b <= c; b++)
                {
                    var a = Math.Sqrt(c * c - b * b);
                    if (a != 0 && double.IsInteger(a) && (int)a + b + c == perimeter)
                    {
                        numberOfSolutions++;
                    }
                }
            }

            if (numberOfSolutions <= maximizedNumberOfSolutions)
            {
                continue;
            }

            maximizedNumberOfSolutions = numberOfSolutions;
            maximizedPerimeter = perimeter;
        }

        return maximizedPerimeter;
    }
}