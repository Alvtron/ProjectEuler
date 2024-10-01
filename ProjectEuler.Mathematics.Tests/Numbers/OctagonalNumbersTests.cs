using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class OctagonalNumbersTests
{
    private IEnumerable<long> octagonalNumbers;

    [OneTimeSetUp]
    public async Task LoadOctagonalNumbersAsync()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\OctagonalNumbersTests_1000000.txt");
        var lines = await File.ReadAllLinesAsync(path);
        this.octagonalNumbers = lines.Select(long.Parse);
    }

    [Test]
    public void IsOctagonal_ValidOctagonalNumbers_ReturnsTrue()
    {
        // Arrange
        foreach (var octagonal in this.octagonalNumbers)
        {
            // Act
            var isOctagonal = OctagonalNumbers.IsOctagonal(octagonal);

            // Assert
            Assert.That(isOctagonal, Is.True, $"{octagonal} is a octagonal number.");
        }
    }

    [Test]
    public void IsOctagonal_InvalidOctagonalNumbers_ReturnsFalse()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 1_000_000).Select(n => (long)n).Except(this.octagonalNumbers);

        foreach (var notOctagonal in numbers)
        {
            // Act
            var isOctagonal = OctagonalNumbers.IsOctagonal(notOctagonal);

            // Assert
            Assert.That(isOctagonal, Is.False, $"{notOctagonal} is not a octagonal number.");
        }
    }

    [Test]
    public void Get_0To1000000_ReturnsFirstFiveHundredOctagonalNumbers()
    {
        // Act
        var generatedOctagonalNumbers = Enumerable.Range(0, 1_000_000).Select(n => OctagonalNumbers.Get(n));

        // Assert
        foreach (var (generated, actual) in generatedOctagonalNumbers.Zip(this.octagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Generate_1000000_AllAreOctagonalNumbers()
    {
        // Act
        var generatedOctagonalNumbers = OctagonalNumbers.Generate().Take(1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedOctagonalNumbers.Zip(this.octagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Between_0To1000000_AllAreOctagonalNumbers()
    {
        // Act
        var generatedOctagonalNumbers = OctagonalNumbers.Between(0, 1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedOctagonalNumbers.Zip(this.octagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }
}