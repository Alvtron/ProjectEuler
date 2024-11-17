using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0038 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var largestPandigital = FindLargestPandigital();
        return Task.FromResult<Answer>(largestPandigital);
    }

    private static int FindLargestPandigital()
    {
        for (var number = 9999; number > 0; number--)
        {
            var digits = new HashSet<int>();
            for (var n = 1; n < 10; n++)
            {
                if (!(number * n).Digits().All(digits.Add))
                {
                    break;
                }

                if (digits.Count > 9 || digits.Contains(0))
                {
                    break;
                }

                if (digits.Count != 9)
                {
                    continue;
                }

                return (int)CombinedNumbers.Combine(digits);
            }
        }

        return -1;
    }
}