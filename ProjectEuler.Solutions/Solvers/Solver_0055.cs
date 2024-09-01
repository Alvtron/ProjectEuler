using ProjectEuler.Solutions.Answers;
using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0055 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var numberOfLychrelNumbers = LychrelNumbers.Between(0, 10_000).Count();
        return Task.FromResult<Answer>(numberOfLychrelNumbers);
    }
}