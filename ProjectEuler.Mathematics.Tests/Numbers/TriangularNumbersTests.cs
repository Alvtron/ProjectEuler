using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class TriangularNumbersTests
{
    private IEnumerable<long> triangularNumbers;

    [OneTimeSetUp]
    public async Task LoadPentagonalNumbersNumbersAsync()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\TriangularNumbersTests_1000000.txt");
        var lines = await File.ReadAllLinesAsync(path);
        this.triangularNumbers = lines.Select(long.Parse);
    }

    [Test]
    public void IsTriangular_ValidTriangularNumbers_ReturnsTrue()
    {
        // Arrange
        foreach (var triangular in this.triangularNumbers)
        {
            // Act
            var isTriangular = TriangularNumbers.IsTriangular(triangular);

            // Assert
            Assert.That(isTriangular, Is.True, $"{triangular} is a triangular number.");
        }
    }

    [Test]
    public void IsTriangular_InvalidTriangularNumbers_ReturnsFalse()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 1_000_000).Select(n => (long)n).Except(this.triangularNumbers);

        foreach (var notTriangular in numbers)
        {
            // Act
            var isTriangular = TriangularNumbers.IsTriangular(notTriangular);

            // Assert
            Assert.That(isTriangular, Is.False, $"{notTriangular} is not a triangular number.");
        }
    }

    [Test]
    public void Get_0To1000000_ReturnsFirstFiveHundredPentagonalNumbers()
    {
        // Act
        var generatedTriangularNumbers = Enumerable.Range(0, 1_000_000).Select(n => TriangularNumbers.Get(n));

        // Assert
        foreach (var (generated, actual) in generatedTriangularNumbers.Zip(this.triangularNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Generate_10000000_AllAreTriangularNumbers()
    {
        // Act
        var generatedTriangularNumbers = TriangularNumbers.Generate().Take(1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedTriangularNumbers.Zip(this.triangularNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Between_0To1000000_AllAreTriangularNumbers()
    {
        // Act
        var generatedTriangularNumbers = TriangularNumbers.Between(0, 1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedTriangularNumbers.Zip(this.triangularNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }
}