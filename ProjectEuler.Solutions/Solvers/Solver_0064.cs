using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0064 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var oddPeriodCount = 0;
        for (var number = 2; number <= 10_000; number++)
        {
            var sqrt = Math.Sqrt(number);
            if (sqrt % 1 == 0)
            {
                continue;
            }

            var period = FindPeriod(number);
            if (period % 2 == 1)
            {
                oddPeriodCount++;
            }
        }

        return Task.FromResult<Answer>(oddPeriodCount);
    }

    private static int FindPeriod(int number)
    {
        var m = 0;
        var d = 1;
        var a0 = (int)Math.Floor(Math.Sqrt(number));
        var a = a0;

        var period = 0;
        while (a != 2 * a0)
        {
            m = d * a - m;
            d = (number - m * m) / d;
            a = (a0 + m) / d;
            period++;
        }

        return period;
    }
}