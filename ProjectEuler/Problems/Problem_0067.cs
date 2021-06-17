using System;
using System.IO;

namespace ProjectEuler.Problems
{
    public class Problem_0067 : Problem
    {
        private static readonly string NumbersFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0067_triangle.txt");
        private static readonly string QuestionFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0067_question.txt");

        public Problem_0067()
            : base(67)
        {
        }

        public override string Question => File.ReadAllText(QuestionFilePath);

        public override Answer Answer => 7273;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            var triangle = CreateTriangle();
            return GetMaximumPathSum(triangle);
        }

        private static int[][] CreateTriangle()
        {
            var lines = File.ReadAllLines(NumbersFilePath);

            var triangle = new int[lines.Length][];

            for (var i = 0; i < lines.Length; i++)
            {
                var digits = lines[i].Split(' ');
                triangle[i] = new int[digits.Length];

                for (var j = 0; j < digits.Length; j++)
                {
                    triangle[i][j] = int.Parse(digits[j]);
                }
            }

            return triangle;
        }

        private static int GetMaximumPathSum(int[][] triangle)
        {
            for (var i = triangle.GetUpperBound(0) - 1; i >= 0; i--)
            {
                for (var j = 0; j < triangle[i].Length; j++)
                {
                    var left = triangle[i + 1][j];
                    var right = triangle[i + 1][j + 1];
                    triangle[i][j] += Math.Max(left, right);
                }
            }

            return triangle[0][0];
        }
    }
}
