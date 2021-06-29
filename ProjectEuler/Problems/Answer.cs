using System;

namespace ProjectEuler.Problems
{
    public readonly struct Answer : IEquatable<Answer>
    {
        public Answer(object value)
        {
            this.Type = value.GetType();
            this.Value = value;
        }

        public Type Type { get; }

        public object Value { get; }

        public static implicit operator Answer(byte value) => new (value);
        public static implicit operator Answer(int value) => new (value);
        public static implicit operator Answer(long value) => new (value);
        public static implicit operator Answer(double value) => new (value);
        public static implicit operator Answer(decimal value) => new (value);
        public static implicit operator Answer(char value) => new (value);
        public static implicit operator Answer(string value) => new (value);

        public static Answer Empty => new("Unsolved");

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public bool Equals(Answer other)
        {
            return Equals(this.Value, other.Value);
        }

        public override int GetHashCode()
        {
            return this.Value?.GetHashCode() ?? 0;
        }
    }
}