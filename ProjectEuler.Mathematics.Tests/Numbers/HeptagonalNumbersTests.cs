using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class HeptagonalNumbersTests
{
    private IEnumerable<long> heptagonalNumbers;

    [OneTimeSetUp]
    public async Task LoadHeptagonalNumbersAsync()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\HeptagonalNumbersTests_1000000.txt");
        var lines = await File.ReadAllLinesAsync(path);
        this.heptagonalNumbers = lines.Select(long.Parse);
    }

    [Test]
    public void IsHeptagonal_ValidHeptagonalNumbers_ReturnsTrue()
    {
        // Arrange
        foreach (var heptagonal in this.heptagonalNumbers)
        {
            // Act
            var isHeptagonal = HeptagonalNumbers.IsHeptagonal(heptagonal);

            // Assert
            Assert.That(isHeptagonal, Is.True, $"{heptagonal} is a heptagonal number.");
        }
    }

    [Test]
    public void IsHeptagonal_InvalidHeptagonalNumbers_ReturnsFalse()
    {
        // Arrange
        var numbers = Enumerable.Range(0, 1_000_000).Select(n => (long)n).Except(this.heptagonalNumbers);

        foreach (var notHeptagonal in numbers)
        {
            // Act
            var isHeptagonal = HeptagonalNumbers.IsHeptagonal(notHeptagonal);

            // Assert
            Assert.That(isHeptagonal, Is.False, $"{notHeptagonal} is not a heptagonal number.");
        }
    }

    [Test]
    public void Get_0To1000000_ReturnsFirstFiveHundredHeptagonalNumbers()
    {
        // Act
        var generatedHeptagonalNumbers = Enumerable.Range(0, 1_000_000).Select(n => HeptagonalNumbers.Get(n));

        // Assert
        foreach (var (generated, actual) in generatedHeptagonalNumbers.Zip(this.heptagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Generate_1000000_AllAreHeptagonalNumbers()
    {
        // Act
        var generatedHeptagonalNumbers = HeptagonalNumbers.Generate().Take(1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedHeptagonalNumbers.Zip(this.heptagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }

    [Test]
    public void Between_0To1000000_AllAreHeptagonalNumbers()
    {
        // Act
        var generatedHeptagonalNumbers = HeptagonalNumbers.Between(0, 1_000_000);

        // Assert
        foreach (var (generated, actual) in generatedHeptagonalNumbers.Zip(this.heptagonalNumbers))
        {
            Assert.That(generated, Is.EqualTo(actual));
        }
    }
}