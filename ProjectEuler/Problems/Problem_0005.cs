using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem_0005 : Problem
    {
        public Problem_0005()
            : base(5)
        {
        }

        public override string Question =>
            "2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.\n" +
            "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ? ";

        public override Answer Answer => 232792560L;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            var numbers = Enumerable.Range(1, 20).ToArray();
            return SmallestNumberDivisibleBy(numbers);
        }

        private static long SmallestNumberDivisibleBy(params int[] numbers)
        {
            // in-place sort by descending
            Array.Sort(numbers, (a, b) => b - a); 

            // with a given set of positive integers,
            // the largest number will have the least amount of divisibles.
            var max = numbers[0]; 
            long current = max;

            for (var i = 1; i < numbers.Length;)
            {
                // each number in the sorted set is checked whether
                // it is divisible by the current number.
                if (current % numbers[i] != 0)
                {
                    current += max;
                    i = 1;
                }
                else i++;
            }

            // if all numbers are divisible by the current number,
            // the current number is returned.
            return current; 
        }
    }
}
