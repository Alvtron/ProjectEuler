using System.Reflection;

namespace ProjectEuler.Library.Solvers;

public class SolverService
{
    private readonly Dictionary<int, Type> cache;

    public SolverService()
    {
        this.cache = GetSolverTypes().ToDictionary(GetNumberFromSolverType);
    }

    public IReadOnlyCollection<int> SolvableProblems => this.cache.Keys;

    public bool CanSolve(int problemNumber)
    {
        return this.cache.ContainsKey(problemNumber);
    }

    public ISolver GetSolver(int number)
    {
        if (!this.cache.TryGetValue(number, out var solverType))
        {
            throw new ArgumentException($"The solver for problem {number} does not exist.", nameof(number));
        }

        return CreateSolver(solverType);
    }

    private static int GetNumberFromSolverType(Type type)
    {
        var number = type.Name.Split('_').Last();
        return int.Parse(number);
    }

    private static IEnumerable<Type> GetSolverTypes()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var solverNamespace = typeof(Solver_0001).Namespace;

        return assembly.GetTypes().Where(type =>
            type.Namespace == solverNamespace && type.Name.StartsWith("Solver_", StringComparison.Ordinal));
    }

    private static ISolver CreateSolver(Type solverType)
    {
        var solverObject = Activator.CreateInstance(solverType);
        if (solverObject is not ISolver solver)
        {
            throw new InvalidOperationException("Unable to create solver from solver type.");
        }

        return solver;
    }
}