using System;
using System.IO;

namespace ProjectEuler.Problems
{
    public class Problem_0115 : Problem
    {
        private static readonly string QuestionFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0115_question.txt");

        public Problem_0115()
            : base(115)
        {
        }

        public override string Question => File.ReadAllText(QuestionFilePath);

        public override Answer Answer => 168;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            const int MAX_COUNT = 1_000_000;
            const int MINIMUM_BLOCK_LENGTH = 50;
            const int MINIMUM_PADDING_LENGTH = 1;

            var count = 0L;
            var rowLength = MINIMUM_BLOCK_LENGTH;

            while (count < MAX_COUNT)
            {
                count = CountBlockCombinations(rowLength++, MINIMUM_BLOCK_LENGTH, MINIMUM_PADDING_LENGTH);
            }

            return rowLength - 1;
        }

        private long CountBlockCombinations(int rowLength, int minimumBlockLength, int minimumPaddingLength)
        {
            var countStartingWithEmpty = this.CountBlockCombinationsFromPadding(minimumBlockLength, minimumPaddingLength, minimumPaddingLength - 1, rowLength - 1);
            var countStartingWithFilled = this.CountBlockCombinationsFromBlock(minimumBlockLength, minimumPaddingLength, minimumBlockLength - 1, rowLength - 1);
            
            return countStartingWithEmpty + countStartingWithFilled;
        }

        private long CountBlockCombinationsFromBlock(int minimumBlockLength, int minimumPaddingLength, int index, int end)
        {
            if (index == end)
            {
                return 1L;
            }

            // extend current
            var count = this.CountBlockCombinationsFromBlock(minimumBlockLength, minimumPaddingLength, index + 1, end);

            if (index + minimumPaddingLength <= end)
            {
                // add padding
                count += this.CountBlockCombinationsFromPadding(minimumBlockLength, minimumPaddingLength, index + minimumPaddingLength, end);
            }

            return count;
        }

        private long CountBlockCombinationsFromPadding(int minimumBlockLength, int minimumPaddingLength, int index, int end)
        {
            if (index == end)
            {
                return 1L;
            }

            // extend current
            var count = this.CountBlockCombinationsFromPadding(minimumBlockLength, minimumPaddingLength, index + 1, end);

            if (index + minimumBlockLength <= end)
            {
                // add block
                count += this.CountBlockCombinationsFromBlock(minimumBlockLength, minimumPaddingLength, index + minimumBlockLength, end);
            }

            return count;
        }
    }
}
