namespace ProjectEuler.Mathematics.Letters;

public static class Alphabet
{
    private static readonly IReadOnlyDictionary<char, int> PositionsByLetters;
    private static readonly IReadOnlyDictionary<int, char> LettersByPositions;

    static Alphabet()
    {
        PositionsByLetters = Enumerable.Range(1, Letters.Length)
            .ToDictionary(position => Letters[position - 1], position => position);
        LettersByPositions = Enumerable.Range(1, Letters.Length)
            .ToDictionary(position => position, position => Letters[position - 1]);
    }

    /// <summary>
    /// Returns all the letters in the alphabet.
    /// </summary>
    public static string Letters { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    /// Determines whether the <paramref name="letter"/> is an alphabetical letter ('a' to 'z' or 'A' to 'Z').
    /// </summary>
    /// <param name="letter">The letter to check.</param>
    /// <returns><see langword="true"/> if the <paramref name="letter"/> is an alphabetical letter; <see langword="false"/> otherwise.</returns>
    public static bool IsAlphabeticalLetter(char letter)
    {
        return PositionsByLetters.ContainsKey(char.ToUpper(letter));
    }

    /// <summary>
    /// Determines whether the <paramref name="position"/> is an alphabetical position (between 1 and 26 inclusive).
    /// </summary>
    /// <param name="position">The position to check.</param>
    /// <returns><see langword="true"/> if the <paramref name="position"/> is an alphabetical position; <see langword="false"/> otherwise.</returns>
    public static bool IsAlphabeticalPosition(int position)
    {
        return position is > 0 and < 27;
    }

    /// <summary>
    /// Finds the position of the specified <paramref name="letter"/> in the alphabet.
    /// </summary>
    /// <param name="letter">The letter to find position of.</param>
    /// <returns>The <see langword="int"/> position of the <paramref name="letter"/> in the alphabet.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the letter is not a character in the alphabet.</exception>
    public static int GetPositionOf(char letter)
    {
        if (!PositionsByLetters.TryGetValue(char.ToUpper(letter), out var position))
        {
            throw new ArgumentOutOfRangeException(nameof(letter), letter, $"The symbol '{letter}' is not in the alphabet.");
        }

        return position;

    }

    /// <summary>
    /// Finds the letter at the specified <paramref name="position"/> in the alphabet.
    /// </summary>
    /// <param name="position">The position of the letter to find.</param>
    /// <returns>The <see langword="char"/> letter at the <paramref name="position"/> in the alphabet.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the position is not outside of range.</exception>
    public static char GetLetterAt(int position)
    {
        if (!LettersByPositions.TryGetValue(position, out var letter))
        {
            throw new ArgumentOutOfRangeException(nameof(position), position, $"The position '{position}' is not an alphabetical position.");
        }

        return letter;
    }
}