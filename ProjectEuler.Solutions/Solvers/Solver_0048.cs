using ProjectEuler.Solutions.Answers;
using System.Numerics;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0048 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sum = BigInteger.Zero;

        for (var number = 1; number <= 1000; number++)
        {
            sum += BigInteger.Pow(number, number);
        }

        var lastDigits = string.Concat(sum.ToString().TakeLast(10));

        return Task.FromResult<Answer>(lastDigits);
    }
}
