using System.Diagnostics.CodeAnalysis;

namespace ProjectEuler.Library.Answers;

public readonly struct Answer : IEquatable<Answer>
{
    public Answer([NotNull] object value)
    {
        this.Value = value.ToString();
    }

    public string Value { get; }

    public static implicit operator Answer(bool value) => new(value);
    public static implicit operator Answer(short value) => new(value);
    public static implicit operator Answer(ushort value) => new(value);
    public static implicit operator Answer(byte value) => new(value);
    public static implicit operator Answer(int value) => new(value);
    public static implicit operator Answer(uint value) => new(value);
    public static implicit operator Answer(long value) => new(value);
    public static implicit operator Answer(ulong value) => new(value);
    public static implicit operator Answer(double value) => new(value);
    public static implicit operator Answer(decimal value) => new(value);
    public static implicit operator Answer(char value) => new(value);
    public static implicit operator Answer(string value) => new(value);

    public static Answer Empty => new(null);

    public override string ToString()
    {
        return this.Value;
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