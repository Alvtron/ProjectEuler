using ProjectEuler.Mathematics.Functions;

namespace ProjectEuler.Mathematics.Tests.Functions;

[TestFixture]
public class GreatestCommonDivisorTests
{
    [Test]
    public void Of_PositiveNumbers_ReturnsCorrectResult()
    {
        // Test case with common positive integers
        Assert.That(GreatestCommonDivisor.Of(54, 24), Is.EqualTo(6));
        Assert.That(GreatestCommonDivisor.Of(48, 18), Is.EqualTo(6));
    }

    [Test]
    public void Of_OneNumberIsZero_ReturnsOtherNumber()
    {
        // GCD with one number as zero should return the absolute value of the other number
        Assert.That(GreatestCommonDivisor.Of(0, 5), Is.EqualTo(5));
        Assert.That(GreatestCommonDivisor.Of(5, 0), Is.EqualTo(5));
    }

    [Test]
    public void Of_BothNumbersZero_ReturnsZero()
    {
        // GCD of zero and zero is typically defined as zero
        Assert.That(GreatestCommonDivisor.Of(0, 0), Is.EqualTo(0));
    }

    [Test]
    public void Of_NegativeNumbers_ReturnsPositiveGCD()
    {
        // GCD should always be positive, even if the inputs are negative
        Assert.That(GreatestCommonDivisor.Of(-54, 24), Is.EqualTo(6));
        Assert.That(GreatestCommonDivisor.Of(54, -24), Is.EqualTo(6));
        Assert.That(GreatestCommonDivisor.Of(-48, -18), Is.EqualTo(6));
    }

    [Test]
    public void Of_PrimeNumbers_ReturnsOne()
    {
        // GCD of two prime numbers should always be 1
        Assert.That(GreatestCommonDivisor.Of(13, 17), Is.EqualTo(1));
        Assert.That(GreatestCommonDivisor.Of(19, 29), Is.EqualTo(1));
    }

    [Test]
    public void Of_EqualNumbers_ReturnsSameNumber()
    {
        // GCD of two equal numbers should return the number itself
        Assert.That(GreatestCommonDivisor.Of(25, 25), Is.EqualTo(25));
        Assert.That(GreatestCommonDivisor.Of(123456, 123456), Is.EqualTo(123456));
    }

    [Test]
    public void Of_LargePositiveNumbers_ReturnsCorrectResult()
    {
        // Testing GCD for large numbers to ensure the algorithm handles large inputs efficiently
        Assert.That(GreatestCommonDivisor.Of(123456789101112, 98765432123456), Is.EqualTo(8));
        Assert.That(GreatestCommonDivisor.Of(long.MaxValue, long.MaxValue - 1), Is.EqualTo(1));
        Assert.That(GreatestCommonDivisor.Of(long.MaxValue, long.MaxValue), Is.EqualTo(long.MaxValue));
    }

    [Test]
    public void Of_LargeNegativeNumbers_ReturnsCorrectResult()
    {
        // Testing GCD for large numbers to ensure the algorithm handles large inputs efficiently
        Assert.That(GreatestCommonDivisor.Of(-123456789101112, -98765432123456), Is.EqualTo(8));
        Assert.That(GreatestCommonDivisor.Of(long.MinValue, long.MinValue + 1), Is.EqualTo(1));
        Assert.That(GreatestCommonDivisor.Of(long.MinValue, long.MinValue), Is.EqualTo(long.MinValue));
    }

    [Test]
    public void Of_OneIsMultipleOfOther_ReturnsSmallerNumber()
    {
        // If one number is a multiple of the other, the GCD should be the smaller number
        Assert.That(GreatestCommonDivisor.Of(21, 7), Is.EqualTo(7));
        Assert.That(GreatestCommonDivisor.Of(100, 10), Is.EqualTo(10));
    }
}