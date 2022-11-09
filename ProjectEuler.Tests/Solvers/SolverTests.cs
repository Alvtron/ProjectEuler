using NUnit.Framework;
using ProjectEuler.Library;
using ProjectEuler.Services;

namespace ProjectEuler.Tests.Solvers;

public class SolverTests
{
    private AnswerSource answerSource;
    private SolverService solverService;

    [OneTimeSetUp]
    public void SetUp()
    {
        this.answerSource = new AnswerSource();
        this.solverService = new SolverService();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        this.answerSource = null;
        this.solverService = null;
    }

    [Test]
    public void Solve_AllProblems_ReturnsCorrectAnswers([Range(1, ProjectEulerConstants.NUMBER_OF_PROBLEMS, 1)] int problemNumber)
    {
        this.RunSolverAndAssertAnswer(problemNumber);
    }

    [Test, Explicit]
    public void Solve_SpecificProblems_ReturnsCorrectAnswer([Values(1,2,3)] int problemNumber)
    {
        this.RunSolverAndAssertAnswer(problemNumber);
    }

    private void RunSolverAndAssertAnswer(int problemNumber)
    {
        if (!this.solverService.ContainsSolver(problemNumber))
        {
            Assert.Ignore($"Ignoring problem {problemNumber}. No solver exists.");
        }

        // ARRANGE
        var answer = this.answerSource.GetAnswer(problemNumber);
        var solver = this.solverService.GetSolver(problemNumber);

        // ACT
        var solvedAnswer = solver.Solve();

        // ASSERT
        Assert.That(solvedAnswer, Is.EqualTo(answer));
    }
}