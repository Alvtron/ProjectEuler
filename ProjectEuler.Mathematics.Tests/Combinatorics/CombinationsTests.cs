using ProjectEuler.Mathematics.Combinatorics;

namespace ProjectEuler.Mathematics.Tests.Combinatorics;

[TestFixture]
public class CombinationsTests
{
    [Test]
    public void Of_Empty_ReturnsCorrectCombinations()
    {
        // ARRANGE
        var nothing = Enumerable.Empty<int>();

        // ACT
        var combinations = Combinations.Of(nothing, 0);

        // ASSERT
        Assert.That(combinations, Is.Empty);
    }

    [TestCase("ABCDEFGHIJKLMN", 1, @"Assets\CombinationsTests_14n_1k.txt")]
    [TestCase("ABCDEFGHIJKLMN", 2, @"Assets\CombinationsTests_14n_2k.txt")]
    [TestCase("ABCDEFGHIJKLMN", 3, @"Assets\CombinationsTests_14n_3k.txt")]
    [TestCase("ABCDEFGHIJKLMN", 4, @"Assets\CombinationsTests_14n_4k.txt")]
    [TestCase("ABCDEFGHIJKLMN", 5, @"Assets\CombinationsTests_14n_5k.txt")]
    [TestCase("ABCDEFGHIJKLMN", 6, @"Assets\CombinationsTests_14n_6k.txt")]
    [TestCase("ABCDEFGHIJKLMN", 7, @"Assets\CombinationsTests_14n_7k.txt")]
    [TestCase("ABCDEFGHIJKLMN", 8, @"Assets\CombinationsTests_14n_8k.txt")]
    [TestCase("ABCDEFGHIJKLMN", 9, @"Assets\CombinationsTests_14n_9k.txt")]
    public async Task Of_SymbolsFromFile_ReturnsCorrectCombinations(string symbols, int length, string filePath)
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, filePath);
        var expectedResult = await File.ReadAllLinesAsync(path);

        // ACT
        var combinations = Combinations.Of(symbols, length).Select(combination => new string(combination.ToArray()));

        // ASSERT
        CollectionAssert.AreEqual(combinations, expectedResult);
    }
}