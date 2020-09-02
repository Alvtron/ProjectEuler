using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Data;
using ProjectEuler;
using System.Diagnostics;

namespace CodeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            RunProblem(new Problem_0702());
        }

        static void RunProblem(IProblem<long> problem)
        {
            Console.WriteLine();
            Console.WriteLine($"Question: {problem.Question}{Environment.NewLine}");
            var stopwatch = Stopwatch.StartNew();
            var answer = problem.Answer();
            stopwatch.Stop();
            Console.WriteLine($"The answer is: {answer}");
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine();
        }
    }
}
