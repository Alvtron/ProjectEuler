using System.Numerics;
using ProjectEuler.Library;
using ProjectEuler.Utilities;

namespace ProjectEuler.Solvers
{
    public class Solver_0025 : ISolver
    {
        public Answer Solve()
        {
            const int NUMBER_OF_DIGITS = 1000;
            var index = 0;

            foreach (var fibonacciNumber in FibonacciNumbers.Generate())
            {
                if (NumberOfDigitsOf(fibonacciNumber) == NUMBER_OF_DIGITS)
                {
                    return index;
                }

                index++;
            }

            return Answer.Empty;
        }

        private static int NumberOfDigitsOf(BigInteger number)
        {
            
            return (int)BigInteger.Log10(number) + 1;
        }
    }
}
