using System;
using System.IO;

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
            const int PADDING = 1;

            return CountBlockCombinations(ROW_LENGTH, MINIMUM_BLOCK_LENGTH, PADDING);
        }

        private long CountBlockCombinations(int rowLength, int minimumFillLength, int minimumPaddingLength)
        {
            var countStartingWithEmpty = this.CountBlockCombinationsFromPadding(minimumFillLength, minimumPaddingLength, minimumPaddingLength - 1, rowLength - 1);
            var countStartingWithFilled = this.CountBlockCombinationsFromBlock(minimumFillLength, minimumPaddingLength, minimumFillLength - 1, rowLength - 1);
            
            return countStartingWithEmpty + countStartingWithFilled;
        }

        private long CountBlockCombinationsFromBlock(int minimumFillLength, int minimumPaddingLength, int index, int end)
        {
            if (index == end)
            {
                return 1L;
            }

            // extend current
            var count = this.CountBlockCombinationsFromBlock(minimumFillLength, minimumPaddingLength, index + 1, end);

            if (index + minimumPaddingLength <= end)
            {
                // add padding
                count += this.CountBlockCombinationsFromPadding(minimumFillLength, minimumPaddingLength, index + minimumPaddingLength, end);
            }

            return count;
        }

        private long CountBlockCombinationsFromPadding(int minimumFillLength, int minimumPaddingLength, int index, int end)
        {
            if (index == end)
            {
                return 1L;
            }

            // extend current
            var count = this.CountBlockCombinationsFromPadding(minimumFillLength, minimumPaddingLength, index + 1, end);

            if (index + minimumFillLength <= end)
            {
                // add block
                count += this.CountBlockCombinationsFromBlock(minimumFillLength, minimumPaddingLength, index + minimumFillLength, end);
            }

            return count;
        }
    }
}
