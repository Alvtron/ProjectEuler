using ProjectEuler.Extensions.Numbers;

namespace ProjectEuler.Extensions.Tests.Numbers;

[TestFixture]
public class LongExtensionsTests
{
    [TestCase(0L, 1)]
    [TestCase(1L, 1)]
    [TestCase(2L, 1)]
    [TestCase(9L, 1)]
    [TestCase(1000L, 4)]
    [TestCase(1234L, 4)]
    [TestCase(123456789L, 9)]
    [TestCase(100000000L, 9)]
    [TestCase(long.MaxValue, 19)]
    public void Length_PositiveNumber_ReturnsCorrectLength(long number, int actualLength)
    {
        // ACT
        var length = number.Length();

        // ASSERT
        Assert.That(length, Is.EqualTo(actualLength));
    }

    [TestCase(-1L, 1)]
    [TestCase(-2L, 1)]
    [TestCase(-9L, 1)]
    [TestCase(-1000L, 4)]
    [TestCase(-1234L, 4)]
    [TestCase(-123456789L, 9)]
    [TestCase(-100000000L, 9)]
    [TestCase(long.MinValue, 19)]
    public void Length_NegativeNumber_ReturnsCorrectLength(long number, int actualLength)
    {
        // ACT
        var length = number.Length();

        // ASSERT
        Assert.That(length, Is.EqualTo(actualLength));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(1000)]
    [TestCase(1234)]
    [TestCase(123456789)]
    [TestCase(100000000)]
    [TestCase(999999999)]
    [TestCase(1000000000)]
    [TestCase(9999999999)]
    [TestCase(10000000000)]
    [TestCase(99999999999)]
    [TestCase(100000000000)]
    [TestCase(999999999999)]
    [TestCase(1000000000000)]
    [TestCase(9999999999999)]
    [TestCase(10000000000000)]
    [TestCase(99999999999999)]
    [TestCase(100000000000000)]
    [TestCase(999999999999999)]
    [TestCase(1000000000000000)]
    [TestCase(9999999999999999)]
    [TestCase(10000000000000000)]
    [TestCase(99999999999999999)]
    [TestCase(100000000000000000)]
    [TestCase(999999999999999999)]
    [TestCase(1000000000000000000)]
    public void Digits_PositiveNumber_ReturnsCorrectDigits(long number)
    {
        // ACT
        var digits = number.Digits();

        // ASSERT
        Assert.That(string.Concat(digits), Is.EqualTo(number.ToString()));
    }

    [TestCase(-0)]
    [TestCase(-1)]
    [TestCase(-2)]
    [TestCase(-1000)]
    [TestCase(-1234)]
    [TestCase(-123456789)]
    [TestCase(-100000000)]
    [TestCase(-999999999)]
    [TestCase(-1000000000)]
    [TestCase(-9999999999)]
    [TestCase(-10000000000)]
    [TestCase(-99999999999)]
    [TestCase(-100000000000)]
    [TestCase(-999999999999)]
    [TestCase(-1000000000000)]
    [TestCase(-9999999999999)]
    [TestCase(-10000000000000)]
    [TestCase(-99999999999999)]
    [TestCase(-100000000000000)]
    [TestCase(-999999999999999)]
    [TestCase(-1000000000000000)]
    [TestCase(-9999999999999999)]
    [TestCase(-10000000000000000)]
    [TestCase(-99999999999999999)]
    [TestCase(-100000000000000000)]
    [TestCase(-999999999999999999)]
    [TestCase(-1000000000000000000)]
    public void Digits_NegativeNumber_ReturnsCorrectDigits(long number)
    {
        // ACT
        var digits = number.Digits();

        // ASSERT
        Assert.That(string.Concat(digits), Is.EqualTo(Math.Abs(number).ToString()));
    }
}