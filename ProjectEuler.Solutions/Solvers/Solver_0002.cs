﻿using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0002 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sumOfEvenFibonacciNumbers = SumOfEvenFibonacciNumbers(limit: 4_000_000);
        return Task.FromResult<Answer>(sumOfEvenFibonacciNumbers);
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