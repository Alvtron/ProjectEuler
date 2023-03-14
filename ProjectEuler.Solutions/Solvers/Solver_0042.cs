using ProjectEuler.Mathematics.Letters;
using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

public class Solver_0042 : ISolver
{
    private static readonly string NumbersFilePath = ResourcesHelper.GetResourcePath("problem_0042_words.txt");

    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var words = await File.ReadAllTextAsync(NumbersFilePath, cancellationToken);
        var numberOfTriangleWords = CountTriangleWords(words.Replace("\"", string.Empty).Split(','));
        return await Task.FromResult(numberOfTriangleWords);
    }

    private static int CountTriangleWords(IEnumerable<string> words)
    {
        return words.Count(IsTriangleWord);
    }

    private static bool IsTriangleWord(string word)
    {
        var wordValue = GetValueOfWord(word);
        return IsTriangleNumber(wordValue);
    }

    private static bool IsTriangleNumber(int number)
    {
        // solve n for 1/2 * n * (n + 1) = number
        // n * (n + 1) = number * 2
        // n*n + n = number * 2
        // n^2 + n - number * 2 = 0
        // Solve using quadratic equation:
        // (-1 + sqrt(1 - 4 * 1 * (-number * 2)))/(2 * 1)
        // (-1 + sqrt(1 - 8 * number))/2
        var remainder = (-1.0 + Math.Sqrt(1.0 - 4.0 * (-number * 2.0))) / 2.0;
        return double.IsInteger(remainder);
    }

    private static int GetValueOfWord(string word)
    {
        return word.Sum(Alphabet.GetPositionOf);
    }
}