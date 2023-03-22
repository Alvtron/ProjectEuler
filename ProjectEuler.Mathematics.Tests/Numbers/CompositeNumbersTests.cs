using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class CompositeNumbersTests
{
    private const string TEST_FILE_PATH = @"Assets\CompositeNumbersTests_1000000.txt";

    [Test]
    public async Task IsComposite_1000000Composites_ReturnsTrue()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

        // ACT & ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var compositeNumber), Is.True);
            Assert.That(CompositeNumbers.IsComposite(compositeNumber), Is.True, $"{compositeNumber} is not a composite.");
        }
    }

    [Test]
    public async Task Generate_1000000_AllAreComposites()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        var actualComposites = await File.ReadAllLinesAsync(path);
        var generatedComposites = CompositeNumbers.Generate().Take(1_000_000);

        // ACT & ASSERT
        foreach (var (generated, actual) in generatedComposites.Zip(actualComposites))
        {
            Assert.That(generated.ToString(), Is.EqualTo(actual));
        }
    }

    [Test]
    public async Task Between_0And1000000_AllAreComposites()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        var actualComposites = await File.ReadAllLinesAsync(path);
        var generatedComposites = CompositeNumbers.Between(0, 1_000_000);

        // ACT & ASSERT
        foreach (var (generated, actual) in generatedComposites.Zip(actualComposites))
        {
            Assert.That(generated.ToString(), Is.EqualTo(actual));
        }
    }

    [Test]
    public async Task Between_1000000And0_AllAreComposites()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        var actualComposites = await File.ReadAllLinesAsync(path);
        Array.Reverse(actualComposites);

        var generatedComposites = CompositeNumbers.Between(1_000_000, 0);

        // ACT & ASSERT
        foreach (var (generated, actual) in generatedComposites.Zip(actualComposites))
        {
            Assert.That(generated.ToString(), Is.EqualTo(actual));
        }
    }
}