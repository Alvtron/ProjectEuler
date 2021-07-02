using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0114 : ISolver
    {
        private const int ROW_LENGTH = 50;
        private const int MINIMUM_BLOCK_LENGTH = 3;
        private const int MINIMUM_PADDING_LENGTH = 1;

        private readonly Cache<long> countFromBlockCache = new(ROW_LENGTH, -1L);
        private readonly Cache<long> countFromEmptyCache = new(ROW_LENGTH, -1L);

        public Answer Solve()
        {
            var countStartingWithEmpty = this.CountBlockCombinationsFromPadding(MINIMUM_PADDING_LENGTH - 1, ROW_LENGTH - 1);
            var countStartingWithFilled = this.CountBlockCombinationsFromBlock(MINIMUM_BLOCK_LENGTH - 1, ROW_LENGTH - 1);

            return countStartingWithEmpty + countStartingWithFilled;
        }

        private long CountBlockCombinationsFromBlock(int index, int end)
        {
            if (index == end)
            {
                this.countFromBlockCache[index] = 1L;
                return 1L;
            }

            if (this.countFromBlockCache.TryGetValue(index, out var cachedCount))
            {
                return cachedCount;
            }

            // extend current
            var count = this.CountBlockCombinationsFromBlock(index + 1, end);

            if (index + MINIMUM_PADDING_LENGTH <= end)
            {
                // add padding
                count += this.CountBlockCombinationsFromPadding(index + MINIMUM_PADDING_LENGTH, end);
            }

            this.countFromBlockCache[index] = count;

            return count;
        }

        private long CountBlockCombinationsFromPadding(int index, int end)
        {
            if (index == end)
            {
                this.countFromEmptyCache[index] = 1L;
                return 1L;
            }

            if (this.countFromEmptyCache.TryGetValue(index, out var cachedCount))
            {
                return cachedCount;
            }

            // extend current
            var count = this.CountBlockCombinationsFromPadding(index + 1, end);

            if (index + MINIMUM_BLOCK_LENGTH <= end)
            {
                // add block
                count += this.CountBlockCombinationsFromBlock(index + MINIMUM_BLOCK_LENGTH, end);
            }

            this.countFromEmptyCache[index] = count;

            return count;
        }
    }
}
