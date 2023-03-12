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
}