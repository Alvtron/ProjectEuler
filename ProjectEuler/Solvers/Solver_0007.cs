using System.Linq;
using ProjectEuler.Library;
using ProjectEuler.Numerics;

namespace ProjectEuler.Solvers;

public class Solver_0007 : ISolver
{
    public Answer Solve()
    {
        return PrimeNumbers.Generate().ElementAt(10_001 - 1);
    }
}