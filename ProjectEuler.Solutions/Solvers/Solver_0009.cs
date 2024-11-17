using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0009 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var (a, b, c) = FindPythagoreanTripletThatEquals(1000);
        return Task.FromResult<Answer>(a * b * c);
    }

    private static Tuple<int, int, int> FindPythagoreanTripletThatEquals(int sum)
    {
        int a;
        var b = 1;
        var c = 1;

        for (a = 1; a < int.MaxValue; a++)
        {
            for (b = a + 1; b < int.MaxValue; b++)
            {
                var newC = Math.Sqrt(a * a + b * b);

                if (!IsInteger(newC))
                {
                    continue;
                }

                c = (int)newC;

                if (a + b + c >= sum)
                {
                    break;
                }
            }

            if (a + b + c == sum)
            {
                break;
            }
        }

        return Tuple.Create(a, b, c);
    }

    private static bool IsInteger(double number)
    {
        return number % 1.0 < double.Epsilon;
    }
}