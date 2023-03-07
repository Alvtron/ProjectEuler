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
        var permutations = Combinations.Of(nothing);

        // ASSERT
        Assert.That(permutations, Is.Empty);
    }

    [Test]
    public void Of_Digits_ReturnsCorrectPermutations()
    {
        // ARRANGE
        var digits = new[] { 1, 2, 3 };

        // ACT
        var permutations = Permutations.Of(digits);

        // ASSERT
        var expected = new HashSet<int[]>
        {
            new[] { 1, },
            new[] { 1, 2 },
            new[] { 1, 3 },
            new[] { 1, 2, 3 },
            new[] { 1, 3, 2 },
            new[] { 2, },
            new[] { 2, 1 },
            new[] { 2, 3 },
            new[] { 2, 1, 3 },
            new[] { 2, 3, 1 },
            new[] { 3, },
            new[] { 3, 1 },
            new[] { 3, 2 },
            new[] { 3, 1, 2 },
            new[] { 3, 2, 1 },
        };

        foreach (var combination in permutations)
        {
            Assert.That(expected.Count(e => e.SequenceEqual(combination)), Is.EqualTo(1));
        }
    }
}