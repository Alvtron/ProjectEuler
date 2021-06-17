using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem_0014 : Problem
    {
        public override string Question =>
            "The following iterative sequence is defined for the set of positive integers:"
            + Environment.NewLine
            + "n -> n/2 (n is even)"
            + Environment.NewLine
            + "n -> 3n + 1 (n is odd)"
            + Environment.NewLine
            + "Using the rule above and starting with 13, we generate the following sequence:"
            + Environment.NewLine
            + "13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1"
            + Environment.NewLine
            + "It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1."
            + Environment.NewLine
            + "Which starting number, under one million, produces the longest chain?";

        public Problem_0014()
            : base(14)
        {
        }

        public override Answer Answer => 837799L;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            return GetNumberForLongestChain(1000000);
        }

        private static long GetNextTerm(long number)
        {
            if (number % 2L == 0L)
            {
                return number / 2L;
            }

            return 3L * number + 1L;
        }

        private static long GetNumberForLongestChain(long limit)
        {
            var terms = new Dictionary<long, long>();

            for (var number = limit; number > 0L; number += 1L)
            {
                if (terms.ContainsKey(number))
                {
                    continue;
                }

                var seenNumbers = new Queue<long>();
                seenNumbers.Enqueue(number);

                var count = 1L;

                while (number > 1)
                {
                    number = GetNextTerm(number);
                    if (terms.ContainsKey(number))
                    {
                        count += terms[number];
                        break;
                    }
                    count++;
                    seenNumbers.Enqueue(number);
                }

                while (seenNumbers.Count > 0)
                {
                    terms[seenNumbers.Dequeue()] = count--;
                }
            }

            var startingTerm = terms.Aggregate((l, r) => l.Key <= limit && l.Value > r.Value ? l : r).Key;

            return startingTerm;
        }
    }
}
