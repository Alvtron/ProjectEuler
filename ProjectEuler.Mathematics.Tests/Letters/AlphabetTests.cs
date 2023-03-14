using ProjectEuler.Mathematics.Letters;

namespace ProjectEuler.Mathematics.Tests.Letters;

[TestFixture]
public class AlphabetTests
{
    private static readonly string UpperCaseAlphabetLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private static readonly string LowerCaseAlphabetLetters = "abcdefghijklmnopqrstuvwxyz";

    public static object[] UpperCaseLettersAndPositions = UpperCaseAlphabetLetters.Select((letter, index) 
        => new object[] { letter, index + 1 }).ToArray();

    public static object[] LowerCaseLettersAndPositions = LowerCaseAlphabetLetters.Select((letter, index) 
        => new object[] { letter, index + 1 }).ToArray();

    public static object[] PositionsAndLetters = UpperCaseAlphabetLetters.Select((letter, index)
        => new object[] { index + 1, letter }).ToArray();

    [Test]
    public void IsAlphabeticalLetter_UpperCaseLettersInTheAlphabet_ReturnsTrue()
    {
        // ACT
        var isAlphabeticalLetter = UpperCaseAlphabetLetters.All(Alphabet.IsAlphabeticalLetter);

        // ASSERT
        Assert.That(isAlphabeticalLetter, Is.True);
    }

    [Test]
    public void IsAlphabeticalLetter_LowerCaseLettersInTheAlphabet_ReturnsTrue()
    {
        // ACT
        var isAlphabeticalLetters = LowerCaseAlphabetLetters.All(Alphabet.IsAlphabeticalLetter);

        // ASSERT
        Assert.That(isAlphabeticalLetters, Is.True);
    }

    [TestCase("!@#&()–[{}]:;',?/*~$^+=<>")]
    public void IsAlphabeticalLetter_NoAlphabeticalLetters_ReturnsFalse(string symbols)
    {
        // ACT & ASSERT
        foreach (var symbol in symbols)
        {
            Assert.That(Alphabet.IsAlphabeticalLetter(symbol), Is.False);
        }
    }

    [Test]
    public void IsAlphabeticalPosition_OneToTwentySix_ReturnsTrue()
    {
        // ACT
        var isAlphabeticalPositions = Enumerable.Range(1, 26).All(Alphabet.IsAlphabeticalPosition);

        // ASSERT
        Assert.That(isAlphabeticalPositions, Is.True);
    }

    [Test]
    public void IsAlphabeticalPosition_NotOneToTwentySix_ReturnsFalse()
    {
        // ARRANGE
        var isNotAlphabeticalPositions = Enumerable
            .Range(-9999, 9999)
            .Concat(Enumerable.Range(27, 9999))
            .All(position => !Alphabet.IsAlphabeticalPosition(position));

        // ACT & ASSERT
        Assert.That(isNotAlphabeticalPositions, Is.True);
    }

    [TestCaseSource(nameof(UpperCaseLettersAndPositions))]
    public void GetPositionOf_UpperCaseLettersInTheAlphabet_ReturnsThePosition(char letter, int expectedPosition)
    {
        // ACT
        var position = Alphabet.GetPositionOf(letter);

        // ASSERT
        Assert.That(position, Is.EqualTo(expectedPosition));
    }

    [TestCaseSource(nameof(LowerCaseLettersAndPositions))]
    public void GetPositionOf_LowerCaseLettersInTheAlphabet_ReturnsThePosition(char letter, int expectedPosition)
    {
        // ACT
        var position = Alphabet.GetPositionOf(letter);

        // ASSERT
        Assert.That(position, Is.EqualTo(expectedPosition));
    }

    [TestCase("!@#&()–[{}]:;',?/*~$^+=<>")]
    public void GetPositionOf_NoLetters_ThrowsArgumentOutOfRangeException(string symbols)
    {
        // ACT & ASSERT
        foreach (var symbol in symbols)
        {
            Assert.That(() => Alphabet.GetPositionOf(symbol), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }

    [TestCaseSource(nameof(PositionsAndLetters))]
    public void GetLetterAt_AlphabeticalPositions_ReturnsTheLetterAtPosition(int position, int expectedLetter)
    {
        // ACT
        var letter = Alphabet.GetLetterAt(position);

        // ASSERT
        Assert.That(letter, Is.EqualTo(expectedLetter));
    }

    [TestCase(new[] {-1_000, -100, -10, -5, -3, -2, -1, 0, 27, 28, 29, 30, 35, 50, 100, 1_000, 1_0000})]
    public void GetLetterAt_PositionsOutOfRange_ThrowsArgumentOutOfRangeException(int[] positions)
    {
        // ACT & ASSERT
        foreach (var position in positions)
        {
            Assert.That(() => Alphabet.GetLetterAt(position), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}