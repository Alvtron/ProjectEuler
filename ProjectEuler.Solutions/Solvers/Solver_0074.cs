using ProjectEuler.Mathematics.Functions;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0074 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        const int length = 60;
        const int limit = 1_000_000;
        var result = FindDigitFactorialChainsOfLength(length, limit);
        return Task.FromResult<Answer>(result);
    }

    static int FindDigitFactorialChainsOfLength(int length, int limit)
    {
        var count = 0;
        var nodes = new Dictionary<int, Node>();

        for (var number = 1; number < limit; number++)
        {
            if (!nodes.ContainsKey(number))
            {
                nodes[number] = new Node {Value = number };
            }

            var chainLength = FindChainLength(nodes[number], nodes);
            if (chainLength == length)
            {
                count++;
            }
        }

        return count;
    }

    static int FindChainLength(Node current, Dictionary<int, Node> nodes)
    {
        var seen = new HashSet<int>();
        var chain = new List<Node>();

        while (!seen.Contains(current.Value))
        {
            // If the chain length for this node is already known, use it
            if (current.ChainLength != -1)
            {
                foreach (var node in chain)
                {
                    node.ChainLength = current.ChainLength + chain.Count - chain.IndexOf(node);
                }
                return current.ChainLength + chain.Count;
            }

            chain.Add(current);
            seen.Add(current.Value);

            var nextValue = Factorial.Sum(current.Value);
            if (!nodes.ContainsKey(nextValue))
            {
                nodes[nextValue] = new Node { Value = nextValue };
            }

            current = nodes[nextValue];
        }

        // If a loop is detected, assign loop lengths
        var loopStart = chain.IndexOf(current);
        var loopLength = chain.Count - loopStart;

        for (var i = 0; i < chain.Count; i++)
        {
            if (i < loopStart)
            {
                chain[i].ChainLength = chain.Count - i;
            }
            else
            {
                chain[i].ChainLength = loopLength;
            }
        }

        return chain.Count;
    }

    public record Node
    {
        public int Value { get; init; }

        public int ChainLength { get; set; } = -1;
    }
}