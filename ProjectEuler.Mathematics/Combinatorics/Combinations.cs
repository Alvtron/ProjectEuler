namespace ProjectEuler.Mathematics.Combinatorics;

public static class Combinations
{
    /// <summary>
    /// Returns all possible combination subsets of the <paramref name="elements"/> in any order.
    /// </summary>
    /// <typeparam name="T">The type of elements to combine.</typeparam>
    /// <param name="elements">The source of elements.</param>
    public static IEnumerable<T[]> Of<T>(IEnumerable<T> elements)
    {
        return elements.Aggregate(Enumerable.Empty<T[]>(), AggregateCombinations);
    }

    private static IEnumerable<T[]> AggregateCombinations<T>(IEnumerable<T[]> combinations, T element)
    {
        foreach (var combination in combinations)
        {
            yield return combination;
            yield return combination.Append(element).ToArray();
        }

        yield return new[] { element };
    }
}