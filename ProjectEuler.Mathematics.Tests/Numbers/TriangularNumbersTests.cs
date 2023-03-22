using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class TriangularNumbersTests
{
    private const string TEST_FILE_PATH = @"Assets\TriangularNumbersTests_1000000.txt";

    [Test]
    public async Task Generate_OneMillionNumbers_AllAreTriangularNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

        // ACT
        using var triangularEnumerator = TriangularNumbers.Generate(1_000_000).GetEnumerator();

        // ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var expectedTriangular), Is.True);
            Assert.That(triangularEnumerator.MoveNext(), Is.True);
            Assert.That(triangularEnumerator.Current, Is.EqualTo(expectedTriangular));
        }
    }

    [Test]
    public async Task Between_OneToFiveHundred_AllAreTriangularNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        var triangularEnumerator = File.ReadLinesAsync(path).GetAsyncEnumerator();
        using var enumerator = TriangularNumbers.Between(1, 500).GetEnumerator();

        // ACT & ASSERT
        while (enumerator.MoveNext())
        {
            await triangularEnumerator.MoveNextAsync();

            Assert.That(triangularEnumerator.Current, Is.EqualTo(enumerator.Current.ToString()));
        }

        Assert.That(enumerator.MoveNext, Is.False);
    }

    [Test]
    public async Task GetNumber_FirstOneMillion_ReturnsFirstFiveHundredTriangularNumbers()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

        // ACT & ASSERT
        var n = 1;
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var expectedTriangular), Is.True);
            Assert.That(TriangularNumbers.GetNumber(n++), Is.EqualTo(expectedTriangular));
        }
    }

    [Test]
    public async Task IsTriangularNumber_TriangularNumbers_ReturnsTrue()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

        // ACT & ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var triangular), Is.True);
            Assert.That(TriangularNumbers.IsTriangularNumber(triangular), Is.True);
        }
    }
}