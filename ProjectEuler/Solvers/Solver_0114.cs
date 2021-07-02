using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0114 : ISolver
    {
        private const int ROW_LENGTH = 50;
        private const int MINIMUM_BLOCK_LENGTH = 3;
        private const int MINIMUM_PADDING_LENGTH = 1;

        private readonly long?[] countFromBlockCache = new long?[ROW_LENGTH];
        private readonly long?[] countFromEmptyCache = new long?[ROW_LENGTH];

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
                return 1L;
            }

            if (this.countFromBlockCache[index].HasValue)
            {
                return this.countFromBlockCache[index].Value;
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

            if (this.countFromEmptyCache[index].HasValue)
            {
                return this.countFromEmptyCache[index].Value;
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
}
