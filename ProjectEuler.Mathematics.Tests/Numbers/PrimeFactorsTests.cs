using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class PrimeFactorsTests
{
    [Test]
    public void DistinctOf_Negative_ReturnsNothing()
    {
        // ACT
        var factors = PrimeFactors.DistinctOf(-1234);

        // ASSERT
        Assert.That(factors, Is.Empty);
    }

    [Test]
    public void DistinctOf_Zero_ReturnsNothing()
    {
        // ACT
        var factors = PrimeFactors.DistinctOf(0);

        // ASSERT
        Assert.That(factors, Is.Empty);
    }

    [Test]
    public void DistinctOf_One_ReturnsNothing()
    {
        // ACT
        var factors = PrimeFactors.DistinctOf(1);

        // ASSERT
        Assert.That(factors, Is.Empty);
    }

    [Test]
    public void DistinctOf_12_ReturnsPrimeFactorsOnly()
    {
        // ARRANGE
        var expected = new[] { 2, 3 };

        // ACT
        var factors = PrimeFactors.DistinctOf(12);

        // ASSERT
        Assert.That(factors, Is.EqualTo(expected));
    }

    [Test]
    public void DistinctOf_4294967295_ReturnsPrimeFactorsOnly()
    {
        // ARRANGE
        var expected = new[] { 3, 5, 17, 257, 65537 };

        // ACT
        var factors = PrimeFactors.DistinctOf(4294967295);

        // ASSERT
        Assert.That(factors, Is.EqualTo(expected));
    }

    [Test]
    public void DistinctOf_9223372036854775807_ReturnsPrimeFactorsOnly()
    {
        // ARRANGE
        var expected = new[] { 7, 73, 127, 337, 92737, 649657 };

        // ACT
        var factors = PrimeFactors.DistinctOf(long.MaxValue);

        // ASSERT
        Assert.That(factors, Is.EqualTo(expected));
    }

    [Test]
    public void Of_12_ReturnsPrimeFactorsOnly()
    {
        // ARRANGE
        var expected = new[] { 2, 2, 3 };

        // ACT
        var factors = PrimeFactors.Of(12);

        // ASSERT
        Assert.That(factors, Is.EqualTo(expected));
    }

    [Test]
    public void Of_4294967295_ReturnsPrimeFactorsOnly()
    {
        // ARRANGE
        var expected = new[] { 3, 5, 17, 257, 65537 };

        // ACT
        var factors = PrimeFactors.Of(4294967295);

        // ASSERT
        Assert.That(factors, Is.EqualTo(expected));
    }

    [Test]
    public void Of_9223372036854775807_ReturnsPrimeFactorsOnly()
    {
        // ARRANGE
        var expected = new[] { 7, 7, 73, 127, 337, 92737, 649657 };

        // ACT
        var factors = PrimeFactors.Of(long.MaxValue);

        // ASSERT
        Assert.That(factors, Is.EqualTo(expected));
    }
}