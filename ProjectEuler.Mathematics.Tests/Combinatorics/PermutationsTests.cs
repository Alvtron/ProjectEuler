using ProjectEuler.Mathematics.Combinatorics;

namespace ProjectEuler.Mathematics.Tests.Combinatorics;

[TestFixture]
public class PermutationsTests
{
    [TestCase(123, 321, true)]              // Permutation
    [TestCase(123, 231, true)]              // Permutation
    [TestCase(123, 456, false)]             // Not a permutation
    [TestCase(112233, 332211, true)]        // Large numbers, permutation
    [TestCase(123, 1223, false)]            // Different number of digits
    [TestCase(0, 0, true)]                  // Both numbers are zero
    [TestCase(100, 1, false)]               // Zeros in digits, not a permutation
    [TestCase(100, 100, true)]              // Same number
    [TestCase(987654321, 123456789, true)]  // Large numbers, permutation
    [TestCase(102345, 543201, true)]        // Zeros as digits, permutation
    [TestCase(9, 9, true)]                  // Single-digit number, same number
    [TestCase(8, 9, false)]                 // Single-digit numbers, different digits
    [TestCase(-123, -321, true)]            // Negative numbers that are permutations
    [TestCase(-123, 321, false)]            // One negative, one positive
    public void ArePermutations_ShouldReturnExpectedResult(int a, int b, bool expected)
    {
        var result = Permutations.ArePermutations(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }

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