using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem_0006 : IProblem<long>
    {
        private readonly int[] Numbers = Enumerable.Range(1, 100).ToArray();

        public string Question
        {
            get => "What is the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum?";
        }

        public long Answer()
        {
            return DifferenceBetweenSumOfSquaresAndSquareOfSum(Numbers);
        }

        static long SumOfSquares(int[] numbers)
        {
            return numbers.Sum(x => (long)Math.Pow(x, 2));
        }

        static long SquareOfSum(int[] numbers)
        {
            long sum = numbers.Sum();
            return (long)Math.Pow(sum, 2);
        }

        static long DifferenceBetweenSumOfSquaresAndSquareOfSum(int[] numbers)
        {
            var sumOfSquares = SumOfSquares(numbers);
            var squareOfSum = SquareOfSum(numbers);
            return squareOfSum - sumOfSquares;
        }
    }
}
