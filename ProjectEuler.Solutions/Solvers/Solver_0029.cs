using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0029 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var numberOfDistinctPowers = GeneratePowerCombinations(2, 100, 2, 100)
            .Distinct()
            .Count();

        return Task.FromResult<Answer>(numberOfDistinctPowers);
    }

    private static IEnumerable<double> GeneratePowerCombinations(int baseMin, int baseMax, int exponentMin, int exponentMax)
    {
        for (var a = baseMin; a <= baseMax; a++)
        for (var b = exponentMin; b <= exponentMax; b++)
        {
            yield return Math.Pow(a, b);
        }
    }
}