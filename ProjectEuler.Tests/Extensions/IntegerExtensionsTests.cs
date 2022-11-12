using System;
using NUnit.Framework;
using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Extensions;

[TestFixture]
public class IntegerExtensionsTests
{
    [TestCase(0, 1)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(9, 1)]
    [TestCase(1000, 4)]
    [TestCase(1234, 4)]
    [TestCase(123456789, 9)]
    [TestCase(100000000, 9)]
    public void Length_PositiveNumber_ReturnsCorrectLength(int number, int actualLength)
    {
        // ACT
        var length = number.Length();

        // ASSERT
        Assert.That(length, Is.EqualTo(actualLength));
    }

    [TestCase(-1, 1)]
    [TestCase(-2, 1)]
    [TestCase(-9, 1)]
    [TestCase(-1000, 4)]
    [TestCase(-1234, 4)]
    [TestCase(-123456789, 9)]
    [TestCase(-100000000, 9)]
    public void Length_NegativeNumber_ReturnsCorrectLength(int number, int actualLength)
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
    public void Digits_PositiveNumber_ReturnsCorrectDigits(int number)
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
    public void Digits_NegativeNumber_ReturnsCorrectDigits(int number)
    {
        // ACT
        var digits = number.Digits();

        // ASSERT
        Assert.That(string.Concat(digits), Is.EqualTo(Math.Abs(number).ToString()));
    }

    [Test]
    public void FirstDigits_PositiveNumber_ReturnsCorrectLength()
    {
        // ARRANGE
        const int number = 123456789;
        const int numberOfDigits = 3;
        const int actualDigits = 123;

        // ACT
        var digits = number.FirstDigits(numberOfDigits);

        // ASSERT
        Assert.That(digits, Is.EqualTo(actualDigits));
    }

    [Test]
    public void FirstDigits_NegativeNumber_ReturnsCorrectLength()
    {
        // ARRANGE
        const int number = -123456789;
        const int numberOfDigits = 4;
        const int actualDigits = -1234;

        // ACT
        var digits = number.FirstDigits(numberOfDigits);

        // ASSERT
        Assert.That(digits, Is.EqualTo(actualDigits));
    }

    [Test]
    public void LastDigits_PositiveNumber_ReturnsCorrectLength()
    {
        // ARRANGE
        const int number = 123456789;
        const int numberOfDigits = 5;
        const int actualDigits = 56789;

        // ACT
        var digits = number.LastDigits(numberOfDigits);

        // ASSERT
        Assert.That(digits, Is.EqualTo(actualDigits));
    }

    [Test]
    public void LastDigits_NegativeNumber_ReturnsCorrectLength()
    {
        // ARRANGE
        const int number = -123456789;
        const int numberOfDigits = 6;
        const int actualDigits = -456789;

        // ACT
        var digits = number.LastDigits(numberOfDigits);

        // ASSERT
        Assert.That(digits, Is.EqualTo(actualDigits));
    }
}