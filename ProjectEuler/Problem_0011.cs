using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Xml.Schema;

namespace ProjectEuler
{
    class Problem_0011 : IProblem<long>
    {
        private readonly string NumberString = System.IO.File.ReadAllText(
            @"C:\Users\thoma\source\repos\CodeChallenges\ProjectEuler\resources\problem_0011_numbers.txt");

        private readonly int[][] NumberMatrix = GetNumberMatrix();

        private int Rows { get => NumberMatrix.Length; }
        private int Columns { get => NumberMatrix[0].Length; }

        private static int[][] GetNumberMatrix()
        {
            var lines = System.IO.File.ReadAllLines(
                @"C:\Users\thoma\source\repos\CodeChallenges\ProjectEuler\resources\problem_0011_numbers.txt");

            var matrix = new int[lines.Length][];

            for (var row = 0; row < lines.Length; row++)
            {
                var digits = lines[row].Split(' ');

                matrix[row] = new int[digits.Length];

                for (var column = 0; column < digits.Length; column++)
                {
                    matrix[row][column] = int.Parse(digits[column]);
                }
            }
            return matrix;
        }

        private long GetLargestProductInGrid(int steps)
        {
            long largestProduct = 0;
            for (var row = 0; row < NumberMatrix.Length; row++)
            {
                for (var column = 0; column < NumberMatrix[row].Length; column++)
                {
                    long product;

                    var canGoUp = CanGoUp(row, steps);
                    var canGoDown = CanGoDown(row, steps);
                    var canGoLeft = CanGoLeft(column, steps);
                    var canGoRight = CanGoRight(column, steps);

                    if (canGoUp)
                    {
                        product = ProductUp(row, column, steps);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }

                    if (canGoUp && canGoLeft)
                    {
                        product = ProductUpLeft(row, column, steps);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }

                    if (canGoUp && canGoRight)
                    {
                        product = ProductUpRight(row, column, steps);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }

                    if (canGoDown)
                    {
                        product = ProductDown(row, column, steps);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }

                    if (canGoDown && canGoLeft)
                    {
                        product = ProductDownLeft(row, column, steps);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }

                    if (canGoDown && canGoRight)
                    {
                        product = ProductDownRight(row, column, steps);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }
                }
            }
            return largestProduct;
        }

        private bool CanGoUp(int row, int steps)
        {
            return row - steps >= 0;
        }

        private bool CanGoDown(int row, int steps)
        {
            return row + steps < Rows;
        }

        private bool CanGoLeft(int column, int steps)
        {
            return column - steps >= 0;
        }

        private bool CanGoRight(int column, int steps)
        {
            return column + steps < Columns;
        }

        private long ProductUp(int row, int column, int steps)
        {
            long product = 1;
            for (var d = 0; d < steps; d++)
            {
                product *= NumberMatrix[row - d][column];
            }
            return product;
        }

        private long ProductDown(int row, int column, int steps)
        {
            long product = 1;
            for (var d = 0; d < steps; d++)
            {
                product *= NumberMatrix[row + d][column];
            }
            return product;
        }

        private long ProductLeft(int row, int column, int steps)
        {

            long product = 1;
            for (var d = 0; d < steps; d++)
            {
                product *= NumberMatrix[row][column - d];
            }
            return product;
        }

        private long ProductRight(int row, int column, int steps)
        {
            long product = 1;
            for (var d = 0; d < steps; d++)
            {
                product *= NumberMatrix[row][column + d];
            }
            return product;
        }

        private long ProductUpLeft(int row, int column, int steps)
        {
            long product = 1;
            for (var d = 0; d < steps; d++)
            {
                product *= NumberMatrix[row - d][column - d];
            }
            return product;
        }

        private long ProductUpRight( int row, int column, int steps)
        {
            long product = 1;
            for (var d = 0; d < steps; d++)
            {
                product *= NumberMatrix[row - d][column + d];
            }
            return product;
        }

        private long ProductDownLeft(int row, int column, int steps)
        {
            long product = 1;
            for (var d = 0; d < steps; d++)
            {
                product *= NumberMatrix[row + d][column - d];
            }
            return product;
        }

        private long ProductDownRight(int row, int column, int steps)
        {
            long product = 1;
            for (var d = 0; d < steps; d++)
            {
                product *= NumberMatrix[row + d][column + d];
            }
            return product;
        }

        public string Question
        {
            get => NumberString + Environment.NewLine
                + "What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?";
        }

        public long Answer()
        {
            return GetLargestProductInGrid(4);
        }
    }
}
