﻿using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0014 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var longestCollatzSequence = GetNumberForLongestChain(1000000);
        return Task.FromResult<Answer>(longestCollatzSequence);
    }

    private static long GetNextTerm(long number)
    {
        return long.IsEvenInteger(number)
            ? ApplyEvenNumberRule(number)
            : ApplyOddNumberRule(number);
    }

    private static long ApplyOddNumberRule(long number)
    {
        return 3L * number + 1L;
    }

    private static long ApplyEvenNumberRule(long number)
    {
        return number / 2L;
    }

    private static long GetNumberForLongestChain(long limit)
    {
        var numberOfTermsByNumber = new Dictionary<long, long>();

        for (var number = 1L; number <= limit; number++)
        {
            if (numberOfTermsByNumber.ContainsKey(number))
            {
                continue;
            }

            var seenNumbers = new Queue<long>();
            seenNumbers.Enqueue(number);

            var count = 1L;
            var term = number;

            while (term > 1)
            {
                term = GetNextTerm(term);
                if (numberOfTermsByNumber.TryGetValue(term, out var numberOfTerms))
                {
                    count += numberOfTerms;
                    break;
                }
                count++;
                seenNumbers.Enqueue(term);
            }

            while (seenNumbers.Count > 0)
            {
                numberOfTermsByNumber[seenNumbers.Dequeue()] = count--;
            }
        }

        return numberOfTermsByNumber.MaxBy(kv => kv.Value).Key;
    }
}