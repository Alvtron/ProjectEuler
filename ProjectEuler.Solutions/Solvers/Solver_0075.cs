using ProjectEuler.Mathematics.Functions;
using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0075 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var result = PythagoreanPerimeterCounter.CountSingularPerimeters(limit: 1_500_000);
        return Task.FromResult<Answer>(result);
    }

    private sealed class PythagoreanPerimeterCounter
    {
        private readonly int[] perimeterCounts;
        private readonly int limit;

        private PythagoreanPerimeterCounter(int limit)
        {
            this.limit = limit;
            this.perimeterCounts = new int[limit + 1];
        }

        /// <summary>
        /// Finds the count of singular integer right triangles.
        /// </summary>
        /// <returns>The number of perimeters that form exactly one right triangle.</returns>
        public static int CountSingularPerimeters(int limit)
        {
            var analyzer = new PythagoreanPerimeterCounter(limit);
            analyzer.GeneratePythagoreanTriples();
            return analyzer.CountUniquePerimeters();
        }

        /// <summary>
        /// Generates all Pythagorean triples using Euclid's formula.
        /// </summary>
        private void GeneratePythagoreanTriples()
        {
            var maxPrimitiveTripleFactor = (int)Math.Sqrt(this.limit / 2.0);
            for (var baseFactor = 2; baseFactor <= maxPrimitiveTripleFactor; baseFactor++)
            {
                this.GenerateTriplesForBaseFactor(baseFactor);
            }
        }

        private void GenerateTriplesForBaseFactor(int baseFactor)
        {
            for (var coFactor = 1; coFactor < baseFactor; coFactor++)
            {
                if (int.IsOddInteger(baseFactor - coFactor) && GreatestCommonDivisor.Of(baseFactor, coFactor) == 1)
                {
                    this.AddTriplesToPerimeterCounts(baseFactor, coFactor);
                }
            }
        }

        private void AddTriplesToPerimeterCounts(int baseFactor, int coFactor)
        {
            var a = baseFactor * baseFactor - coFactor * coFactor;
            var b = 2 * baseFactor * coFactor;
            var c = baseFactor * baseFactor + coFactor * coFactor;
            var perimeter = a + b + c;

            while (perimeter <= this.limit)
            {
                perimeterCounts[perimeter]++;
                perimeter += a + b + c;
            }
        }

        private int CountUniquePerimeters()
        {
            var count = 0;

            for (var i = 0; i <= this.limit; i++)
            {
                if (this.perimeterCounts[i] == 1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}