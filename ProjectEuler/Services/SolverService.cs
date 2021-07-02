using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProjectEuler.Library;

namespace ProjectEuler.Services
{
    public class SolverService
    {
        private readonly Dictionary<int, Type> Source;

        public SolverService()
        {
            var assembly = Assembly.GetExecutingAssembly();
            const string NAMESPACE = "ProjectEuler.Solvers";

            var solvers = assembly.GetTypes().Where(type => type.Namespace == NAMESPACE && type.Name.StartsWith("Solver"));

            this.Source = solvers.ToDictionary(GetNumberFromSolverType, type => type);
        }

        public bool ContainsSolver(int number)
        {
            return this.Source.ContainsKey(number);
        }

        public ISolver GetSolver(int number)
        {
            var solverType = this.Source[number];
            return CreateInstanceOfSolverType(solverType);
        }

        private static ISolver CreateInstanceOfSolverType(Type type)
        {
            return (ISolver)Activator.CreateInstance(type);
        }

        private static int GetNumberFromSolverType(Type type)
        {
            var number = type.Name.Split('_').Last();
            return int.Parse(number);
        }
    }
}
