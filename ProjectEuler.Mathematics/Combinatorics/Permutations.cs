namespace ProjectEuler.Mathematics.Combinatorics;

public static class Permutations
{
    /// <summary>
    /// Finds all possible permutations of the <paramref name="elements"/> in lexicographic order.
    /// </summary>
    /// <typeparam name="T">The type of elements to permutate.</typeparam>
    /// <param name="elements">The source of elements.</param>
    public static IEnumerable<IEnumerable<T>> Of<T>(IEnumerable<T> elements)
    {
        ArgumentNullException.ThrowIfNull(elements, nameof(elements));

        var list = ConvertToList(elements);
        return FindPermutationsInLexicographicOrder(list, list.Count);
    }

    /// <summary>
    /// Finds all possible permutations of the <paramref name="elements"/> in lexicographic order.
    /// </summary>
    /// <typeparam name="T">The type of elements to permutate.</typeparam>
    /// <param name="elements">The source of elements.</param>
    /// <param name="length">The length of each permutation set.</param>
    public static IEnumerable<IEnumerable<T>> Of<T>(IEnumerable<T> elements, int length)
    {
        ArgumentNullException.ThrowIfNull(elements, nameof(elements));

        if (length < 0)
        {
            throw new ArgumentException("The length was negative.", nameof(length));
        }

        var list = ConvertToList(elements);
        if (list.Count < length)
        {
            throw new ArgumentException("The length was greater than the number of elements.", nameof(length));
        }

        return FindPermutationsInLexicographicOrder(list, length);
    }

    private static IEnumerable<IEnumerable<T>> FindPermutationsInLexicographicOrder<T>(IReadOnlyList<T> elements, int length)
    {
        switch (elements.Count)
        {
            case 0:
                yield break;
            case 1:
                yield return elements;
                yield break;
        }

        var indices = Enumerable.Range(0, elements.Count).ToArray();

        var lastIndex = indices.Length - 1;
        var nextToLastIndex = indices.Length - 2;

        while (true)
        {
            yield return indices.Select(index => elements[index]).Take(length);

            var firstIndex = nextToLastIndex;
            while (firstIndex >= 0 && indices[firstIndex] > indices[firstIndex + 1])
            {
                firstIndex--;
            }

            if (firstIndex < 0)
            {
                break;
            }

            var secondIndex = lastIndex;
            while (indices[firstIndex] > indices[secondIndex])
            {
                secondIndex--;
            }

            Swap(indices, firstIndex, secondIndex);
            SwapRange(indices, firstIndex + 1, lastIndex);
        }
    }

    private static void SwapRange<T>(IList<T> elements, int fromIndex, int toIndex)
    {
        while (fromIndex < toIndex)
        {
            Swap(elements, fromIndex, toIndex);
            fromIndex++;
            toIndex--;
        }
    }

    private static void Swap<T>(IList<T> elements, int firstIndex, int secondIndex)
    {
        (elements[firstIndex], elements[secondIndex]) = (elements[secondIndex], elements[firstIndex]);
    }

    private static IReadOnlyList<T> ConvertToList<T>(IEnumerable<T> elements)
    {
        if (elements is not IReadOnlyList<T> list)
        {
            list = elements.ToArray();
        }

        return list;
    }
}
