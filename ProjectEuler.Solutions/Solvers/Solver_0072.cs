using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0072 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var phi = EulerTotientNumbers.Generate(1_000_000);
        return Task.FromResult<Answer>(phi.Sum() - 1);
    }
}