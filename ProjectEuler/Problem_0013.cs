using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler
{
    class Problem_0013 : IProblem<long>
    {
        private readonly string NumbersString = System.IO.File.ReadAllText(
                @"C:\Users\thoma\source\repos\CodeChallenges\ProjectEuler\resources\problem_0013_numbers.txt");
        private readonly BigInteger[] Numbers;

        public Problem_0013()
        {
            var lines = System.IO.File.ReadAllLines(
                @"C:\Users\thoma\source\repos\CodeChallenges\ProjectEuler\resources\problem_0013_numbers.txt");

            var numbers = new BigInteger[lines.Length];

            for (var i = 0; i < lines.Length; i++)
            {
                var number = BigInteger.Parse(lines[i]);
                numbers[i] = number;
            }

            Numbers = numbers;
        }

        public string Question
        {
            get => "Work out the first ten digits of the sum of the following one-hundred 50-digit numbers:"
                + Environment.NewLine + NumbersString;
        }

        public long Answer()
        {
            return GetFirstTenNumbersOfSum();
        }

        private long GetFirstTenNumbersOfSum()
        {
            var sum = new BigInteger();
            foreach (var number in Numbers)
            {
                sum += number;
            }

            var firstNumbers = long.Parse(sum.ToString().Substring(0, 10));
            return firstNumbers;
        }
    }
}
