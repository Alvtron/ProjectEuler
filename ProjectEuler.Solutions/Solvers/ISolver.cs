using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

public interface ISolver
{
    /// <summary>
    /// Attempts to solve the problem as an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    Task<Answer> SolveAsync(CancellationToken cancellationToken = default);
}