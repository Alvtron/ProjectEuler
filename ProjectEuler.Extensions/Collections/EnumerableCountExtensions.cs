namespace ProjectEuler.Extensions.Collections;

public static class EnumerableCountExtensions
{
    /// <summary>
    /// Check if the number of elements in the source is equal to the specified count.
    /// </summary>
    /// <remarks>
    /// This will never exhaust the source past the necessary number of elements.
    /// This is in almost all circumstances faster than .Count() == x, where x is an arbitrary <see cref="int"/>.<br/>
    /// If the source is a sequence that implements <see cref="ICollection{TSource}"/>, the Count-property is used instead.
    /// </remarks>
    /// <typeparam name="TSource">The element type in the source.</typeparam>
    /// <param name="source">The source of elements.</param>
    /// <param name="count">The number of elements that is checked.</param>
    /// <returns>True if the number of elements in the source is identical to the specified count; false otherwise.</returns>
    public static bool CountEquals<TSource>(this IEnumerable<TSource> source, int count)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (count < 0)
        {
            return false;
        }

        if (source is ICollection<TSource> collection)
        {
            return collection.Count == count;
        }

        if (count == 0)
        {
            return !source.Any();
        }

        using var enumerator = source.Skip(count - 1).GetEnumerator();
        return enumerator.MoveNext() && !enumerator.MoveNext();
    }

    /// <summary>
    /// Check if the number of elements in the source is higher than the specified count.
    /// </summary>
    /// <remarks>
    /// This will never exhaust the source past the necessary number of elements.
    /// This is in almost all circumstances faster than .Count() &gt; x, where x is an arbitrary <see cref="int"/>.<br/>
    /// If the source is a sequence that implements <see cref="ICollection{TSource}"/>, the Count-property is used instead.
    /// </remarks>
    /// <typeparam name="TSource">The element type in the source.</typeparam>
    /// <param name="source">The source of elements.</param>
    /// <param name="count">The number of elements that is checked.</param>
    /// <returns>True if the number of elements in the source is higher than the specified count; false otherwise.</returns>
    public static bool CountHigherThan<TSource>(this IEnumerable<TSource> source, int count)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (count < 0)
        {
            return true;
        }

        if (source is ICollection<TSource> collection)
        {
            return collection.Count > count;
        }

        return source.Skip(count).Any();
    }

    /// <summary>
    /// Check if the number of elements in the source is lower than the specified count.
    /// </summary>
    /// <remarks>
    /// This will never exhaust the source past the necessary number of elements.
    /// This is in almost all circumstances faster than .Count() &lt; x, where x is an arbitrary <see cref="int"/>.<br/>
    /// If the source is a sequence that implements <see cref="ICollection{TSource}"/>, the Count-property is used instead.
    /// </remarks>
    /// <typeparam name="TSource">The element type in the source.</typeparam>
    /// <param name="source">The source of elements.</param>
    /// <param name="count">The number of elements that is checked.</param>
    /// <returns>True if the number of elements in the source is lower than the specified count; false otherwise.</returns>
    public static bool CountLowerThan<TSource>(this IEnumerable<TSource> source, int count)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (count < 1)
        {
            return false;
        }

        if (source is ICollection<TSource> collection)
        {
            return collection.Count < count;
        }

        return !source.Skip(count - 1).Any();
    }
}