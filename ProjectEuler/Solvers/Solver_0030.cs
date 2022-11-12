using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Extensions;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers;

public class Solver_0030 : ISolver
{
    public Answer Solve()
    {
        return FindSumOfPowers(5).Sum();
    }

    private static IEnumerable<double> FindSumOfPowers(int power)
    {
        var maxSum = Math.Pow(10, power + 1);
        for (var targetSum = 2; targetSum < maxSum; targetSum++)
        {
            var actualSum = (int)targetSum.Digits().Sum(digit => Math.Pow(digit, power));

            if (actualSum == targetSum)
            {
                yield return actualSum;
            }
        }
    }
}