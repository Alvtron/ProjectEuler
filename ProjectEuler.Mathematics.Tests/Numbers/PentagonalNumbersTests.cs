using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class PentagonalNumbersTests
{
    private const string TEST_FILE_PATH = @"Assets\PentagonalNumbersTests_500.txt";

    [Test]
    public async Task Generate_FiveHundredNumbers_AllArePentagonalNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

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
    public async Task Between_OneToFiveHundred_AllArePentagonalNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        var pentagonalEnumerator = File.ReadLinesAsync(path).GetAsyncEnumerator();
        using var enumerator = PentagonalNumbers.Between(1, 500).GetEnumerator();

        // ACT & ASSERT
        while (enumerator.MoveNext())
        {
            await pentagonalEnumerator.MoveNextAsync();

            Assert.That(pentagonalEnumerator.Current, Is.EqualTo(enumerator.Current.ToString()));
        }

        Assert.That(enumerator.MoveNext, Is.False);
    }

    [Test]
    public async Task GetNumber_FirstFiveHundred_ReturnsFirstFiveHundredPentagonalNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

        // ACT & ASSERT
        var n = 1;
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var expectedPentagonal), Is.True);
            Assert.That(PentagonalNumbers.GetNumber(n++), Is.EqualTo(expectedPentagonal));
        }
    }

    [Test]
    public async Task IsPentagonalNumber_PentagonalNumbers_ReturnsTrue()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

        // ACT & ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var pentagonal), Is.True);
            Assert.That(PentagonalNumbers.IsPentagonalNumber(pentagonal), Is.True);
        }
    }
}