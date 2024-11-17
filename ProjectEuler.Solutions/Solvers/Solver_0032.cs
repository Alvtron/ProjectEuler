using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0032 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var products = new HashSet<int>();

        for (var multiplicand = 1;; multiplicand++)
        {
            var multiplicandLength = multiplicand.Length();
            if (multiplicandLength + multiplicandLength + 1 > 9)
            {
                break;
            }

            for (var multiplier = multiplicand + 1;; multiplier++)
            {
                var product = multiplicand * multiplier;

                if (multiplicandLength + multiplier.Length() + product.Length() > 9)
                {
                    break;
                }

                if (PandigitalNumbers.IsZeroLessPandigital(CombinedNumbers.Combine(multiplicand, multiplier, product)))
                {
                    products.Add(product);
                }
            }
        }

        var sumOfProducts = products.Sum();
        return Task.FromResult<Answer>(sumOfProducts);
    }
}