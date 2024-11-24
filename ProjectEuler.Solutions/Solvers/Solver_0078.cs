using ProjectEuler.Mathematics.Functions;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0078 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var integerPartitions = new IntegerPartitions();
        var result = integerPartitions.EnumerateNumberOfPartitions()
            .Select((partitions, index) => (Partitions: partitions, Number: index))
            .First(k => k.Partitions % 1_000_000 == 0);

        return Task.FromResult<Answer>(result.Number);
    }
}