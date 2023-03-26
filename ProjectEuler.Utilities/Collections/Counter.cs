namespace ProjectEuler.Utilities.Collections
{
    public static class Counter
    {
        /// <summary>
        /// Counts the <paramref name="elements"/> using the provided <see cref="IEqualityComparer{T}"/>
        /// and returns a instance of the <see cref="Counter{T}"/> class that contains the result.
        /// </summary>
        /// <param name="elements">The elements that is counted.</param>
        public static Counter<TElement> Count<TElement>(IEnumerable<TElement> elements)
            where TElement : notnull
        {
            var counter = new Counter<TElement>();
            return CountUsingCounter(counter, elements);
        }

        /// <summary>
        /// Counts the <paramref name="elements"/> and returns a instance of the <see cref="Counter{T}"/> class that contains the result.
        /// </summary>
        /// <param name="elements">The elements that is counted.</param>
        /// <param name="comparer">The equality comparer.</param>
        public static Counter<TElement> Count<TElement>(IEnumerable<TElement> elements, IEqualityComparer<TElement> comparer)
            where TElement : notnull
        {
            var counter = new Counter<TElement>(comparer);
            return CountUsingCounter(counter, elements);
        }

        private static Counter<TElement> CountUsingCounter<TElement>(Counter<TElement> counter, IEnumerable<TElement> elements)
            where TElement : notnull
        {
            foreach (var element in elements)
            {
                counter.Increment(element);
            }

            return counter;
        }
    }
}
