using System;
using System.IO;
using ProjectEuler.Library;

namespace ProjectEuler.Problems
{
    public class Problem_0114 : Problem
    {
        private static readonly string QuestionFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0114_question.txt");

        public Problem_0114()
            : base(114)
        {
        }

        public override string Question => File.ReadAllText(QuestionFilePath);

        public override Answer Answer => 16475640049L;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            const int ROW_LENGTH = 50;
            const int MINIMUM_BLOCK_LENGTH = 3;
            const int MINIMUM_PADDING_LENGTH = 1;

            return new Problem_114_Solver(ROW_LENGTH, MINIMUM_BLOCK_LENGTH, MINIMUM_PADDING_LENGTH).Solve();
        }

        private class Problem_114_Solver : ISolver
        {
            private readonly int rowLength;
            private readonly int minimumBlockLength;
            private readonly int minimumPaddingLength;
            private readonly Cache<long> countFromBlockCache;
            private readonly Cache<long> countFromEmptyCache;

            public Problem_114_Solver(int rowLength, int minimumBlockLength, int minimumPaddingLength)
            {
                this.rowLength = rowLength;
                this.minimumBlockLength = minimumBlockLength;
                this.minimumPaddingLength = minimumPaddingLength;

                this.countFromEmptyCache = new Cache<long>(rowLength, -1L);
                this.countFromBlockCache = new Cache<long>(rowLength, -1L);
            }

            public Answer Solve()
            {
                var countStartingWithEmpty = this.CountBlockCombinationsFromPadding(this.minimumPaddingLength - 1, rowLength - 1);
                var countStartingWithFilled = this.CountBlockCombinationsFromBlock(this.minimumBlockLength - 1, rowLength - 1);

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

                if (index + this.minimumPaddingLength <= end)
                {
                    // add padding
                    count += this.CountBlockCombinationsFromPadding(index + this.minimumPaddingLength, end);
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

                if (index + this.minimumBlockLength <= end)
                {
                    // add block
                    count += this.CountBlockCombinationsFromBlock(index + this.minimumBlockLength, end);
                }

                this.countFromEmptyCache[index] = count;

                return count;
            }
        }
    }
}
