using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0079 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var passcode = DetermineShortestPossibleSecretPasscode();
        return Task.FromResult<Answer>(passcode);
    }

    private static string DetermineShortestPossibleSecretPasscode()
    {
        var keys = Resource_0079.Keys.AsSpan();
        var precedenceGraph = BuildPrecedenceGraph(keys);
        var passcode = PerformTopologicalSort(precedenceGraph);
        return string.Concat(passcode);
    }

    private static Dictionary<char, HashSet<char>> BuildPrecedenceGraph(ReadOnlySpan<char> keys)
    {
        var graph = new Dictionary<char, HashSet<char>>();

        foreach (var lineRange in keys.Split(Environment.NewLine))
        {
            var key = keys[lineRange];
            for (var i = 0; i < key.Length; i++)
            {
                var currentDigit = key[i];
                if (!graph.TryGetValue(currentDigit, out var neighbors))
                {
                    neighbors = graph[currentDigit] = new HashSet<char>();
                }

                for (var j = i + 1; j < key.Length; j++)
                {
                    neighbors.Add(key[j]);
                }
            }
        }

        return graph;
    }

    private static IEnumerable<char> PerformTopologicalSort(Dictionary<char, HashSet<char>> graph)
    {
        var inDegrees = graph.Keys.ToDictionary(node => node, _ => 0);

        foreach (var neighbor in graph.Values.SelectMany(neighbors => neighbors))
        {
            inDegrees[neighbor]++;
        }

        var zeroInDegreeNodes = new Queue<char>(inDegrees.Where(pair => pair.Value == 0).Select(pair => pair.Key));

        while (zeroInDegreeNodes.Count > 0)
        {
            var currentNode = zeroInDegreeNodes.Dequeue();
            yield return currentNode;

            foreach (var neighbor in graph[currentNode])
            {
                inDegrees[neighbor]--;
                if (inDegrees[neighbor] == 0)
                {
                    zeroInDegreeNodes.Enqueue(neighbor);
                }
            }
        }
    }
}
