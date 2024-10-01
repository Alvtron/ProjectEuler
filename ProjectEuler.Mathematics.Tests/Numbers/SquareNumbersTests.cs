using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class SquareNumbersTests
{
    private IEnumerable<long> squareNumbers;

    [OneTimeSetUp]
    public async Task LoadPentagonalNumbersNumbersAsync()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\SquareNumbersTests_1000000.txt");
        var lines = await File.ReadAllLinesAsync(path);
        this.squareNumbers = lines.Select(long.Parse);
    }

    [Test]
    public void IsSquare_ValidSquareNumbers_ReturnsTrue()
    {
        // Arrange
        foreach (var square in this.squareNumbers)
        {
            // Act
            var isSquare = SquareNumbers.IsSquare(square);

            // Assert
            Assert.That(isSquare, Is.True, $"{square} is a square number.");
        }
    }

    [Test]
    public void IsSquare_InvalidSquareNumbers_ReturnsFalse()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 1_000_000).Select(n => (long)n).Except(this.squareNumbers);

        foreach (var notSquare in numbers)
        {
            // Act
            var isSquare = SquareNumbers.IsSquare(notSquare);

            // Assert
            Assert.That(isSquare, Is.False, $"{notSquare} is not a square number.");
        }
    }

    [Test]
    public void Get_0To1000000_ReturnsFirstFiveHundredPentagonalNumbers()
    {
        // Act
        var generatedSquareNumbers = Enumerable.Range(0, 1_000_000).Select(n => SquareNumbers.Get(n));

        // Assert
        foreach (var (generated, actual) in generatedSquareNumbers.Zip(this.squareNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Generate_10000000_AllAreSquareNumbers()
    {
        // Act
        var generatedSquareNumbers = SquareNumbers.Generate().Take(1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedSquareNumbers.Zip(this.squareNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Between_0To1000000_AllAreSquareNumbers()
    {
        // Act
        var generatedSquareNumbers = SquareNumbers.Between(0, 1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedSquareNumbers.Zip(this.squareNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }
}