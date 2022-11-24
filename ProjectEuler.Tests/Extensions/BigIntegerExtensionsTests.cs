using System.Numerics;
using NUnit.Framework;
using ProjectEuler.Extensions.Extensions;

namespace ProjectEuler.Tests.Extensions;

[TestFixture]
public class BigIntegerExtensionsTests
{
    [Test]
    public void Length_PositiveNumber_ReturnsCorrectLength()
    {
        // ARRANGE
        var number = BigInteger.Pow(10, 1000);
        var actualLength = number.ToString().Length;

        // ACT
        var length = number.Length();

        // ASSERT
        Assert.That(length, Is.EqualTo(actualLength));
    }

    [Test]
    public void Length_NegativeNumber_ReturnsCorrectLength()
    {
        // ARRANGE
        var number = -BigInteger.Pow(10, 1000);
        var actualLength = number.ToString().Length - 1;

        // ACT
        var length = number.Length();

        // ASSERT
        Assert.That(length, Is.EqualTo(actualLength));
    }

    [Test]
    public void FirstDigits_PositiveNumber_ReturnsCorrectLength()
    {
        // ARRANGE
        var number = new BigInteger(123456789);
        const int numberOfDigits = 3;
        var actualDigits = new BigInteger(123);

        // ACT
        var digits = number.FirstDigits(numberOfDigits);

        // ASSERT
        Assert.That(digits, Is.EqualTo(actualDigits));
    }

    [Test]
    public void FirstDigits_NegativeNumber_ReturnsCorrectLength()
    {
        // ARRANGE
        var number = new BigInteger(-123456789);
        const int numberOfDigits = 4;
        var actualDigits = new BigInteger(-1234);

        // ACT
        var digits = number.FirstDigits(numberOfDigits);

        // ASSERT
        Assert.That(digits, Is.EqualTo(actualDigits));
    }

    [Test]
    public void LastDigits_PositiveNumber_ReturnsCorrectLength()
    {
        // ARRANGE
        var number = new BigInteger(123456789);
        const int numberOfDigits = 5;
        var actualDigits = new BigInteger(56789);

        // ACT
        var digits = number.LastDigits(numberOfDigits);

        // ASSERT
        Assert.That(digits, Is.EqualTo(actualDigits));
    }

    [Test]
    public void LastDigits_NegativeNumber_ReturnsCorrectLength()
    {
        // ARRANGE
        var number = new BigInteger(-123456789);
        const int numberOfDigits = 6;
        var actualDigits = new BigInteger(-456789);

        // ACT
        var digits = number.LastDigits(numberOfDigits);

        // ASSERT
        Assert.That(digits, Is.EqualTo(actualDigits));
    }
}