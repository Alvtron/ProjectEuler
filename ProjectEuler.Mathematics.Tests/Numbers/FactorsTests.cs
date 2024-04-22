using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class FactorsTests
{
    [Test]
    public void Of_Negative_ReturnsNegativeFactors()
    {
        // ARRANGE
        var expected = new[]
        {
            1, -1, 2, -2, 3, -3, 4, -4, 6, -6, 12, -12,
        };

        // ACT
        var factors = Factors.Of(-12);

        // ASSERT
        Assert.That(factors, Is.EqualTo(expected));
    }

    [Test]
    public void Of_Zero_ReturnsNothing()
    {
        // ACT
        var factors = PrimeFactors.DistinctOf(0);

        // ASSERT
        Assert.That(factors, Is.Empty);
    }

    [Test]
    public void Of_One_ReturnsOne()
    {
        // ARRANGE
        var expected = new[] { 1, };

        // ACT
        var factors = Factors.Of(1);

        // ASSERT
        Assert.That(factors, Is.EqualTo(expected));
    }

    [Test]
    public void Of_12_ReturnsFactorsOnly()
    {
        // ARRANGE
        var expected = new[]
        {
            1, -1, 2, -2, 3, -3, 4, -4, 6, -6, 12, -12,
        };

        // ACT
        var factors = Factors.Of(12);

        // ASSERT
        Assert.That(factors, Is.EqualTo(expected));
    }

    [Test]
    public void Of_4294967295_ReturnsFactorsOnly()
    {
        // ARRANGE
        var expected = new[]
        {
            1, -1, 3, -3, 5, -5, 15, -15, 17, -17, 51, -51, 85, -85, 255, -255, 257, -257, 771, -771, 1285, -1285,
            3855, -3855, 4369, -4369, 13107, -13107, 21845, -21845, 65535, -65535, 65537, -65537, 196611, -196611,
            327685, -327685, 983055, -983055, 1114129, -1114129, 3342387, -3342387, 5570645, -5570645, 16711935, -16711935,
            16843009, -16843009, 50529027, -50529027, 84215045, -84215045, 252645135, -252645135, 286331153, -286331153,
            858993459, -858993459, 1431655765, -1431655765, 4294967295, -4294967295,
        };

        // ACT
        var factors = Factors.Of(4294967295);

        // ASSERT
        Assert.That(factors, Is.EqualTo(expected));
    }
}