using ProjectEuler.Helpers.Numerics;
using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0007 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var prime = PrimeNumbers.Generate().ElementAt(10_001 - 1);
        return await Task.FromResult(prime);
    }
}