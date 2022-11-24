using HtmlAgilityPack;

namespace ProjectEuler.Library.Problems;

public class ProblemSource
{
    private readonly Dictionary<int, IProblem> cache;

    public ProblemSource()
    {
        this.cache = new Dictionary<int, IProblem>();
    }

    public async Task<IProblem> GetProblemAsync(int number, CancellationToken cancellationToken = default)
    {
        if (this.cache.TryGetValue(number, out var cachedProblem))
        {
            return cachedProblem;
        }

        var url = CreateProblemUrl(number);
        var web = new HtmlWeb();
        var htmlDoc = await web.LoadFromWebAsync(url.ToString(), cancellationToken);

        var titleNode = htmlDoc.DocumentNode.SelectSingleNode("//h2");

        var descriptionNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='problem_content']");

        return this.cache[number] = new Problem(number, titleNode.InnerText, descriptionNode.InnerText);
    }

    private static Uri CreateProblemUrl(int number)
    {
        return new Uri(@$"https://projecteuler.net/problem={number}");
    }
}