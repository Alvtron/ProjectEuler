using ProjectEuler.Mathematics.Numbers;
using System.Collections;
using System.Text;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class BinaryNumbersTests
{
    [Test]
    public void Range_OfFourLength_ReturnsCorrect()
    {
        // ARRANGE
        var expectedResult = new[]
        {
            "0000",
            "0001",
            "0010",
            "0011",
            "0100",
            "0101",
            "0110",
            "0111",
            "1000",
            "1001",
            "1010",
            "1011",
            "1100",
            "1101",
            "1110",
            "1111",
        };

        // ACT
        var combination = BinaryNumbers.Range(4);

        // ASSERT
        Assert.That(combination.Select(BitArrayToString), Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void Range_FirstTenOfEightLength_ReturnsCorrect()
    {
        // ARRANGE
        var expectedResult = new[]
        {
            "00000000",
            "00000001",
            "00000010",
            "00000011",
            "00000100",
            "00000101",
            "00000110",
            "00000111",
            "00001000",
            "00001001",
            "00001010",
        };

        // ACT
        var combination = BinaryNumbers.Range(0, 10, 8);

        // ASSERT
        Assert.That(combination.Select(BitArrayToString), Is.EquivalentTo(expectedResult));
    }

    private static string BitArrayToString(BitArray bits)
    {
        var sb = new StringBuilder();

        for (var i = bits.Count - 1; i >= 0; i--)
        {
            var c = bits[i] ? '1' : '0';
            sb.Append(c);
        }

        return sb.ToString();
    }
}