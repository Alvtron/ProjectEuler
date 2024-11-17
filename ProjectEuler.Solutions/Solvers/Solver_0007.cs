using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0007 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var prime = PrimeNumbers.Generate().ElementAt(10_001 - 1);
        return Task.FromResult<Answer>(prime);
    }
}