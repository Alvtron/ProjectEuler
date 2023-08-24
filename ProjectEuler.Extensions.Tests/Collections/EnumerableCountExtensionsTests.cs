using ProjectEuler.Extensions.Collections;

namespace ProjectEuler.Extensions.Tests.Collections;

[TestFixture]
public class EnumerableCountExtensionsTests
{
    [Test]
    public void CountEquals_CountIsNumberOfElements_ReturnsTrue()
    {
        // ARRANGE
        var zero = Enumerable.Range(1, 0);
        var one = Enumerable.Range(1, 1);
        var ten = Enumerable.Range(1, 10);
        var hundred = Enumerable.Range(1, 100);
        var thousand = Enumerable.Range(1, 1000);
        var million = Enumerable.Range(1, 1_000_000);
        var billion = Enumerable.Range(1, 1_000_000_000);

        // ACT & ASSERT
        Assert.That(zero.CountEquals(0), Is.True);
        Assert.That(one.CountEquals(1), Is.True);
        Assert.That(ten.CountEquals(10), Is.True);
        Assert.That(hundred.CountEquals(100), Is.True);
        Assert.That(thousand.CountEquals(1000), Is.True);
        Assert.That(million.CountEquals(1_000_000), Is.True);
        Assert.That(billion.CountEquals(1_000_000_000), Is.True);
    }

    [Test]
    public void CountEquals_CountIsLowerThanNumberOfElements_ReturnsFalse()
    {
        // ARRANGE
        var zero = Enumerable.Range(1, 0);
        var one = Enumerable.Range(1, 1);
        var ten = Enumerable.Range(1, 10);
        var hundred = Enumerable.Range(1, 100);
        var thousand = Enumerable.Range(1, 1000);
        var million = Enumerable.Range(1, 1_000_000);
        var billion = Enumerable.Range(1, 1_000_000_000);

        // ACT & ASSERT
        Assert.That(zero.CountEquals(0 - 1), Is.False);
        Assert.That(one.CountEquals(1 - 1), Is.False);
        Assert.That(ten.CountEquals(10 - 1), Is.False);
        Assert.That(hundred.CountEquals(100 - 1), Is.False);
        Assert.That(thousand.CountEquals(1000 - 1), Is.False);
        Assert.That(million.CountEquals(1_000_000 - 1), Is.False);
        Assert.That(billion.CountEquals(1_000_000_000 - 1), Is.False);
    }

    [Test]
    public void CountEquals_CountIsHigherThanNumberOfElements_ReturnsFalse()
    {
        // ARRANGE
        var zero = Enumerable.Range(1, 0);
        var one = Enumerable.Range(1, 1);
        var ten = Enumerable.Range(1, 10);
        var hundred = Enumerable.Range(1, 100);
        var thousand = Enumerable.Range(1, 1000);
        var million = Enumerable.Range(1, 1_000_000);
        var billion = Enumerable.Range(1, 1_000_000_000);

        // ACT & ASSERT
        Assert.That(zero.CountEquals(0 + 1), Is.False);
        Assert.That(one.CountEquals(1 + 1), Is.False);
        Assert.That(ten.CountEquals(10 + 1), Is.False);
        Assert.That(hundred.CountEquals(100 + 1), Is.False);
        Assert.That(thousand.CountEquals(1000 + 1), Is.False);
        Assert.That(million.CountEquals(1_000_000 + 1), Is.False);
        Assert.That(billion.CountEquals(1_000_000_000 + 1), Is.False);
    }

    [Test]
    public void CountLowerThan_CountIsNumberOfElements_ReturnsFalse()
    {
        // ARRANGE
        var zero = Enumerable.Range(1, 0);
        var one = Enumerable.Range(1, 1);
        var ten = Enumerable.Range(1, 10);
        var hundred = Enumerable.Range(1, 100);
        var thousand = Enumerable.Range(1, 1000);
        var million = Enumerable.Range(1, 1_000_000);
        var billion = Enumerable.Range(1, 1_000_000_000);

        // ACT & ASSERT
        Assert.That(zero.CountLowerThan(0), Is.False);
        Assert.That(one.CountLowerThan(1), Is.False);
        Assert.That(ten.CountLowerThan(10), Is.False);
        Assert.That(hundred.CountLowerThan(100), Is.False);
        Assert.That(thousand.CountLowerThan(1000), Is.False);
        Assert.That(million.CountLowerThan(1_000_000), Is.False);
        Assert.That(billion.CountLowerThan(1_000_000_000), Is.False);
    }

