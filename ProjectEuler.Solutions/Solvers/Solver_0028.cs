using ProjectEuler.Solutions.Answers;
using ProjectEuler.Utilities.Collections;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0028 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        const int SIZE = 1001;
        var spiral = CreateSpiral(SIZE);

        const int MIDDLE = SIZE / 2;
        var sum = 0;

        for (var index = 0; index < MIDDLE; index++)
        {
            var lastIndex = SIZE - 1 - index;
                
            sum += spiral[index, index];
            sum += spiral[index, lastIndex];
            sum += spiral[lastIndex, index];
            sum += spiral[lastIndex, lastIndex];
        }

        sum += spiral[MIDDLE, MIDDLE];

        return Task.FromResult<Answer>(sum);
    }

    private static int[,] CreateSpiral(int size)
    {
        if (size < 0)
        {
            throw new ArgumentException("The size must be a positive number.", nameof(size));
        }

        if (size % 2 == 0)
        {
            throw new ArgumentException("The size must be an odd number.", nameof(size));
        }

        var number = 1;
        var totalSize = size * size;
        var spiral = new int[size, size];

        var position = new Position(size / 2, size / 2);
        spiral[position.X, position.Y] = number++;

        var moves = new Cycle<Func<Position, Position>>
        {
            p => p.Move(Position.Right),
            p => p.Move(Position.Down),
            p => p.Move(Position.Left),
            p => p.Move(Position.Up),
        };

        var currentMove = moves.Next();

        while (number <= totalSize)
        {
            position = currentMove(position);
            spiral[position.X, position.Y] = number++;

            var nextMove = moves.Peek();
            var nextPosition = nextMove(position);

            if (spiral[nextPosition.X, nextPosition.Y] == 0)
            {
                currentMove = moves.Next();
            }
        }

        return spiral;
    }

    public readonly record struct Position(int X, int Y)
    {
        public static Position Right => new(1, 0);
        public static Position Left => new(-1, 0);
        public static Position Up => new(0, 1);
        public static Position Down => new(0, -1);

        public Position Move(Position direction)
            => new(this.X + direction.X, this.Y + direction.Y);
    }
}