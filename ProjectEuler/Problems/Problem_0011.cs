using System;
using System.IO;

namespace ProjectEuler.Problems
{
    public class Problem_0011 : Problem
    {
        private static readonly string QuestionFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0011_question.txt");
        private static readonly string MatrixFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0011_numbers.txt");

        public Problem_0011()
            : base(11)
        {
        }

        public override string Question => File.ReadAllText(QuestionFilePath);

        public override Answer Answer => 70600674L;

        public override bool IsSolved => true;

        public override Answer Solve()
        {
            var matrix = ConvertStringToMatrix(File.ReadAllText(MatrixFilePath), Environment.NewLine, " ", 20);

            return GetLargestProductInGrid(matrix, 4);
        }

        private static int[,] ConvertStringToMatrix(string source, string rowDelimiter, string columnDelimiter, int size)
        {
            var lines = source.Split(rowDelimiter);

            var matrix = new int[size, size];

            for (var row = 0; row < lines.Length; row++)
            {
                var digits = lines[row].Split(columnDelimiter);

                for (var column = 0; column < digits.Length; column++)
                {
                    matrix[row, column] = int.Parse(digits[column]);
                }
            }
            return matrix;
        }

        private long GetLargestProductInGrid(int[,] matrix, int steps)
        {
            var numberOfRows = matrix.GetLength(0);
            var numberOfColumns = matrix.GetLength(1);

            bool CanGoUp(int row)
            {
                return row - steps >= 0;
            }
            
            bool CanGoDown(int row)
            {
                return row + steps < numberOfRows;
            }

            bool CanGoLeft(int column)
            {
                return column - steps >= 0;
            }

            bool CanGoRight(int column)
            {
                return column + steps < numberOfColumns;
            }

            long ProductUp(int row, int column)
            {
                long product = 1;
                for (var d = 0; d < steps; d++)
                {
                    product *= matrix[row - d, column];
                }
                return product;
            }

            long ProductDown(int row, int column)
            {
                long product = 1;
                for (var d = 0; d < steps; d++)
                {
                    product *= matrix[row + d, column];
                }
                return product;
            }

            long ProductUpLeft(int row, int column)
            {
                long product = 1;
                for (var d = 0; d < steps; d++)
                {
                    product *= matrix[row - d, column - d];
                }
                return product;
            }

            long ProductUpRight(int row, int column)
            {
                long product = 1;
                for (var d = 0; d < steps; d++)
                {
                    product *= matrix[row - d, column + d];
                }
                return product;
            }

            long ProductDownLeft(int row, int column)
            {
                long product = 1;
                for (var d = 0; d < steps; d++)
                {
                    product *= matrix[row + d, column - d];
                }
                return product;
            }

            long ProductDownRight(int row, int column)
            {
                long product = 1;
                for (var d = 0; d < steps; d++)
                {
                    product *= matrix[row + d, column + d];
                }
                return product;
            }

            long largestProduct = 0;
            
            for (var row = 0; row < numberOfRows; row++)
            {
                for (var column = 0; column < numberOfColumns; column++)
                {
                    long product;

                    var canGoUp = CanGoUp(row);
                    var canGoDown = CanGoDown(row);
                    var canGoLeft = CanGoLeft(column);
                    var canGoRight = CanGoRight(column);

                    if (canGoUp)
                    {
                        product = ProductUp(row, column);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }

                    if (canGoUp && canGoLeft)
                    {
                        product = ProductUpLeft(row, column);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }

                    if (canGoUp && canGoRight)
                    {
                        product = ProductUpRight(row, column);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }

                    if (canGoDown)
                    {
                        product = ProductDown(row, column);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }

                    if (canGoDown && canGoLeft)
                    {
                        product = ProductDownLeft(row, column);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }

                    if (canGoDown && canGoRight)
                    {
                        product = ProductDownRight(row, column);
                        largestProduct = largestProduct < product ? product : largestProduct;
                    }
                }
            }

            return largestProduct;
        }
    }
}
