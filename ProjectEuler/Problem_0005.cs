using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem_0005 : IProblem<long>
    {
        private readonly int[] Numbers = Enumerable.Range(1, 20).ToArray();

        public string Question
        {
            get => "2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.\n" +
                "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ? ";
        }

        public long Answer()
        {
            return SmallestNumberDivisbleBy(Numbers);
        }

        private static long SmallestNumberDivisbleBy(params int[] numbers)
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
