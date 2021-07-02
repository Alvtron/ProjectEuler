using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0015 : ISolver
    {
        public Answer Solve()
        {
            return GetNumberOfPaths(20, 20);
        }

        private static bool IsAtTargetLocation(int x, int y, long?[,] grid)
        {
            return x == grid.GetLength(0) - 1 && (y == grid.GetLength(1) - 1);
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
            return CountWays(0, 0, grid);
        }
    }
}
