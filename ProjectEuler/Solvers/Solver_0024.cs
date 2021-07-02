using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0024 : ISolver
    {
        public Answer Solve()
        {
            return CreatePermutations(0, 1, 2, 3, 4, 5, 6, 7, 8, 9).ElementAtOrDefault(1_000_000 - 1);
        }

        private static IEnumerable<int> CreatePermutations(params int[] digits)
        {
            for (var i = 0; i < digits.Length; i++)
            {
                yield return 0;
            }
        }
    }
}
