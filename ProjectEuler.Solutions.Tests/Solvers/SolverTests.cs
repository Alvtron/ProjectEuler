using System.Collections;
using System.Diagnostics;
using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Solvers;

namespace ProjectEuler.Solutions.Tests.Solvers;

[TestFixture]
public class SolverTests
{
    private readonly AnswerSource answers = new();
    private readonly SolverService solverService = new();

    [TestCaseSource(typeof(ProblemNumberCases))]
    public async Task Solve_AllProblems_ReturnsCorrectAnswers(int problemNumber)
    {
        if (!this.solverService.CanSolve(problemNumber))
        {
            Assert.Ignore($"Ignoring problem {problemNumber}. No solver exists.");
            return;
        }

        if (!this.answers.HasAnswer(problemNumber))
        {
            Assert.Ignore($"Ignoring problem {problemNumber}. No answer exists.");
            return;
        }

        // ARRANGE
        var answer = this.answers.GetAnswer(problemNumber);
        var solver = this.solverService.GetSolver(problemNumber);

        // ACT
        var stopwatch = Stopwatch.StartNew();
        var solvedAnswer = await solver.SolveAsync();
        stopwatch.Stop();

        // ASSERT
        Assert.That(solvedAnswer, Is.EqualTo(answer), CreateFailureMessage(stopwatch.Elapsed, solvedAnswer, answer));
        Assert.Pass(CreateSuccessMessage(stopwatch.Elapsed, solvedAnswer));
    }

    private static string CreateFailureMessage(TimeSpan duration, Answer solvedAnswer, Answer actualAnswer)
    {
        return $"{solvedAnswer} in {PrettyDuration(duration)}. The correct answer should be {actualAnswer}.";
    }

    private static string CreateSuccessMessage(TimeSpan duration, Answer solvedAnswer)
    {
        return $"{solvedAnswer} in {PrettyDuration(duration)}.";
    }

    private static string PrettyDuration(TimeSpan duration)
    {
        return duration.TotalMilliseconds < 1000 ? $"{duration.TotalMilliseconds:F2} ms" : $"{duration.TotalSeconds:F2} s";
    }

    private sealed class ProblemNumberCases : IEnumerable
    {
        private readonly SolverService solverService = new();

        public IEnumerator GetEnumerator()
        {
            return this.solverService.SolvableProblems
                .Select(problem => new TestCaseData(problem).SetName($"Problem {problem:D4}"))
                .GetEnumerator();
        }
    }
}