using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class CombinedNumbersTests
{
    [TestCase(0, 0, 0)]
    [TestCase(0, 1, 1)]
    [TestCase(1, 2, 12)]
    [TestCase(2, 1, 21)]
    [TestCase(10, 20, 1020)]
    [TestCase(123, 456, 123456)]
    [TestCase(987, 654, 987654)]
    [TestCase(2147483647, 999999999, 2147483647999999999)]
    public void Combine_TwoPositiveIntegers_ReturnsCombinedNumber(int first, int second, long expectedResult)
    {
        // ACT
        var combination = CombinedNumbers.Combine(first, second);

        // ASSERT
        Assert.That(combination, Is.EqualTo(expectedResult));
    }

    [TestCase(-1, -2, -12)]
    [TestCase(-2, -1, -21)]
    [TestCase(-10, -20, -1020)]
    [TestCase(-123, -456, -123456)]
    [TestCase(-987, -654, -987654)]
    [TestCase(-2147483647, -999999999, -2147483647999999999)]
    public void Combine_TwoNegativeIntegers_ReturnsCombinedNumber(int first, int second, long expectedResult)
    {
        // ACT
        var combination = CombinedNumbers.Combine(first, second);

        // ASSERT
        Assert.That(combination, Is.EqualTo(expectedResult));
    }

    [TestCase(0, 0, 0, 0)]
    [TestCase(0, 0, 1, 1)]
    [TestCase(1, 2, 3, 123)]
    [TestCase(3, 2, 1, 321)]
    [TestCase(10, 20, 30, 102030)]
    [TestCase(123, 456, 789, 123456789)]
    [TestCase(987, 654, 321, 987654321)]
    [TestCase(922337, 2036854, 775807, 9223372036854775807)]
    public void Combine_ThreePositiveIntegers_ReturnsCombinedNumber(int first, int second, int third, long expectedResult)
    {
        // ACT
        var combination = CombinedNumbers.Combine(first, second, third);

        // ASSERT
        Assert.That(combination, Is.EqualTo(expectedResult));
    }

    [TestCase(-1, -2, -3, -123)]
    [TestCase(-3, -2, -1, -321)]
    [TestCase(-10, -20, -30, -102030)]
    [TestCase(-123, -456, -789, -123456789)]
    [TestCase(-987, -654, -321, -987654321)]
    [TestCase(-922337, -2036854, -775807, -9223372036854775807)]
    public void Combine_ThreeNegativeIntegers_ReturnsCombinedNumber(int first, int second, int third, long expectedResult)
    {
        // ACT
        var combination = CombinedNumbers.Combine(first, second, third);

        // ASSERT
        Assert.That(combination, Is.EqualTo(expectedResult));
    }

    [TestCase(0, 0, 0, 0, 0)]
    [TestCase(0, 0, 0, 1, 1)]
    [TestCase(1, 2, 3, 4, 1234)]
    [TestCase(4, 3, 2, 1, 4321)]
    [TestCase(10, 20, 30, 40, 10203040)]
    [TestCase(123, 456, 789, 123, 123456789123)]
    [TestCase(987, 654, 321, 123, 987654321123)]
    [TestCase(92233, 72036, 85477, 5807, 9223372036854775807)]
    public void Combine_FourPositiveIntegers_ReturnsCombinedNumber(int first, int second, int third, int fourth, long expectedResult)
    {
        // ACT
        var combination = CombinedNumbers.Combine(first, second, third, fourth);

        // ASSERT
        Assert.That(combination, Is.EqualTo(expectedResult));
    }

    [TestCase(-1, -2, -3, -4, -1234)]
    [TestCase(-4, -3, -2, -1, -4321)]
    [TestCase(-10, -20, -30, -40, -10203040)]
    [TestCase(-123, -456, -789, -123, -123456789123)]
    [TestCase(-987, -654, -321, -123, -987654321123)]
    [TestCase(-92233, -72036, -85477, -5807, -9223372036854775807)]
    public void Combine_FourNegativeIntegers_ReturnsCombinedNumber(int first, int second, int third, int fourth, long expectedResult)
    {
        // ACT
        var combination = CombinedNumbers.Combine(first, second, third, fourth);

        // ASSERT
        Assert.That(combination, Is.EqualTo(expectedResult));
    }

    [TestCase(new[] { 0, 0, 0, 0 }, 0)]
    [TestCase(new[] { 0, 0, 0, 1 }, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, 1234)]
    [TestCase(new[] { 4, 3, 2, 1 }, 4321)]
    [TestCase(new[] { 10, 20, 30, 40, 50, 60, 70 }, 10203040506070)]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 123456789)]
    [TestCase(new[] { 987, 65, 4, 3, 21 }, 987654321)]
    [TestCase(new[] { 92233, 72036, 85477, 5807 }, 9223372036854775807)]
    public void Combine_PositiveIntegersArray_ReturnsCombinedNumber(int[] numbers, long expectedResult)
    {
        // ACT
        var combination = CombinedNumbers.Combine(numbers);

        // ASSERT
        Assert.That(combination, Is.EqualTo(expectedResult));
    }

    [TestCase(new[] { -1, -2, -3, -4 }, -1234)]
    [TestCase(new[] { -4, -3, -2, -1 }, -4321)]
    [TestCase(new[] { -10, -20, -30, -40, -50, -60, -70 }, -10203040506070)]
    [TestCase(new[] { -1, -2, -3, -4, -5, -6, -7, -8, -9 }, -123456789)]
    [TestCase(new[] { -987, -65, -4, -3, -21 }, -987654321)]
    [TestCase(new[] { -92233, -72036, -85477, -5807 }, -9223372036854775807)]
    public void Combine_NegativeIntegersArray_ReturnsCombinedNumber(int[] numbers, long expectedResult)
    {
        // ACT
        var combination = CombinedNumbers.Combine(numbers);

        // ASSERT
        Assert.That(combination, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Combine_PositiveAndNegativeIntegers_ThrowsArgumentException()
    {
        // ACT & ASSERT
        Assert.That(() => CombinedNumbers.Combine(1, -2), Throws.ArgumentException);
        Assert.That(() => CombinedNumbers.Combine(1, -2, 3), Throws.ArgumentException);
        Assert.That(() => CombinedNumbers.Combine(1, -2, 3, -4), Throws.ArgumentException);
        Assert.That(() => CombinedNumbers.Combine(1, 2, 3, -4), Throws.ArgumentException);
        Assert.That(() => CombinedNumbers.Combine(- 1, 2, 3, 4), Throws.ArgumentException);
        Assert.That(() => CombinedNumbers.Combine(- 1, - 2, -3, 4), Throws.ArgumentException);
        Assert.That(() => CombinedNumbers.Combine(new[] { 1, -2, 3, -4 }), Throws.ArgumentException);
    }
}