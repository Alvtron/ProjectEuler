using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class PentagonalNumbersTests
{
    [Test]
    public async Task Generate_FiveHundredNumbers_AllArePentagonalNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\PentagonalNumbersTests_500.txt");

        // ACT
        using var pentagonalEnumerator = PentagonalNumbers.Generate(500).GetEnumerator();

        // ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var expectedPentagonal), Is.True);
            Assert.That(pentagonalEnumerator.MoveNext(), Is.True);
            Assert.That(pentagonalEnumerator.Current, Is.EqualTo(expectedPentagonal));
        }
    }

    [Test]
    public async Task GetNumber_FirstFiveHundred_ReturnsFirstFiveHundredPentagonalNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\PentagonalNumbersTests_500.txt");

        // ACT & ASSERT
        var n = 1;
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var expectedPentagonal), Is.True);
            Assert.That(PentagonalNumbers.GetNumber(n++), Is.EqualTo(expectedPentagonal));
        }
    }

    [Test]
    public async Task IsPentagonalNumber_PandigitalNumbers_ReturnsTrue()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\PentagonalNumbersTests_500.txt");

        // ACT & ASSERT
        var n = 1;
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var pentagonal), Is.True);
            Assert.That(PentagonalNumbers.IsPentagonalNumber(pentagonal), Is.True);
        }
    }
}