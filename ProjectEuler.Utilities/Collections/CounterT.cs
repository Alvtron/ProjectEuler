namespace ProjectEuler.Utilities.Collections
{
    /// <summary>
    /// It provides methods for counting elements of equal type; both increment and decrement are supported.
    /// Counting elements has a guaranteed O(1) time complexity.
    /// </summary>
    /// <typeparam name="T">The type of the elements that are counted.</typeparam>
    public class Counter<T> : Dictionary<T, int>
        where T : notnull
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Counter{T}" /> class that is empty
        /// and uses the default <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        public Counter()
            : base(EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Counter{T}"/> class that is empty,
        /// and uses the specified <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <param name="comparer">The equality comparer.</param>
        public Counter(IEqualityComparer<T> comparer)
            : base(comparer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Counter{T}"/> class that
        /// contains elements copied from the specified <see cref="IDictionary{T,Int32}" />
        /// and uses the default <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <param name="data">The dictionary of data to be copied.</param>
        public Counter(IDictionary<T, int> data)
            : base(data, EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Counter{T}"/> class that
        /// contains elements copied from the specified <see cref="IDictionary{T,Int32}"/>
        /// and uses the provided <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <param name="data">The dictionary of data to be copied.</param>
        /// <param name="comparer">The equality comparer.</param>
        public Counter(IDictionary<T, int> data, IEqualityComparer<T> comparer)
            : base(data, comparer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Counter{T}"/> class that
        /// contains keys copied from the specified <see cref="IEnumerable{T}"/> with an initial start value,
        /// and uses the default <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <remarks>Duplicate keys are ignored.</remarks>
        /// <param name="keys">The keys to be copied.</param>
        /// <param name="startValue">The initial start value.</param>
        public Counter(IEnumerable<T> keys, int startValue)
            : this(keys, startValue, EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Counter{T}"/> class that
        /// contains keys copied from the specified <see cref="IEnumerable{T}"/> with an initial start value,
        /// and uses the provided <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <remarks>Duplicate keys are ignored.</remarks>
        /// <param name="keys">The keys to be copied.</param>
        /// <param name="startValue">The initial start value.</param>
        /// <param name="comparer">The equality comparer.</param>
        public Counter(IEnumerable<T> keys, int startValue, IEqualityComparer<T> comparer)
            : base(comparer)
        {
            if (keys is null)
            {
                throw new ArgumentNullException(nameof(keys));
            }

            foreach (var key in keys)
            {
                this[key] = startValue;
            }
        }

        public static Counter<T> operator +(Counter<T> counter, int value)
        {
            var result = counter.ToDictionary(kv => kv.Key, kv => kv.Value + value);

            return new Counter<T>(result);
        }

        public static Counter<T> operator +(Counter<T> first, IDictionary<T, int> second)
        {
            var combined = new Dictionary<T, int>(first);

            foreach (var kv in second)
            {
                if (combined.ContainsKey(kv.Key))
                {
                    combined[kv.Key] += kv.Value;
                }
                else
                {
                    combined[kv.Key] = kv.Value;
                }
            }

            return new Counter<T>(combined);
        }

        public static Counter<T> operator -(Counter<T> counter, int value)
        {
            var result = counter.ToDictionary(kv => kv.Key, kv => kv.Value - value);

            return new Counter<T>(result);
        }

        public static Counter<T> operator -(Counter<T> first, IDictionary<T, int> second)
        {
            var combined = new Dictionary<T, int>(first);

            foreach (var kv in second)
            {
                if (combined.ContainsKey(kv.Key))
                {
                    combined[kv.Key] -= kv.Value;
                }
                else
                {
                    combined[kv.Key] = -kv.Value;
                }
            }

            return new Counter<T>(combined);
        }

        /// <summary>
        /// Increments the key by one, if not a different value is specified.
        /// </summary>
        /// <param name="key">The key to be incremented.</param>
        /// <param name="by">The amount to increment.</param>
        public void Increment(T key, int by = 1)
        {
            this.AddIfNotExists(key);
            this[key] += by;
        }

        /// <summary>
        /// Decrements the key by one, if not a different value is specified.
        /// </summary>
        /// <param name="key">The key to be decremented.</param>
        /// <param name="by">The amount to decrement.</param>
        public void Decrement(T key, int by = 1)
        {
            this.AddIfNotExists(key);
            this[key] -= by;
        }

        /// <summary>
        /// Resets the key in the counter back to zero, if not a different value is specified.
        /// </summary>
        /// <param name="key">The key to reset.</param>
        /// <param name="to">Value to reset to.</param>
        public void Reset(T key, int to = 0)
        {
            if (!this.ContainsKey(key))
            {
                throw new KeyNotFoundException($"There is no count data on key '{key}'.");
            }

            this[key] = to;
        }

        /// <summary>
        /// Resets all keys in the counter to zero, if not a different value is specified.
        /// </summary>
        /// <param name="to">Value to reset to.</param>
        public void Reset(int to = 0)
        {
            foreach (var key in this.Keys.ToArray())
            {
                this[key] = to;
            }
        }

        /// <summary>
        /// Combines this counter with the other count data container.
        /// Any counts on matching keys are added together.
        /// The remaining counts stored on unmatched keys are included as they were.
        /// </summary>
        /// <param name="other">The other count data container.</param>
        public void Combine(IDictionary<T, int> other)
        {
            foreach (var kv in other)
            {
                if (this.ContainsKey(kv.Key))
                {
                    this[kv.Key] += kv.Value;
                }
                else
                {
                    this[kv.Key] = kv.Value;
                }
            }
        }

        /// <summary>
        /// If the key does not exists, this adds the key to the count dictionary with a count equal to zero.
        /// </summary>
        /// <param name="key">The key that is ensured to exist.</param>
        private void AddIfNotExists(T key)
        {
            if (this.ContainsKey(key))
            {
                return;
            }

            this[key] = 0;
        }
    }
}
