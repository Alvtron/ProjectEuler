using System.Linq;
using ProjectEuler.Library;
using ProjectEuler.Utilities;

namespace ProjectEuler.Solvers
{
    public class Solver_0007 : ISolver
    {
        public Answer Solve()
        {
            var primeGenerator = new PrimeGenerator();
            return primeGenerator.GetPrimes().ElementAt(10_001 - 1);
        }
    }
}
