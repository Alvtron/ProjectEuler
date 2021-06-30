using System.Linq;

namespace ProjectEuler.Library
{
    public class Cache<T>
    {
        private readonly T defaultValue;
        private readonly T[] cache;

        public Cache(int size, T defaultValue)
        {
            this.defaultValue = defaultValue;
            this.cache = Enumerable.Repeat(defaultValue, size).ToArray();
        }

        public T this[int index]
        {
            get => this.cache[index];
            set => this.cache[index] = value;
        }

        public bool ContainsValue(int index) => !this[index].Equals(this.defaultValue);

        public bool TryGetValue(int index, out T value)
        {
            value = this.cache[index];
            return this.ContainsValue(index);
        }
    }
}