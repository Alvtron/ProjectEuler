﻿using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0021 : ISolver
    {
        public Answer Solve()
        {
            return GetSumOfAmicableNumbersInRange(1, 10000);
        }

        private static Answer GetSumOfAmicableNumbersInRange(int start, int end)
        {
            var numbersSums = new Dictionary<int, int>();

            for (var number = start; number < end; number++)
            {
                var divisors = GetDivisorsOf(number);
                var sum = divisors.Sum();

                numbersSums.Add(number, sum);
            }

            var total = 0;

            foreach (var (firstNumber, firstSum) in numbersSums)
            {
                var secondNumber = firstSum;

                // skip already processed numbers
                if (firstNumber >= secondNumber)
                {
                    continue;
                }

                // skip if there are no other number equal to the sum of divisors of the first number
                if (!numbersSums.TryGetValue(secondNumber, out var secondSum))
                {
                    continue;
                }

                // skip if sum of divisors of second number is not equal to first number
                if (secondSum != firstNumber)
                {
                    continue;
                }

                total += firstSum + secondSum;
            }

            return total;
        }

        private static IEnumerable<int> GetDivisorsOf(int number)
        {
            for (var divisor = 1; divisor < number; divisor++)
            {
                if (number % divisor == 0)
                {
                    yield return divisor;
                }
            }
        }
    }
}