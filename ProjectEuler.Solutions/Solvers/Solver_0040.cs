using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

public class Solver_0040 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var digits = FindFractionalDigits(1, 10, 100, 1000, 10_000, 100_000, 1_000_000);
        var product = digits.Aggregate(1, (product, digit) => product * digit);
        return await Task.FromResult(product);
    }

    private static IEnumerable<int> FindFractionalDigits(params int[] digitIndices)
    {
        var indexLookup = digitIndices.ToHashSet();
        var index = 1;
        foreach (var fractionPart in GenerateDecimalFraction())
        {
            if (indexLookup.Remove(index++))
            {
                yield return fractionPart;
            }

            if (indexLookup.Count == 0)
            {
                break;
            }
        }
    }

    private static IEnumerable<int> GenerateDecimalFraction()
    {
        return Enumerable
            .Range(1, int.MaxValue - 1)
            .SelectMany(number => number.Digits());
    }
}