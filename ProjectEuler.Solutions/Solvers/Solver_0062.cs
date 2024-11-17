using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0062 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var cubePermutation = FindCubePermutation();
        return Task.FromResult<Answer>(cubePermutation);
    }

    private static long FindCubePermutation()
    {
        var cubePermutation = 0L;
        var cubeMap = new Dictionary<string, List<long>>();

        for (var n = 1L; cubePermutation == 0; n++)
        {
            var cube = n * n * n;
            var key = string.Concat(cube.Digits().OrderBy(d => d));

            if (cubeMap.TryGetValue(key, out var mappedCubes))
            {
                mappedCubes.Add(cube);
            }
            else
            {
                mappedCubes = cubeMap[key] = [cube];
            }

            if (mappedCubes.Count == 5)
            {
                cubePermutation = cubeMap[key].First();
            }
        }

        return cubePermutation;
    }

}