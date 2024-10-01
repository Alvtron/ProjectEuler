using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class HexagonalNumbersTests
{
    private IEnumerable<long> hexagonalNumbers;

    [OneTimeSetUp]
    public async Task LoadHexagonalNumbersAsync()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\HexagonalNumbersTests_1000000.txt");
        var lines = await File.ReadAllLinesAsync(path);
        this.hexagonalNumbers = lines.Select(long.Parse);
    }

    [Test]
    public void IsHexagonal_ValidHexagonalNumbers_ReturnsTrue()
    {
        // Arrange
        foreach (var hexagonal in this.hexagonalNumbers)
        {
            // Act
            var isHexagonal = HexagonalNumbers.IsHexagonal(hexagonal);

            // Assert
            Assert.That(isHexagonal, Is.True, $"{hexagonal} is a hexagonal number.");
        }
    }

    [Test]
    public void IsHexagonal_InvalidHexagonalNumbers_ReturnsFalse()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 1_000_000).Select(n => (long)n).Except(this.hexagonalNumbers);

        foreach (var notHexagonal in numbers)
        {
            // Act
            var isHexagonal = HexagonalNumbers.IsHexagonal(notHexagonal);

            // Assert
            Assert.That(isHexagonal, Is.False, $"{notHexagonal} is not a hexagonal number.");
        }
    }

    [Test]
    public void Get_0To100000_ReturnsFirstFiveHundredHexagonalNumbers()
    {
        // Act
        var generatedHexagonalNumbers = Enumerable.Range(0, 1_000_000).Select(n => HexagonalNumbers.Get(n));

        // Assert
        foreach (var (generated, actual) in generatedHexagonalNumbers.Zip(this.hexagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Generate_1000000_AllAreHexagonalNumbers()
    {
        // Act
        var generatedHexagonalNumbers = HexagonalNumbers.Generate().Take(1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedHexagonalNumbers.Zip(this.hexagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Between_0To1000000_AllAreHexagonalNumbers()
    {
        // Act
        var generatedHexagonalNumbers = HexagonalNumbers.Between(0, 1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedHexagonalNumbers.Zip(this.hexagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }
}