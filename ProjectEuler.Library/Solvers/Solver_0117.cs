using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0117 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        const int ROW_LENGTH = 50;

        var grayBlock = new Block(Color.Gray, 1);
        var redBlock = new Block(Color.Red, 2);
        var greenBlock = new Block(Color.Green, 3);
        var blueBlock = new Block(Color.Blue, 4);
        var blockCounter = new BlockCombinationCounter(ROW_LENGTH, grayBlock, redBlock, greenBlock, blueBlock);

        var numberOfBlockCombinations = blockCounter.Count();
        return await Task.FromResult(numberOfBlockCombinations);
    }

    private enum Color
    {
        Gray,
        Red,
        Green,
        Blue,
    }

    private sealed class Block
    {
        public Block(Color color, int length)
        {
            this.Color = color;
            this.Length = length;
        }

        public Color Color { get; }

        public int Length { get; }
    }

    private sealed class BlockCombinationCounter
    {
        private readonly int rowLength;
        private readonly Block[] blocks;
        private readonly Dictionary<Block, long?[]> cache;

        public BlockCombinationCounter(int rowLength, params Block[] blocks)
        {
            this.rowLength = rowLength;
            this.blocks = blocks;

            this.cache = blocks.ToDictionary(block => block, _ => new long?[rowLength]);
        }

        public long Count()
        {
            return this.blocks.Sum(block => this.CountBlockCombinations(block, block.Length - 1, this.rowLength - 1));
        }

        private long CountBlockCombinations(Block block, int index, int end)
        {
            if (index > end)
            {
                return 0L;
            }

            if (index == end)
            {
                return 1L;
            }

            if (this.cache[block][index].HasValue)
            {
                return this.cache[block][index].Value;
            }

            var count = this.blocks.Sum(nextBlock => this.CountBlockCombinations(nextBlock, index + nextBlock.Length, end));

            this.cache[block][index] = count;
            return count;
        }
    }
}