﻿using ProjectEuler.Mathematics.Numbers;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0046 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var smallestComposite = FindSmallestCompositeRefutingGoldbach();
        return await Task.FromResult(smallestComposite);
    }

    private static Answer FindSmallestCompositeRefutingGoldbach()
    {
        foreach (var composite in CompositeNumbers.Generate().Where(long.IsOddInteger))
        {
            var any = false;

            foreach (var prime in PrimeNumbers.Generate().Where(long.IsOddInteger))
            {
                if (prime > composite - 2L)
                {
                    break;
                }

                if (SquareNumbers.IsSquare((composite - prime) / 2L))
                {
                    any = true;
                }
            }

            if (!any)
            {
                return composite;
            }
        }

        throw new InvalidOperationException("Unable to disprove Goldbach's.");
    }
}