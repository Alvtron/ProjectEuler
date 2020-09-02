using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjectEuler
{
    class Problem_0015 : IProblem<long>
    {
        private static bool IsAtTargetLocation(int x, int y, long?[,] grid)
        {
            return (x == grid.GetLength(0) - 1) && (y == grid.GetLength(1) - 1);
        } 
        private static bool IsOutOfBounds(int x, int y, long?[,] grid)
        {
            return x < 0 || x >= grid.GetLength(0) || y < 0 || y >= grid.GetLength(1);
        }

        private static long CountWays(int x, int y, long?[,] grid)
        {
            if (IsOutOfBounds(x, y, grid))
            {
                return 0;
            }

            if (IsAtTargetLocation(x, y, grid))
            {
                return 1;
            }

            if (grid[x, y].HasValue)
            {
                return grid[x, y].Value;
            }

            var ways = 0L;

            ways += CountWays(x + 1, y, grid);
            ways += CountWays(x, y + 1, grid);

            grid[x, y] = ways;

            return ways;
        }

        private static long GetNumberOfPaths(int gridWidth, int gridHeight)
        {
            var grid = new long?[gridWidth + 1, gridHeight + 1];
            var ways = CountWays(0, 0, grid);
            return ways;
        }

        public string Question
        {
            get => "Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner."
                + Environment.NewLine
                + "How many such routes are there through a 20×20 grid?";
        }

        public long Answer()
        {
            var answer = GetNumberOfPaths(20, 20);
            return answer;
        }
    }
}
