using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

public class Solver_0008 : ISolver
{
    private static readonly string NumberFilePath = ResourcesHelper.GetResourcePath("problem_0008_number.txt");

    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var number = await File.ReadAllTextAsync(NumberFilePath, cancellationToken);
        var greatestProductOfAdjacentDigits = GreatestProductOfAdjacentDigits(number, 13);
        return await Task.FromResult(greatestProductOfAdjacentDigits);
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