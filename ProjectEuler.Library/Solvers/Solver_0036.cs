using ProjectEuler.Extensions.Extensions;
using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0036 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var palindromes = FindDoubleBasePalindromesBetween(0, 1_000_000);
        return await Task.FromResult(palindromes.Sum());
    }

    private static IEnumerable<int> FindDoubleBasePalindromesBetween(int start, int end)
    {
        for (var number = start; number < end; number++)
        {
            var digits = number.Digits().ToArray();
            if (!IsPalindromic(digits))
            {
                continue;
            }

            var binary = Convert.ToString(number, 2).ToCharArray();
            if (!IsPalindromic(binary))
            {
                continue;
            }

            yield return number;
        }
    }

    private static bool IsPalindromic<T>(IReadOnlyCollection<T> elements)
    {
        if (elements.Count < 2)
        {
            return true;
        }

        var middle = elements.Count / 2;

        var firstPart = elements.Take(middle);
        var secondPart = int.IsEvenInteger(elements.Count)
            ? elements.Skip(middle).Reverse()
            : elements.Skip(middle + 1).Reverse();

        return firstPart.SequenceEqual(secondPart);
    }
}