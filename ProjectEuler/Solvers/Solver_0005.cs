﻿using System;
using System.Linq;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0005 : ISolver
    {
        public Answer Solve()
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