using ProjectEuler.Mathematics.Letters;
using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0022 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var wordScores = GetWordScoresInFile();
        var sumOfNamesScores = wordScores.Sum();
        return Task.FromResult<Answer>(sumOfNamesScores);
    }

    private static IEnumerable<int> GetWordScoresInFile()
    {
        var wordCounts = GetWords(Resource_0022.Names);

        var wordPosition = 1;
        foreach (var word in wordCounts.Order(StringComparer.OrdinalIgnoreCase))
        {
            var lastWordPosition = wordPosition;
            var wordScore = GetWordScore(word);

            while (wordPosition <= lastWordPosition)
            {
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

    private static HashSet<string> GetWords(ReadOnlySpan<char> text)
    {
        var wordCounts = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var lookUp = wordCounts.GetAlternateLookup<ReadOnlySpan<char>>();
        foreach (var wordRange in text.SplitAny("\","))
        {
            var word = text[wordRange];
            if (word.IsEmpty)
            {
                continue;
            }

            lookUp.Add(word);
        }

        return wordCounts;
    }
}