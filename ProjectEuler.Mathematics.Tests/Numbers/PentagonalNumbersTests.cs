using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class PentagonalNumbersTests
{
    private IEnumerable<long> pentagonalNumbers;

    [OneTimeSetUp]
    public async Task LoadPentagonalNumbersNumbersAsync()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\PentagonalNumbersTests_1000000.txt");
        var lines = await File.ReadAllLinesAsync(path);
        this.pentagonalNumbers = lines.Select(long.Parse);
    }

    [Test]
    public void IsPentagonal_ValidPentagonalNumbers_ReturnsTrue()
    {
        // Arrange
        foreach (var pentagonal in this.pentagonalNumbers)
        {
            // Act
            var isPentagonal = PentagonalNumbers.IsPentagonal(pentagonal);

            // Assert
            Assert.That(isPentagonal, Is.True, $"{pentagonal} is a pentagonal number.");
        }
    }

    [Test]
    public void IsPentagonal_InvalidPentagonalNumbers_ReturnsFalse()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 1_000_000).Select(n => (long)n).Except(this.pentagonalNumbers);

        foreach (var notPentagonal in numbers)
        {
            // Act
            var isPentagonal = PentagonalNumbers.IsPentagonal(notPentagonal);

            // Assert
            Assert.That(isPentagonal, Is.False, $"{notPentagonal} is not a pentagonal number.");
        }
    }

    [Test]
    public void Get_0To1000000_ReturnsFirstFiveHundredPentagonalNumbers()
    {
        // Act
        var generatedPentagonalNumbers = Enumerable.Range(0, 1_000_000).Select(n => PentagonalNumbers.Get(n));

        // Assert
        foreach (var (generated, actual) in generatedPentagonalNumbers.Zip(this.pentagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Generate_1000000_AllArePentagonalNumbers()
    {
        // Act
        var generatedPentagonalNumbers = PentagonalNumbers.Generate().Take(1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedPentagonalNumbers.Zip(this.pentagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Between_0To1000000_AllArePentagonalNumbers()
    {
        // Act
        var generatedPentagonalNumbers = PentagonalNumbers.Between(0, 1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedPentagonalNumbers.Zip(this.pentagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }
}