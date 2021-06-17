using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem_0006 : Problem
    {
        public Problem_0006()
            : base(6)
        {
        }

        public override string Question =>
            "What is the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum?";

        public override Answer Answer => 25164150L;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            var numbers = Enumerable.Range(1, 100).ToArray();
            return DifferenceBetweenSumOfSquaresAndSquareOfSum(numbers);
        }

        private static long SumOfSquares(IEnumerable<int> numbers)
        {
            return numbers.Sum(x => (long)Math.Pow(x, 2));
        }

        private static long SquareOfSum(IEnumerable<int> numbers)
        {
            long sum = numbers.Sum();
            return (long)Math.Pow(sum, 2);
        }

        private static long DifferenceBetweenSumOfSquaresAndSquareOfSum(IReadOnlyCollection<int> numbers)
        {
            var sumOfSquares = SumOfSquares(numbers);
            var squareOfSum = SquareOfSum(numbers);
            return squareOfSum - sumOfSquares;
        }
    }
}
