using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class CyclicNumbersTests
{
    [TestCase(0, new long[] { 0 })]
    [TestCase(1, new long[] { 1 })]
    [TestCase(12, new long[] { 12, 21 })]
    [TestCase(123, new long[] { 123, 231, 312 })]
    [TestCase(1234, new long[] { 1234, 2341, 3412, 4123 })]
    [TestCase(12345, new long[] { 12345, 23451, 34512, 45123, 51234 })]
    public void CycleLeft_PositiveNumbers_ReturnsCyclicNumbers(long number, long[] expectedCyclicNumbers)
    {
        // Act
        var cyclicNumbers = CyclicNumbers.CycleLeft(number);

        // Assert
        Assert.That(cyclicNumbers, Is.EqualTo(expectedCyclicNumbers));
    }

    [TestCase(-1, new long[] { -1 })]
    [TestCase(-12, new long[] { -12, -21 })]
    [TestCase(-123, new long[] { -123, -231, -312 })]
    [TestCase(-1234, new long[] { -1234, -2341, -3412, -4123 })]
    [TestCase(-12345, new long[] { -12345, -23451, -34512, -45123, -51234 })]
    public void CycleLeft_NegativeNumbers_ReturnsCyclicNumbers(long number, long[] expectedCyclicNumbers)
    {
        // Act
        var cyclicNumbers = CyclicNumbers.CycleLeft(number);

        // Assert
        Assert.That(cyclicNumbers, Is.EqualTo(expectedCyclicNumbers));
    }

    [TestCase(0, new long[] { 0 })]
    [TestCase(1, new long[] { 1 })]
    [TestCase(12, new long[] { 12, 21 })]
    [TestCase(123, new long[] { 123, 312, 231 })]
    [TestCase(1234, new long[] { 1234, 4123, 3412, 2341 })]
    [TestCase(12345, new long[] { 12345, 51234, 45123, 34512, 23451 })]
    public void CycleRight_PositiveNumbers_ReturnsCyclicNumbers(long number, long[] expectedCyclicNumbers)
    {
        // Act
        var cyclicNumbers = CyclicNumbers.CycleRight(number);

        // Assert
        Assert.That(cyclicNumbers, Is.EqualTo(expectedCyclicNumbers));
    }

    [TestCase(-1, new long[] { -1 })]
    [TestCase(-12, new long[] { -12, -21 })]
    [TestCase(-123, new long[] { -123, -312, -231 })]
    [TestCase(-1234, new long[] { -1234, -4123, -3412, -2341 })]
    [TestCase(-12345, new long[] { -12345, -51234, -45123, -34512, -23451 })]
    public void CycleRight_NegativeNumbers_ReturnsCyclicNumbers(long number, long[] expectedCyclicNumbers)
    {
        // Act
        var cyclicNumbers = CyclicNumbers.CycleRight(number);

        // Assert
        Assert.That(cyclicNumbers, Is.EqualTo(expectedCyclicNumbers));
    }

    [TestCase(12, 21)]
    [TestCase(123, 312)]
    [TestCase(123, 231)]
    [TestCase(12345, 45123)]
    [TestCase(12345, 23451)]
    [TestCase(12345, 34512)]
    [TestCase(12345, 51234)]
    public void AreCyclic_WhenPositiveCyclicNumbers_ReturnsTrue(long first, long second)
    {
        // Act
        var isCyclic = CyclicNumbers.AreCyclic(first, second);

        // Assert
        Assert.That(isCyclic, Is.True);
    }

    [TestCase(-12, -21)]
    [TestCase(-123, -312)]
    [TestCase(-123, -231)]
    [TestCase(-12345, -45123)]
    [TestCase(-12345, -23451)]
    [TestCase(-12345, -34512)]
    [TestCase(-12345, -51234)]
    public void AreCyclic_WhenNegativeCyclicNumbers_ReturnsTrue(long first, long second)
    {
        // Act
        var isCyclic = CyclicNumbers.AreCyclic(first, second);

        // Assert
        Assert.That(isCyclic, Is.True);
    }

    [TestCase(0, 0)]
    [TestCase(0, 1)]
    [TestCase(1, 0)]
    [TestCase(123, 123)]
    [TestCase(12345, 1)]
    [TestCase(12345, 54321)]
    [TestCase(12345, 12345)]
    [TestCase(12345, 451230)]
    public void AreCyclic_WhenPositiveNonCyclicNumbers_ReturnsFalse(long first, long second)
    {
        // Act
        var isCyclic = CyclicNumbers.AreCyclic(first, second);

        // Assert
        Assert.That(isCyclic, Is.False);
    }

    [TestCase(0, -1)]
    [TestCase(-1, 0)]
    [TestCase(-123, -123)]
    [TestCase(-12345, -1)]
    [TestCase(-12345, -54321)]
    [TestCase(-12345, -12345)]
    [TestCase(-12345, -451230)]
    public void AreCyclic_WhenNegativeNonCyclicNumbers_ReturnsFalse(long first, long second)
    {
        // Act
        var isCyclic = CyclicNumbers.AreCyclic(first, second);

        // Assert
        Assert.That(isCyclic, Is.False);
    }

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(12, 21)]
    [TestCase(123, 231)]
    [TestCase(1234, 2341)]
    [TestCase(12345, 23451)]
    [TestCase(23451, 34512)]
    [TestCase(34512, 45123)]
    [TestCase(45123, 51234)]
    [TestCase(51234, 12345)]
    public void RotateLeft_PositiveNumbers_RotatesNumbersLeft(long number, long expectedRotatedNumber)
    {
        // Act
        var rotatedNumber = CyclicNumbers.RotateLeft(number);

        // Assert
        Assert.That(rotatedNumber, Is.EqualTo(expectedRotatedNumber));
    }

    [TestCase(-1, -1)]
    [TestCase(-12, -21)]
    [TestCase(-123, -231)]
    [TestCase(-1234, -2341)]
    [TestCase(-12345, -23451)]
    [TestCase(-23451, -34512)]
    [TestCase(-34512, -45123)]
    [TestCase(-45123, -51234)]
    [TestCase(-51234, -12345)]
    public void RotateLeft_NegativeNumbers_RotatesNumbersLeft(long number, long expectedRotatedNumber)
    {
        // Act
        var rotatedNumber = CyclicNumbers.RotateLeft(number);

        // Assert
        Assert.That(rotatedNumber, Is.EqualTo(expectedRotatedNumber));
    }

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(12, 21)]
    [TestCase(123, 312)]
    [TestCase(1234, 4123)]
    [TestCase(12345, 51234)]
    [TestCase(51234, 45123)]
    [TestCase(45123, 34512)]
    [TestCase(34512, 23451)]
    [TestCase(23451, 12345)]
    public void RotateRight_PositiveNumbers_RotatesNumbersRight(long number, long expectedRotatedNumber)
    {
        // Act
        var rotatedNumber = CyclicNumbers.RotateRight(number);

        // Assert
        Assert.That(rotatedNumber, Is.EqualTo(expectedRotatedNumber));
    }

    [TestCase(-1, -1)]
    [TestCase(-12, -21)]
    [TestCase(-123, -312)]
    [TestCase(-1234, -4123)]
    [TestCase(-12345, -51234)]
    [TestCase(-51234, -45123)]
    [TestCase(-45123, -34512)]
    [TestCase(-34512, -23451)]
    [TestCase(-23451, -12345)]
    public void RotateRight_NegativeNumbers_RotatesNumbersRight(long number, long expectedRotatedNumber)
    {
        // Act
        var rotatedNumber = CyclicNumbers.RotateRight(number);

        // Assert
        Assert.That(rotatedNumber, Is.EqualTo(expectedRotatedNumber));
    }
}