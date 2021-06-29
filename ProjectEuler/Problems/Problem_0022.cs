using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectEuler.Library;

namespace ProjectEuler.Problems
{
    public class Problem_0022 : Problem
    {
        private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly IReadOnlyDictionary<char, int> AlphabeticalPositions = Enumerable.Range(0, ALPHABET.Length).ToDictionary(i => ALPHABET[i], i => i + 1);

        private static readonly string QuestionFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0022_question.txt");
        private static readonly string NamesFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0022_names.txt");

        public Problem_0022()
            : base(22)
        {
        }

        public override string Question => File.ReadAllText(QuestionFilePath);

        public override Answer Answer => 871198282;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            var wordScores = GetWordScoresInFile(NamesFilePath);

            return wordScores.Sum();
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
            return word.Where(character => AlphabeticalPositions.ContainsKey(character))
                .Select(character => AlphabeticalPositions[character])
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
}
