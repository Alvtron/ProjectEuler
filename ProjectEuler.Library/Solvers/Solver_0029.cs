using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0029 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        return GeneratePowerCombinations(2, 100, 2, 100)
            .Distinct()
            .Count();
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