using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Answers;

public class AnswerSource
{
    private readonly Dictionary<int, Answer> answers;

    public AnswerSource()
    {
        this.answers = LoadAnswers();
    }

    /// <summary>
    /// Whether this source has an answer.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public bool HasAnswer(int number)
    {
        return this.answers.ContainsKey(number);
    }

    public Answer GetAnswer(int number)
    {
        return this.answers[number];
    }

    private static Dictionary<int, Answer> LoadAnswers()
    {
        var answersFile = ResourcesHelper.GetResourcePath("answers.txt");
        var numbersAndAnswers = File.ReadAllLines(answersFile);
        return numbersAndAnswers
            .Select(a => a.Split(';'))
            .ToDictionary(a => int.Parse(a[0]), a => new Answer(a[1]));
    }
}