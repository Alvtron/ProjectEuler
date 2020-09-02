using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem_0067 : IProblem<long>
    {
        private int[][] Triangle { get; set; }

        public Problem_0067()
        {
            Triangle = CreateTriangle();
        }

        private int[][] CreateTriangle()
        {
            var lines = System.IO.File.ReadAllLines(
                @"C:\Users\thoma\source\repos\CodeChallenges\ProjectEuler\resources\problem_0067_triangle.txt");

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

        private int GetMaximumPathSum(int[][] triangle)
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

        public string Question { get; }

        public long Answer()
        {
            return GetMaximumPathSum(Triangle);
        }
    }
}
