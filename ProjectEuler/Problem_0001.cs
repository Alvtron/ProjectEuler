using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    class Problem_0001 : IProblem<long>
    {
        public string Question
        {
            get => "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.\n" +
                "Find the sum of all the multiples of 3 or 5 below 1000.";
        }

        public long Answer()
        {
            var multiples = new int[] { 3, 5 };
            var limit = 1000;
            return SumOfMultiples(multiples, limit);
        }

        private static long SumOfMultiples(int[] numbers, int limit)
        {
            var totalSum = 0;

            for (var i = 1; i < limit; i++)
            {
                foreach (var number in numbers)
                {
                    if (i % number == 0)
                    {
                        totalSum += i;
                        break;
                    }
                }
            }

            return totalSum;
        }
    }
}
