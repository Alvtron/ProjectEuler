using System.Linq;

namespace ProjectEuler.Problems
{
    public class Problem_0001 : Problem
    {
        public Problem_0001()
            : base(1)
        {
        }

        public override string Question =>
            "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.\n" +
            "Find the sum of all the multiples of 3 or 5 below 1000.";

        public override Answer Answer => 233168;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            var multiples = new[] { 3, 5 };
            return SumOfMultiples(multiples, 1000);
        }

        private static int SumOfMultiples(int[] numbers, int limit)
        {
            var totalSum = 0;

            for (var i = 1; i < limit; i++)
            {
                if (numbers.Any(number => i % number == 0))
                {
                    totalSum += i;
                }
            }

            return totalSum;
        }
    }
}
