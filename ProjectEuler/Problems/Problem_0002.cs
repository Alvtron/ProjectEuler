﻿namespace ProjectEuler.Problems
{
    public class Problem_0002 : Problem
    {
        private const int LIMIT = 4000000;

        public Problem_0002()
            : base(2)
        {
        }

        public override string Question =>
            "Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:\n" +
            "1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...\n" +
            "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.";

        public override Answer Answer => 4613732L;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            return SumOfEvenFibonacciNumbers(LIMIT);
        }

        private static long SumOfEvenFibonacciNumbers(int limit)
        {
            var first = 1;
            var second = 2;
            var sum = second;
            do
            {
                var secondCopy = second;
                second = first + second;
                first = secondCopy;
                if (second % 2 == 0)
                {
                    sum += second;
                }
            } while (second <= limit);
            return sum;
        }
    }
}