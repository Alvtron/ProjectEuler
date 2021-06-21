using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ProjectEuler.Library;

namespace ProjectEuler.Problems
{
    public class Problem_0028 : Problem
    {
        private static readonly string QuestionFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0028_question.txt");

        public Problem_0028()
            : base(28)
        {
        }

        public override string Question => File.ReadAllText(QuestionFilePath);

        public override Answer Answer => 669171001;

        public override bool IsSolved => true;

        public override Answer Solve()
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

            return sum;
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
                p => p.Right(),
                p => p.Down(),
                p => p.Left(),
                p => p.Up(),
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

        private static void PrintSpiral(int[,] spiral)
        {
            Debug.WriteLine("");
            for (var j = 0; j < spiral.GetLength(0); j++)
            {
                Debug.WriteLine(string.Join("\t", Enumerable.Range(0, spiral.GetLength(1)).Select(i => spiral[i, j])));
            }   
        }
    }
}
