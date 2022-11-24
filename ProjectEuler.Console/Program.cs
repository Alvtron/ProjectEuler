using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ProjectEuler.Library.Answers;
using ProjectEuler.Library.Problems;
using ProjectEuler.Library.Solvers;

namespace ProjectEuler.Console;

public class Program
{
    public static async Task Main()
    {
        await SolveAsync(0001, 0002, 0003);
    }

    private static async Task SolveAsync(params int[] numbers)
    {
        var answerSource = new AnswerSource();
        var problemSource = new ProblemSource();
        var solverService = new SolverService();

        foreach (var number in numbers)
        {
            if (!solverService.CanSolve(number))
            {
                throw new ArgumentException($"No solver exists for problem {number}.", nameof(number));
            }

            if (!answerSource.HasAnswer(number))
            {
                throw new ArgumentException($"No answer exists for problem {number}.", nameof(number));
            }

            var answer = answerSource.GetAnswer(number);
            var problem = await problemSource.GetProblemAsync(number);
            var solver = solverService.GetSolver(number);

            await RunProblemAsync(problem, solver, answer);
        }
    }

    private static async Task RunProblemAsync(IProblem problem, ISolver solver, Answer answer)
    {
        System.Console.WriteLine($"Question {problem.Number}: {problem.Title}");
        System.Console.WriteLine($"{problem.Description}");

        var stopwatch = Stopwatch.StartNew();
        var solvedAnswer = await solver.SolveAsync();
        stopwatch.Stop();

        System.Console.WriteLine("-----------------------------");
        System.Console.Write($"The solved answer is {solvedAnswer}");

        System.Console.WriteLine(solvedAnswer.Equals(answer)
            ? ", which is correct."
            : $", which is incorrect. The correct answer should be '{answer}'.");

        System.Console.WriteLine($"Elapsed time was {stopwatch.Elapsed.TotalMilliseconds} ms.");
        System.Console.WriteLine("-----------------------------");
    }
}