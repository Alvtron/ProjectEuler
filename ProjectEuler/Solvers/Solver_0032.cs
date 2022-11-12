using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Extensions;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers;

public class Solver_0032 : ISolver
{
    private static readonly int[] allDigits = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public Answer Solve()
    {
        var products = new HashSet<int>();

        for (var multiplicand = 1;; multiplicand++)
        {
            var multiplicandLength = multiplicand.Length();
            if (multiplicandLength + multiplicandLength + 1 > allDigits.Length)
            {
                break;
            }

            for (var multiplier = multiplicand + 1;; multiplier++)
            {
                var product = multiplicand * multiplier;

                if (multiplicandLength + multiplier.Length() + product.Length() > allDigits.Length)
                {
                    break;
                }

                if (IsPandigital(multiplicand, multiplier, product))
                {
                    products.Add(product);
                }
            }
        }

        return products.Sum();
    }

    private static bool IsPandigital(params int[] numbers)
    {
        var digits = numbers.SelectMany(n => n.Digits());
        return IsPandigital(digits);
    }

    private static bool IsPandigital(IEnumerable<int> digits)
    {
        var set = new HashSet<int>();
        return digits.All(set.Add) && set.Count == allDigits.Length && !set.Contains(0);
    }
}