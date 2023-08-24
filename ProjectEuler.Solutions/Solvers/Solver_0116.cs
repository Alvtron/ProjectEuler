using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0116 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        const int ROW_LENGTH = 50;

        var redBlockCounter = new BlockCombinationCounter(ROW_LENGTH, 2);
        var greenBlockCounter = new BlockCombinationCounter(ROW_LENGTH, 3);
        var blueBlockCounter = new BlockCombinationCounter(ROW_LENGTH, 4);

        var numberOfBlockCombinations = redBlockCounter.Count() + greenBlockCounter.Count() + blueBlockCounter.Count() - 3;
        return await Task.FromResult(numberOfBlockCombinations);
    }

    private sealed class BlockCombinationCounter
    {
        private readonly int rowLength;
        private readonly int blockLength;
        private readonly long?[] countFromBlockCache;
        private readonly long?[] countFromEmptyCache;

        public BlockCombinationCounter(int rowLength, int blockLength)
        {
            this.rowLength = rowLength;
            this.blockLength = blockLength;
            this.countFromBlockCache = new long?[rowLength];
            this.countFromEmptyCache = new long?[rowLength];
        }

        public long Count()
        {
            var countStartingWithEmpty = this.CountBlockCombinationsFromPadding(0, this.rowLength - 1);
            var countStartingWithFilled = this.CountBlockCombinationsFromBlock(this.blockLength - 1, this.rowLength - 1);

            return countStartingWithEmpty + countStartingWithFilled;
        }

        private long CountBlockCombinationsFromBlock(int index, int end)
        {
            if (index == end)
            {
                return 1L;
            }

            if (this.countFromBlockCache[index].HasValue)
            {
                return this.countFromBlockCache[index].Value;
            }

            var count = this.CountBlockCombinationsFromPadding(index + 1, end);

            if (index + this.blockLength <= end)
            {
                count += this.CountBlockCombinationsFromBlock(index + this.blockLength, end);
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

            if (this.countFromEmptyCache[index].HasValue)
            {
                return this.countFromEmptyCache[index].Value;
            }

            var count = this.CountBlockCombinationsFromPadding(index + 1, end);

            if (index + this.blockLength <= end)
            {
                count += this.CountBlockCombinationsFromBlock(index + this.blockLength, end);
            }

            this.countFromEmptyCache[index] = count;
            return count;
        }
    }
}