using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class SquareNumbersTests
{
    private string[]? actualSquares;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\SquareNumbersTests_1000000.txt");
        this.actualSquares = await File.ReadAllLinesAsync(path);
    }

    [Test]
    public void IsSquare_1000000Squares_ReturnsTrue()
    {
        foreach (var line in this.actualSquares!)
        {
            // ARRANGE
            Assert.That(long.TryParse(line, out var squareNumber), Is.True);

            // ACT
            var isSquare = SquareNumbers.IsSquare(squareNumber);

            // ASSERT
            Assert.That(isSquare, Is.True,
                $"{squareNumber} is not a perfect square.");
        }
    }

    [Test]
    public void Generate_1000000_AllAreSquares()
    {
        // ACT
        var generatedSquares = SquareNumbers.Generate().Take(1_000_000);

        // ASSERT
        foreach (var (generated, actual) in generatedSquares.Zip(this.actualSquares!))
        {
            Assert.That(generated.ToString(), Is.EqualTo(actual));
        }
    }

    [Test]
    public void Between_0And1000000_AllAreSquares()
    {
        // ACT
        var generatedSquares = SquareNumbers.Between(0, 1_000_000);

        // ASSERT
        foreach (var (generated, actual) in generatedSquares.Zip(this.actualSquares!))
        {
            Assert.That(generated.ToString(), Is.EqualTo(actual));
        }
    }

    [Test]
    public void Between_1000000And0_AllAreSquares()
    {
        // ACT
        var generatedSquares = SquareNumbers.Between(1_000_000, 0);

        // ASSERT
        foreach (var (generated, actual) in generatedSquares.Zip(this.actualSquares!.Reverse()))
        {
            Assert.That(generated.ToString(), Is.EqualTo(actual));
        }
    }
}