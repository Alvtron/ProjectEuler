namespace ProjectEuler.Mathematics.Combinatorics;

public static class Combinations
{
    /// <summary>
    /// Finds all possible combination subsets of the source of <paramref name="elements"/> in any order.
    /// </summary>
    /// <typeparam name="T">The type of elements to combine.</typeparam>
    /// <param name="elements">The elements to combine.</param>
    /// <param name="length">The target length of each subset combinations.</param>
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

        return FindCombinationsWithLength(list, length);
    }

    // Rosetta
    private static IEnumerable<IEnumerable<T>> FindCombinationsWithLength<T>(IReadOnlyList<T> array, int m)
    {
        var indices = new int[m];
        var stack = new Stack<int>(m);
        stack.Push(0);
        while (stack.Count > 0)
        {
            var index = stack.Count - 1;
            var value = stack.Pop();
            while (value < array.Count)
            {
                indices[index++] = value++;
                stack.Push(value);
                if (index != m)
                {
                    continue;
                }

                yield return indices.Select(i => array[i]);
                break;
            }
        }
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