using System.Collections.Immutable;
using ProjectEuler.Extensions.Numbers;
using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0043 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sum = FindDivisiblePandigitalNumbers().Sum();
        return Task.FromResult<Answer>(sum);
    }
     
    private static IEnumerable<long> FindDivisiblePandigitalNumbers()
    {
        const int span = 3;
        var digits = ImmutableHashSet.Create(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
        var dividends = ImmutableStack.Create(2, 3, 5, 7, 11, 13, 17);

        var largestNumber = CombinedNumbers.Combine(digits.Reverse().Take(span));
        var remainingDividends = dividends.Pop(out var largestDividend);
        
        for (var number = largestDividend; number <= largestNumber; number += largestDividend)
        {
            var initialPandigital = number.Length() != span 
                ? ImmutableList.CreateRange(number.Digits().Prepend(0)) 
                : ImmutableList.CreateRange(number.Digits());

            if (initialPandigital.Distinct().Count() != span)
            {
                continue;
            }

            foreach (var divisiblePandigital in FindDivisiblePandigitalNumbers(initialPandigital, remainingDividends, digits.Except(initialPandigital)))
            {
                yield return divisiblePandigital;
            }
        }
    }

    private static IEnumerable<long> FindDivisiblePandigitalNumbers(ImmutableList<int> pandigital, ImmutableStack<int> dividends, ImmutableHashSet<int> remainingDigits)
    {
        if (dividends.IsEmpty)
        {
            yield return CombinedNumbers.Combine(remainingDigits.Concat(pandigital));
            yield break;
        }

        dividends = dividends.Pop(out var dividend);

        foreach (var digit in remainingDigits)
        {
            var nextPandigital = pandigital.Insert(0, digit);
            var combine = CombinedNumbers.Combine(nextPandigital.Take(3));
            if (combine % dividend != 0)
            {
                continue;
            }

            foreach (var finalPandigital in FindDivisiblePandigitalNumbers(nextPandigital, dividends, remainingDigits.Remove(digit)))
            {
                yield return finalPandigital;
            }
        }
    }
}