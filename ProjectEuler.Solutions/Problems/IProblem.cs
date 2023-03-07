namespace ProjectEuler.Solutions.Problems;

public interface IProblem
{
    public int Number { get; }

    public string Title { get; }

    public string Description { get; }
}

public class Problem : IProblem
{
    public Problem(int number, string title, string description)
    {
        if (number < 0)
        {
            throw new ArgumentException("The problem number must be a positive integer.", nameof(number));
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("The title was empty.", nameof(title));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("The description was empty.", nameof(description));
        }

        this.Number = number;
        this.Title = title;
        this.Description = description;
    }

    public int Number { get; }

    public string Title { get; }

    public string Description { get; }
}