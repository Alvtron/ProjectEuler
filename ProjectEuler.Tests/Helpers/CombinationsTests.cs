using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

[TestFixture]
public class CombinationsTests
{
    [Test]
    public void Of_Empty_ReturnsCorrectCombinations()
    {
        // ARRANGE
        var nothing = Enumerable.Empty<int>();

        // ACT
        var combinations = Combinations.Of(nothing);

        // ASSERT
        Assert.That(combinations, Is.Empty);
    }

    [Test]
    public void Of_Digits_ReturnsCorrectCombinations()
    {
        // ARRANGE
        var digits = new[] { 1, 2, 3 };

        // ACT
        var combinations = Combinations.Of(digits);

        // ASSERT
        var expected = new HashSet<int[]>
        {
            new[] { 1, },
            new[] { 2, },
            new[] { 3, },
            new[] { 1, 2 },
            new[] { 1, 3 },
            new[] { 2, 3 },
            new[] { 1, 2, 3 },
        };

        foreach (var combination in combinations)
        {
            Assert.That(expected.Count(e => e.SequenceEqual(combination)), Is.EqualTo(1));
        }
    }
}