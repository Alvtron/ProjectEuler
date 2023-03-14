using ProjectEuler.Extensions.Streams;
using ProjectEuler.Mathematics.Letters;
using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

public class Solver_0022 : ISolver
{
    private static readonly string NamesFilePath = ResourcesHelper.GetResourcePath("problem_0022_names.txt");

    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var wordScores = GetWordScoresInFile(NamesFilePath);
        var sumOfNamesScores = wordScores.Sum();
        return await Task.FromResult(sumOfNamesScores);
    }

    private static IEnumerable<int> GetWordScoresInFile(string path)
    {
        var wordCounts = CountWordsInFile(path);

        var wordPosition = 1;
        foreach (var (word, count) in wordCounts)
        {
            var lastWordPosition = wordPosition + count - 1;

            while (wordPosition <= lastWordPosition)
            {
                var wordScore = GetWordScore(word);

                yield return wordPosition++ * wordScore;
            }
        }
    }

    private static int GetWordScore(string word)
    {
        return word
            .Where(Alphabet.IsAlphabeticalLetter)
            .Select(Alphabet.GetPositionOf)
            .Sum();
    }

    private static SortedDictionary<string, int> CountWordsInFile(string path)
    {
        using var streamReader = new StreamReader(path);

        var wordCounts = new SortedDictionary<string, int>(StringComparer.InvariantCulture);

        foreach (var word in streamReader.ReadWords())
        {
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts[word] = 1;
            }
        }

        return wordCounts;
    }
}