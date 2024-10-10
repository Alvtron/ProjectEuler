using System.Numerics;
using ProjectEuler.Mathematics.Functions;

namespace ProjectEuler.Mathematics.Tests.Functions;

[TestFixture]
public class FactorialTests
{
    [Test]
    public void Of_Zero_ReturnsOne()
    {
        // Arrange
        var number = 1;

        // Act
        var result = Factorial.Of(number);

        // Assert
        Assert.That(result, Is.EqualTo(BigInteger.One), "Factorial of 0 should be 1.");
    }

    [Test]
    public void Of_One_ReturnsOne()
    {
        // Arrange
        var number = 1;

        // Act
        var result = Factorial.Of(number);

        // Assert
        Assert.That(result, Is.EqualTo(BigInteger.One), "Factorial of 1 should be 1.");
    }

    [Test]
    public void Of_SmallNumber_ReturnsCorrectFactorial()
    {
        // Arrange
        var number = 5;

        // Act
        var result = Factorial.Of(number);

        // Assert
        Assert.That(result, Is.EqualTo(new BigInteger(120)), "Factorial of 5 should be 120.");
    }

    [Test]
    public void Of_LargeNumber_ReturnsCorrectFactorial()
    {
        // Arrange
        var number = 10;

        // Act
        var result = Factorial.Of(number);

        // Assert
        Assert.That(result, Is.EqualTo(new BigInteger(3628800)), "Factorial of 10 should be 3,628,800.");
    }

    [Test]
    public void Of_VeryLargeNumber_ReturnsCorrectFactorial()
    {
        // Arrange
        var number = 99;

        // Act
        var result = Factorial.Of(number);

        // Assert
        Assert.That(result, Is.EqualTo(BigInteger.Parse("933262154439441526816992388562667004907159682643816214685929638952175999932299156089414639761565182862536979208272237582511852109168640000000000000000000000")));
    }

    [Test]
    public void Sum_SingleDigit_ReturnsFactorialOfDigit()
    {
        // Arrange
        var number = 5;

        // Act
        var result = Factorial.Sum(number);

        // Assert
        Assert.That(result, Is.EqualTo(120), "Sum of factorials of digits of 5 should be 120.");
    }

    [Test]
    public void Sum_MultipleDigits_ReturnsSumOfFactorialsOfDigits()
    {
        // Arrange
        var number = 145;

        // Act
        var result = Factorial.Sum(number);

        // Assert
        Assert.That(result, Is.EqualTo(145), "Sum of factorials of digits of 145 should be 145.");
    }

    [Test]
    public void Sum_LargeNumber_ReturnsCorrectSum()
    {
        // Arrange
        var number = long.MaxValue;

        // Act
        var result = Factorial.Sum(number);

        // Assert
        Assert.That(result, Is.EqualTo(464690), "Sum of factorials of digits of 9223372036854775807 should be 464690.");
    }

    [Test]
    public void Sum_NumberContainingZero_IgnoresZero()
    {
        // Arrange
        var number = 102;

        // Act
        var result = Factorial.Sum(number);

        // Assert
        Assert.That(result, Is.EqualTo(4), "Sum of factorials of digits of 102 should be 4.");
    }
}