using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Helpers;

public static class Permutations
{
    /// <summary>
    /// Returns all possible permutations of the <paramref name="elements"/> in a specific order.
    /// </summary>
    /// <typeparam name="T">The type of elements to permutate.</typeparam>
    /// <param name="elements">The source of elements.</param>
    public static IEnumerable<T[]> Of<T>(IEnumerable<T> elements)
    {
        return elements.Aggregate(Enumerable.Empty<T[]>(), AggregatePermutations);
    }

    private static IEnumerable<T[]> AggregatePermutations<T>(IEnumerable<T[]> combinations, T element)
    {
        foreach (var combination in combinations)
        {
            yield return combination;
            yield return combination.Prepend(element).ToArray();
            yield return combination.Append(element).ToArray();
        }

        yield return new[] { element };
    }
}
