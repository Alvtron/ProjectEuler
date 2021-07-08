using ProjectEuler.Library;
using ProjectEuler.Numerics;

namespace ProjectEuler.Solvers
{
    public class Solver_0010 : ISolver
    {
        public Answer Solve()
        {
            return SumOfPrimesBelow(2_000_000);
        }

        private static long SumOfPrimesBelow(long limit)
        {
            var sum = 0L;

            foreach (var prime in PrimeNumbers.Generate())
            {
                if (prime >= limit)
                {
                    break;
                }

                sum += prime;
            }

            return sum;
        }
    }
}
