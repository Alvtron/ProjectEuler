using System.Collections;
using System.Diagnostics;
using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Solvers;

namespace ProjectEuler.Solutions.Tests.Solvers;

[TestFixture]
public class SolverTests
{
    private AnswerSource answers;
    private SolverService solverService;

    [OneTimeSetUp]
    public void SetUp()
    {
        this.answers = new AnswerSource();
        this.solverService = new SolverService();
    }

    [TestCaseSource(typeof(ProblemNumberCases))]
    public async Task Solve_AllProblems_ReturnsCorrectAnswers(int problemNumber)
    {
        await this.RunSolverAndAssertAnswer(problemNumber);
    }

    [Test, Explicit]
    public async Task Solve_SpecificProblems_ReturnsCorrectAnswer([Values(1,2,3)] int problemNumber)
    {
        await this.RunSolverAndAssertAnswer(problemNumber);
    }

    private async Task RunSolverAndAssertAnswer(int problemNumber)
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
        Assert.That(solvedAnswer, Is.EqualTo(answer), CreateFailureMessage(stopwatch, solvedAnswer, answer));
        Assert.Pass(CreateSuccessMessage(stopwatch, solvedAnswer));
    }

    private static string CreateFailureMessage(Stopwatch stopwatch, Answer solvedAnswer, Answer actualAnswer)
    {
        return $"{solvedAnswer} in {stopwatch.Elapsed.TotalMilliseconds:#.00} ms. " +
               $"The correct answer should be {actualAnswer}.";
    }

    private static string CreateSuccessMessage(Stopwatch stopwatch, Answer solvedAnswer)
    {
        return $"{solvedAnswer}, in {stopwatch.Elapsed.TotalMilliseconds:#.00} ms.";
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