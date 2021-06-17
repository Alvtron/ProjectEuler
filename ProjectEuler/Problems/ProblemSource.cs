using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public static class ProblemSource
    {
        public static IEnumerable<IProblem> All => GetProblems();

        public static IEnumerable<IProblem> Solved => All.Where(problem => problem.IsSolved);

        public static IEnumerable<IProblem> Unsolved => All.Where(problem => !problem.IsSolved);

        private static IEnumerable<IProblem> GetProblems()
        {
            yield return new Problem_0001();
            yield return new Problem_0002();
            yield return new Problem_0005();
            yield return new Problem_0006();
            yield return new Problem_0008();
            yield return new Problem_0011();
            yield return new Problem_0013();
            yield return new Problem_0014();
            yield return new Problem_0015();
            yield return new Problem_0017();
            yield return new Problem_0018();
            yield return new Problem_0024();
            yield return new Problem_0067();
            yield return new Problem_0702();
        }
    }
}
