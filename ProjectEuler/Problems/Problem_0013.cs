using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    public class Problem_0013 : Problem
    {
        private static readonly string NumbersFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0013_numbers.txt");

        public Problem_0013()
            : base(13)
        {
        }

        public override string Question =>
            "Work out the first ten digits of the sum of the following one-hundred 50-digit numbers:"
            + Environment.NewLine + File.ReadAllText(NumbersFilePath);

        public override Answer Answer => 5537376230L;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            var numbersString = File.ReadAllText(NumbersFilePath);
            var numbers = GetNumbersFromString(numbersString);
            var sum = GetSumOf(numbers);

            return GetFirstDigitsOf(sum, 10);
        }

        private static IEnumerable<BigInteger> GetNumbersFromString(string numbers)
        {
            return numbers.Split(Environment.NewLine).Select(BigInteger.Parse);
        }

        private static BigInteger GetSumOf(IEnumerable<BigInteger> numbers)
        {
            var sum = new BigInteger();

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        private static long GetFirstDigitsOf(BigInteger number, int count)
        {
            var firstNumbers = number.ToString().Substring(0, count);
            return long.Parse(firstNumbers);
        }
    }
}
