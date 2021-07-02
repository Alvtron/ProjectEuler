using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0014 : ISolver
    {
        public Answer Solve()
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
