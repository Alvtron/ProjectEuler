using ProjectEuler.Extensions.Extensions;
using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0038 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var largestPandigital = FindLargestPandigital();
        return await Task.FromResult(largestPandigital);
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

                return ConvertDigitsIntoNumber(digits);
            }
        }

        return -1;
    }

    private static int ConvertDigitsIntoNumber(IReadOnlyCollection<int> array)
    {
        return array
            .Select((number, index) => number * Convert.ToInt32(Math.Pow(10, array.Count - index - 1)))
            .Sum();
    }
}