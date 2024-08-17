using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0052 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<Answer>(FindSmallestNumberWithPermutedMultiples(6));
    }

    private static long FindSmallestNumberWithPermutedMultiples(int targetNumberOfMultiples)
    {
        for (var number = 1;; number++)
        {
            var digits = number.Digits().ToHashSet();
            var numberOfMultiples = 1;

            for (var multiple = 2; multiple <= targetNumberOfMultiples; multiple++)
            {
                var product = number * multiple;

                if (!digits.SetEquals(product.Digits()))
                {
                    break;
                }

                numberOfMultiples++;
            }

            if (numberOfMultiples == targetNumberOfMultiples)
            {
                return number;
            }
        }
    }
}