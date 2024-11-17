using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0008 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var greatestProductOfAdjacentDigits = GreatestProductOfAdjacentDigits(Resource_0008.LargeNumber, 13);
        return Task.FromResult<Answer>(greatestProductOfAdjacentDigits);
    }

    private static long GreatestProductOfAdjacentDigits(string largeNumber, int numberOfDigits)
    {
        long largestProduct = 0;

        for (var i = 0; i < largeNumber.Length - numberOfDigits + 1; i++)
        {
            var currentDigits = largeNumber.Substring(i, numberOfDigits);
            long currentProduct = 1;

            foreach (var digit in currentDigits)
            {
                currentProduct *= long.Parse(digit.ToString());
            }

            if (largestProduct < currentProduct)
            {
                largestProduct = currentProduct;
            }
        }

        return largestProduct;
    }
}