using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class HexagonalNumbersTests
{
    private const string TEST_FILE_PATH = @"Assets\HexagonalNumbersTests_1000_000.txt";

    [Test]
    public async Task Generate_OneMillionNumbers_AllAreHexagonalNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

        // ACT
        using var hexagonalEnumerator = HexagonalNumbers.Generate(1_000_000).GetEnumerator();

        // ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var expectedHexagonal), Is.True);
            Assert.That(hexagonalEnumerator.MoveNext(), Is.True);
            Assert.That(hexagonalEnumerator.Current, Is.EqualTo(expectedHexagonal));
        }
    }

    [Test]
    public async Task Between_OneToFiveHundred_AllAreHexagonalNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        var hexagonalEnumerator = File.ReadLinesAsync(path).GetAsyncEnumerator();
        using var enumerator = HexagonalNumbers.Between(1, 500).GetEnumerator();

        // ACT & ASSERT
        while (enumerator.MoveNext())
        {
            await hexagonalEnumerator.MoveNextAsync();

            Assert.That(hexagonalEnumerator.Current, Is.EqualTo(enumerator.Current.ToString()));
        }

        Assert.That(enumerator.MoveNext, Is.False);
    }

    [Test]
    public async Task GetNumber_FirstOneMillion_ReturnsFirstFiveHundredHexagonalNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

        // ACT & ASSERT
        var n = 1;
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var expectedHexagonal), Is.True);
            Assert.That(HexagonalNumbers.GetNumber(n++), Is.EqualTo(expectedHexagonal));
        }
    }

    [Test]
    public async Task IsHexagonalNumber_HexagonalNumbers_ReturnsTrue()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

        // ACT & ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var hexagonal), Is.True);
            Assert.That(HexagonalNumbers.IsHexagonalNumber(hexagonal), Is.True);
        }
    }
}