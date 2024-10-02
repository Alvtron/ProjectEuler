using System.Collections;
using ProjectEuler.Mathematics.Combinatorics;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0068 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var rings = CreateGonRings([1,2,3,4,5,6,7,8,9,10]);
        var strings = rings.Select(ring => string.Concat(ring.Select(l => $"{l.X}{l.Y}{l.Z}"))).Where(s => s.Length == 16);
        var biggestString = strings.Select(long.Parse).Max();

        return Task.FromResult<Answer>(biggestString);
    }

    private static IEnumerable<GonRing> CreateGonRings(int[] digits)
    {
        return Permutations.Of(digits).Select(permutedDigits => TryCreateGonRing(digits.Length, permutedDigits)).OfType<GonRing>();
    }

    private static GonRing? TryCreateGonRing(int numberOfDigits, IEnumerable<int> digits)
    {
        using var enumerator = digits.GetEnumerator();
        var lines = new Line[numberOfDigits / 2];
        lines[0] = CreateFirstLine(enumerator);
        for (var index = 1; index < lines.Length - 1; index++)
        {
            lines[index] = CreateNextLine(enumerator, lines[index - 1]);
            if (lines[0].Sum != lines[index].Sum)
            {
                return null;
            }
        }

        lines[^1] = CreateLastLine(enumerator, lines[0], lines[^2]);
        if (lines[0].Sum != lines[^1].Sum)
        {
            return null; // continue;
        }

        return new GonRing(lines);
    }

    private static Line CreateFirstLine(IEnumerator<int> enumerator)
    {
        enumerator.MoveNext();
        var x = enumerator.Current;
        enumerator.MoveNext();
        var y = enumerator.Current;
        enumerator.MoveNext();
        var z = enumerator.Current;

        return new Line(x, y, z);
    }

    private static Line CreateNextLine(IEnumerator<int> enumerator, Line previousLine)
    {
        enumerator.MoveNext();
        var x = enumerator.Current;
        enumerator.MoveNext();
        var z = enumerator.Current;

        return new Line(x, previousLine.Z, z);
    }

    private static Line CreateLastLine(IEnumerator<int> enumerator, Line firstLine, Line previousLine)
    {
        enumerator.MoveNext();
        var x = enumerator.Current;

        return new Line(x, previousLine.Z, firstLine.Y);
    }

    private readonly record struct Line(int X, int Y, int Z)
    {
        public int Sum { get; } = X + Y + Z;
    }

    private class GonRing : IEnumerable<Line>
    {
        private readonly Line[] lines;
        private readonly int minIndex;

        public GonRing(Line[] lines)
        {
            this.lines = lines;
            this.minIndex = Array.IndexOf(lines, lines.MinBy(l => l.X));
        }

        public IEnumerator<Line> GetEnumerator() => lines.Skip(minIndex).Concat(lines.Take(minIndex)).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}