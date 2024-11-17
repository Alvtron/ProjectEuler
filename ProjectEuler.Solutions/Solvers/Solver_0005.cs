using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0005 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var numbers = Enumerable.Range(1, 20).ToArray();
        var smallestMultiple = SmallestNumberDivisibleBy(numbers);
        return Task.FromResult<Answer>(smallestMultiple);
    }

    private static long SmallestNumberDivisibleBy(params int[] numbers)
    {
        Array.Sort(numbers, (a, b) => b - a); 

        var max = numbers[0]; 
        long current = max;

        for (var i = 1; i < numbers.Length;)
        {
            if (current % numbers[i] != 0)
            {
                current += max;
                i = 1;
            }
            else i++;
        }

        return current; 
    }
}