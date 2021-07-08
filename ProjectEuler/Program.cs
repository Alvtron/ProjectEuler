using System;
using System.Diagnostics;
using ProjectEuler.Library;
using ProjectEuler.Services;

namespace ProjectEuler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Solve(0001, 0002, 0003);
        }

        private static void Solve(params int[] numbers)
        {
            var answerSource = new AnswerSource();
            var problemSource = new ProblemSource();
            var solverService = new SolverService();

            foreach (var number in numbers)
            {
                if (!solverService.ContainsSolver(number))
                {
                    Console.WriteLine($"Warning: No solver exists for problem {number}.");
                    continue;
                }

                var answer = answerSource.GetAnswer(number);
                var problem = problemSource.GetProblem(number);
                var solver = solverService.GetSolver(number);

                RunProblem(problem, solver, answer);
            }
        }

        private static void SolveAll()
        {
            var answerSource = new AnswerSource();
            var problemSource = new ProblemSource();
            var solverService = new SolverService();

            for (var number = 1; number <= ProjectEulerConstants.NUMBER_OF_PROBLEMS; number++)
            {
                if (!solverService.ContainsSolver(number))
                {
                    Console.WriteLine($"Warning: No solver exists for problem {number}.");
                    continue;
                }

                var answer = answerSource.GetAnswer(number);
                var problem = problemSource.GetProblem(number);
                var solver = solverService.GetSolver(number);

                RunProblem(problem, solver, answer);
            }
        }

        private static void RunProblem(IProblem problem, ISolver solver, Answer answer)
        {
            Console.WriteLine($"Question {problem.Number}: {problem.Title}");
            Console.WriteLine($"{problem.Description}");

            var stopwatch = Stopwatch.StartNew();
            var solvedAnswer = solver.Solve();
            stopwatch.Stop();

            Console.WriteLine("-----------------------------");
            Console.Write($"The solved answer is {solvedAnswer}");

            Console.WriteLine(solvedAnswer.Equals(answer)
                ? ", which is correct."
                : $", which is incorrect. The correct answer should be '{answer}'.");

            Console.WriteLine($"Elapsed time was {stopwatch.Elapsed.TotalMilliseconds} ms.");
            Console.WriteLine("-----------------------------");
        }
    }
}
