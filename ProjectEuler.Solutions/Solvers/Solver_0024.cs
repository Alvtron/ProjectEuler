using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

public class Solver_0024 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var digits = Enumerable.Range(0, 10).ToArray();

        for (var index = 1; index < 1_000_000; index++)
        {
            Permutate(digits);
        }

        var lexicographicPermutation = string.Concat(digits);
        return await Task.FromResult(lexicographicPermutation);
    }

    private static void Permutate(int[] digits)
    {
        // find non-increasing suffix
        var i = digits.Length - 1;
        while (i > 0 && digits[i - 1] >= digits[i])
        {
            i--;
        }

        // if suffix is first index, no more permutations exists
        if (i == 0)
        {
            throw new InvalidOperationException("No more permutations exists.");
        }

        // find successor to pivot
        var j = digits.Length - 1;
        while (digits[j] <= digits[i - 1])
        {
            j--;
        }

        // swap the pivot with successor
        Swap(ref digits[j], ref digits[i - 1]);

        // reverse suffix
        Array.Reverse(digits, i, digits.Length - i);
    }

    private static void Swap(ref int left, ref int right)
    {
        (left, right) = (right, left);
    }
}