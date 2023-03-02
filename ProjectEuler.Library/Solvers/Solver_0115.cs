using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0115 : ISolver
{
    private const int MAX_COUNT = 1_000_000;
    private const int MINIMUM_BLOCK_LENGTH = 50;
    private const int MINIMUM_PADDING_LENGTH = 1;

    private Dictionary<int, long> countFromBlockCache;
    private Dictionary<int, long> countFromEmptyCache;

    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var count = 0L;
        var rowLength = MINIMUM_BLOCK_LENGTH;

        while (count < MAX_COUNT)
        {
            count = this.CountBlockCombinations(rowLength++);
        }

        return await Task.FromResult(rowLength - 1);
    }

    private long CountBlockCombinations(int rowLength)
    {
        this.countFromBlockCache = new Dictionary<int, long>();
        this.countFromEmptyCache = new Dictionary<int, long>();

        var countStartingWithEmpty =
            this.CountBlockCombinationsFromPadding(MINIMUM_PADDING_LENGTH - 1, rowLength - 1);
        var countStartingWithFilled = this.CountBlockCombinationsFromBlock(MINIMUM_BLOCK_LENGTH - 1, rowLength - 1);

        return countStartingWithEmpty + countStartingWithFilled;
    }

    private long CountBlockCombinationsFromBlock(int index, int end)
    {
        if (index == end)
        {
            return 1L;
        }

        if (this.countFromBlockCache.TryGetValue(index, out var cachedCount))
        {
            return cachedCount;
        }

        var count = this.CountBlockCombinationsFromBlock(index + 1, end);

        if (index + MINIMUM_PADDING_LENGTH <= end)
        {
            count += this.CountBlockCombinationsFromPadding(index + MINIMUM_PADDING_LENGTH, end);
        }

        this.countFromBlockCache[index] = count;
        return count;
    }

    private long CountBlockCombinationsFromPadding(int index, int end)
    {
        if (index == end)
        {
            return 1L;
        }

        if (this.countFromEmptyCache.TryGetValue(index, out var cachedCount))
        {
            return cachedCount;
        }

        var count = this.CountBlockCombinationsFromPadding(index + 1, end);

        if (index + MINIMUM_BLOCK_LENGTH <= end)
        {
            count += this.CountBlockCombinationsFromBlock(index + MINIMUM_BLOCK_LENGTH, end);
        }

        this.countFromEmptyCache[index] = count;
        return count;
    }
}