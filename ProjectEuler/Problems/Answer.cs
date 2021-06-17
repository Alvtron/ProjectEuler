using System;

namespace ProjectEuler.Problems
{
    public class Answer : IEquatable<Answer>
    {
        public Answer(object value)
        {
            this.Type = value.GetType();
            this.Value = value;
        }

        public Type Type { get; private init; }

        public object Value { get; private init; }

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
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(this.Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Answer) obj);
        }

        public override int GetHashCode()
        {
            return (this.Value != null ? this.Value.GetHashCode() : 0);
        }
    }
}