using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem_0014 : IProblem<long>
    {
        private static long GetNextTerm(long n)
        {
            if (n % 2L == 0L)
            {
                return n / 2L;
            }
            else
            {
                return (3L * n) + 1L;
            }
        }

        private static long GetNumberForLongestChain(int limit)
        {
            var terms = new Dictionary<long, long>();

            for (var n = limit; n > 0; n--)
            {
                if (terms.ContainsKey(n))
                {
                    continue;
                }

                var seenNumbers = new Queue<long>();
                seenNumbers.Enqueue(n);

                var number = (long)n;
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

            var startingTerm = terms.Aggregate((l, r) => (l.Key <= limit) && (l.Value > r.Value) ? l : r).Key;

            return startingTerm;
        }

        public string Question
        {
            get => "The following iterative sequence is defined for the set of positive integers:"
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
        }

        public long Answer()
        {
            return GetNumberForLongestChain(1000000);
        }
    }
}
