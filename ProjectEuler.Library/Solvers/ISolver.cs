using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public interface ISolver
{
    /// <summary>
    /// Attempts to solve the problem as an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    Task<Answer> SolveAsync(CancellationToken cancellationToken = default);
}