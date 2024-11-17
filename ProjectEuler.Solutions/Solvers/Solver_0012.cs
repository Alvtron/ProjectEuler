using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0012 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        const int NUMBER_OF_FACTORS = 500;

        foreach (var triangleNumber in GenerateTriangleNumbers())
        {
            var numberOfFactors = GetNumberOfFactorsOf(triangleNumber);
            if (numberOfFactors > NUMBER_OF_FACTORS)
            {
                return Task.FromResult<Answer>(triangleNumber);
            }
        }

        return Task.FromResult(Answer.Empty);
    }

    private static IEnumerable<int> GenerateTriangleNumbers()
    {
        for (var number = 1; true; number++)
        {
            yield return GetTriangleNumberAt(number);
        }
    }

    private static int GetTriangleNumberAt(int position)
    {
        return position * (position + 1) / 2;
    }

    private static int GetNumberOfFactorsOf(int number)
    {
        var factorCount = 0;
        var limit = (int)Math.Ceiling(Math.Sqrt(number));

        for (var divisor = 1; divisor < limit; divisor++)
        {
            if (number % divisor == 0)
            {
                // found a pair of factors
                factorCount += 2;
            }
        }

        // check if number is an exact square
        if (limit * limit == number)
        {
            factorCount++;
        }

        return factorCount;
    }
}