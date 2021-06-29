using System;
using System.Diagnostics;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunProblem(new Problem_0115());
        }

        public static void RunProblem(IProblem problem)
        {
            Console.WriteLine($"Question {problem.Number}:");
            Console.WriteLine($"{problem.Question}");

            var stopwatch = Stopwatch.StartNew();
            var solvedAnswer = problem.Solve();
            stopwatch.Stop();

            Console.WriteLine("-----------------------------");
            Console.Write($"The solved answer is {solvedAnswer}");

            if (!problem.IsSolved)
            {
                Console.WriteLine(", which must be assessed.");
            }
            else if (solvedAnswer.Equals(problem.Answer))
            {
                Console.WriteLine(", which is correct.");
            }
            else
            {
                Console.WriteLine($", which is incorrect. The correct answer should be '{problem.Answer}'.");
            }

            Console.WriteLine($"Elapsed time was {stopwatch.Elapsed.TotalMilliseconds} ms.");
            Console.WriteLine("-----------------------------");
        }
    }
}
