using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem_0024 : Problem
    {
        private static readonly string QuestionFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0024_question.txt");

        public Problem_0024()
            : base(24)
        {
        }

        public override string Question => File.ReadAllText(QuestionFilePath);

        public override Answer Answer => Answer.Empty;

        public override bool IsSolved => false;

        public override Answer Solve()
        {
            return CreatePermutations(0, 1, 2, 3, 4, 5, 6, 7, 8, 9).ElementAtOrDefault(1_000_000 - 1);
        }

        private static IEnumerable<int> CreatePermutations(params int[] digits)
        {
            for (var i = 0; i < digits.Length; i++)
            {
                yield return 0;
            }
        }
    }
}
