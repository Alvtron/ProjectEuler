using ProjectEuler.Mathematics.Combinatorics;

namespace ProjectEuler.Mathematics.Tests.Combinatorics;

[TestFixture]
public class PermutationsTests
{
    [Test]
    public void Of_Empty_ReturnsCorrectPermutations()
    {
        // ARRANGE
        var nothing = Enumerable.Empty<int>();

        // ACT
        var permutations = Permutations.Of(nothing);

        // ASSERT
        Assert.That(permutations, Is.Empty);
    }

    [Test]
    public void Of_LettersNoLength_ReturnsCorrectPermutations()
    {
        // ARRANGE
        const string LETTERS = "ABC";
        var expected = new HashSet<string>
        {
            "ABC",
            "ACB",
            "BAC",
            "BCA",
            "CAB",
            "CBA",
        };

        // ACT
        var permutations = Permutations.Of(LETTERS).Select(permutation => new string(permutation.ToArray()));

        // ASSERT
        Assert.That(permutations, Is.EqualTo(expected));
    }

    [Test]
    public void Of_LettersWithLength_ReturnsCorrectPermutations()
    {
        // ARRANGE
        const string LETTERS = "ABC";
        var expected = new HashSet<string>
        {
            "AB",
            "AC",
            "BA",
            "BC",
            "CA",
            "CB",
        };

        // ACT
        var permutations = Permutations.Of(LETTERS, 2).Select(permutation => new string(permutation.ToArray()));

        // ASSERT
        Assert.That(permutations, Is.EquivalentTo(expected));
    }
}