    [Test]
    public void CountLowerThan_CountIsLowerThanNumberOfElements_ReturnsFalse()
    {
        // ARRANGE
        var zero = Enumerable.Range(1, 0);
        var one = Enumerable.Range(1, 1);
        var ten = Enumerable.Range(1, 10);
        var hundred = Enumerable.Range(1, 100);
        var thousand = Enumerable.Range(1, 1000);
        var million = Enumerable.Range(1, 1_000_000);
        var billion = Enumerable.Range(1, 1_000_000_000);

        // ACT & ASSERT
        Assert.That(zero.CountLowerThan(0 - 1), Is.False);
        Assert.That(one.CountLowerThan(1 - 1), Is.False);
        Assert.That(ten.CountLowerThan(10 - 1), Is.False);
        Assert.That(hundred.CountLowerThan(100 - 1), Is.False);
        Assert.That(thousand.CountLowerThan(1000 - 1), Is.False);
        Assert.That(million.CountLowerThan(1_000_000 - 1), Is.False);
        Assert.That(billion.CountLowerThan(1_000_000_000 - 1), Is.False);
    }

    [Test]
    public void CountLowerThan_CountIsHigherThanNumberOfElements_ReturnsTrue()
    {
        // ARRANGE
        var zero = Enumerable.Range(1, 0);
        var one = Enumerable.Range(1, 1);
        var ten = Enumerable.Range(1, 10);
        var hundred = Enumerable.Range(1, 100);
        var thousand = Enumerable.Range(1, 1000);
        var million = Enumerable.Range(1, 1_000_000);
        var billion = Enumerable.Range(1, 1_000_000_000);

        // ACT & ASSERT
        Assert.That(zero.CountLowerThan(0 + 1), Is.True);
        Assert.That(one.CountLowerThan(1 + 1), Is.True);
        Assert.That(ten.CountLowerThan(10 + 1), Is.True);
        Assert.That(hundred.CountLowerThan(100 + 1), Is.True);
        Assert.That(thousand.CountLowerThan(1000 + 1), Is.True);
        Assert.That(million.CountLowerThan(1_000_000 + 1), Is.True);
        Assert.That(billion.CountLowerThan(1_000_000_000 + 1), Is.True);
    }

    // asd asd asd

    [Test]
    public void CountHigherThan_CountIsNumberOfElements_ReturnsFalse()
    {
        // ARRANGE
        var zero = Enumerable.Range(1, 0);
        var one = Enumerable.Range(1, 1);
        var ten = Enumerable.Range(1, 10);
        var hundred = Enumerable.Range(1, 100);
        var thousand = Enumerable.Range(1, 1000);
        var million = Enumerable.Range(1, 1_000_000);
        var billion = Enumerable.Range(1, 1_000_000_000);

        // ACT & ASSERT
        Assert.That(zero.CountHigherThan(0), Is.False);
        Assert.That(one.CountHigherThan(1), Is.False);
        Assert.That(ten.CountHigherThan(10), Is.False);
        Assert.That(hundred.CountHigherThan(100), Is.False);
        Assert.That(thousand.CountHigherThan(1000), Is.False);
        Assert.That(million.CountHigherThan(1_000_000), Is.False);
        Assert.That(billion.CountHigherThan(1_000_000_000), Is.False);
    }

    [Test]
    public void CountHigherThan_CountIsLowerThanNumberOfElements_ReturnsTrue()
    {
        // ARRANGE
        var zero = Enumerable.Range(1, 0);
        var one = Enumerable.Range(1, 1);
        var ten = Enumerable.Range(1, 10);
        var hundred = Enumerable.Range(1, 100);
        var thousand = Enumerable.Range(1, 1000);
        var million = Enumerable.Range(1, 1_000_000);
        var billion = Enumerable.Range(1, 1_000_000_000);

        // ACT & ASSERT
        Assert.That(zero.CountHigherThan(0 - 1), Is.True);
        Assert.That(one.CountHigherThan(1 - 1), Is.True);
        Assert.That(ten.CountHigherThan(10 - 1), Is.True);
        Assert.That(hundred.CountHigherThan(100 - 1), Is.True);
        Assert.That(thousand.CountHigherThan(1000 - 1), Is.True);
        Assert.That(million.CountHigherThan(1_000_000 - 1), Is.True);
        Assert.That(billion.CountHigherThan(1_000_000_000 - 1), Is.True);
    }

    [Test]
    public void CountHigherThan_CountIsHigherThanNumberOfElements_ReturnsFalse()
    {
        // ARRANGE
        var zero = Enumerable.Range(1, 0);
        var one = Enumerable.Range(1, 1);
        var ten = Enumerable.Range(1, 10);
        var hundred = Enumerable.Range(1, 100);
        var thousand = Enumerable.Range(1, 1000);
        var million = Enumerable.Range(1, 1_000_000);
        var billion = Enumerable.Range(1, 1_000_000_000);

        // ACT & ASSERT
        Assert.That(zero.CountHigherThan(0 + 1), Is.False);
        Assert.That(one.CountHigherThan(1 + 1), Is.False);
        Assert.That(ten.CountHigherThan(10 + 1), Is.False);
        Assert.That(hundred.CountHigherThan(100 + 1), Is.False);
        Assert.That(thousand.CountHigherThan(1000 + 1), Is.False);
        Assert.That(million.CountHigherThan(1_000_000 + 1), Is.False);
        Assert.That(billion.CountHigherThan(1_000_000_000 + 1), Is.False);
    }
}