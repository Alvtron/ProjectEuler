using System.Numerics;
using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0056 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var maxDigitalSum = 0;
        for (var a = 1; a < 100; a++)
        {
            for (var b = 1; b < 100; b++)
            {
                var digitalSum = BigInteger.Pow(a, b).Digits().Sum();
                if (maxDigitalSum < digitalSum)
                {
                    maxDigitalSum = digitalSum;
                }
            }
        }

        return Task.FromResult<Answer>(maxDigitalSum);
    }
}