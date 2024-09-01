using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class LychrelNumbersTests
{
    private const string TEST_FILE_PATH = @"Assets\LychrelNumbersTests_10000.txt";
    private int[] knownNumbers = [];

    [OneTimeSetUp]
    public async Task SetUp()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        Assert.That(File.Exists(path), Is.True);

        var lines = await File.ReadAllLinesAsync(path);
        this.knownNumbers = lines.Select(int.Parse).ToArray();
    }

    [Test]
    public void Between_0And10000_ReturnsLychrelNumbers()
    {
        // ARRANGE
        var lychrelNumbers = this.knownNumbers.Where(n => n is >= 0 and <= 10_000);

        // ACT
        var possibleLychrelNumbers = LychrelNumbers.Between(0, 10_000);

        // ASSERT
        Assert.That(possibleLychrelNumbers, Is.EquivalentTo(lychrelNumbers));
    }

    [Test]
    public void Generate_10000_ReturnsLychrelNumbers()
    {
        // ARRANGE
        var lychrelNumbers = this.knownNumbers.Where(n => n is >= 0 and <= 10_000);

        // ACT
        var possibleLychrelNumbers = LychrelNumbers.Generate().TakeWhile(n => n <= 10_000);

        // ASSERT
        Assert.That(possibleLychrelNumbers, Is.EquivalentTo(lychrelNumbers));
    }

    [Test]
    public void IsLychrelNumber_AllKnown_ReturnsTrue()
    {
        // ARRANGE
        var lychrelNumbers = this.knownNumbers.Where(n => n is >= 0 and <= 10_000);

        // ACT
        var allAreLychrelNumbers = lychrelNumbers.All(n => LychrelNumbers.IsLychrelNumber(n));

        // ASSERT
        Assert.That(allAreLychrelNumbers, Is.True);
    }

    public void IsLychrelNumber_NonLychrelNumbers_ReturnsFalse(long number)
    {
        // ARRANGE
        var lychrelNumbers = Enumerable.Range(-10000, 10000).Except(this.knownNumbers);

        // ACT
        var anyLychrelNumber = lychrelNumbers.Any(n => LychrelNumbers.IsLychrelNumber(n));

        // ASSERT
        Assert.That(anyLychrelNumber, Is.False);
    }
}