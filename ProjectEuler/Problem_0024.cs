using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem_0024 : IProblem<long>
    {
        private static IEnumerable<int> CreatePermutations(params int[] digits)
        {
            for (var i = 0; i < digits.Length; i++)
            {
                yield return 0;
            }
        }

        public string Question { get; }

        public long Answer()
        {
            return CreatePermutations(0, 1, 2, 3, 4, 5, 6, 7, 8, 9).ElementAtOrDefault(1_000_000 - 1);
        }
    }
}
