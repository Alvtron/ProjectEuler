using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class MathExpressionProblem : IProblem<string[]>
    {
        private readonly int[] NUMBERS = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private const string OPERATORS = "+-";
        private const int SUM = 100;

        public string Question
        {
            get => "Given a sequence of\n" +
                "1, 2, 3, 4, 5, 6, 7, 8, and 9\n" +
                "insert addition (+) or subtraction (-) between the numbers and find all combinations that creates an expression that equals 100.";
        }

        public string[] Answer()
        {
            return Expressions(NUMBERS, OPERATORS, SUM).ToArray();
        }

        private static double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }

        private static IEnumerable<string> Expressions(int[] numbers, string operators, int sum)
        {
            if (numbers.Length < 1 || numbers.Length <= operators.Length)
            {
                throw new ArgumentException();
            }

            operators += " ";
            foreach (var operations in Permutables(operators.ToCharArray(), numbers.Length - 1))
            {
                var expressionBuilder = new StringBuilder();
                foreach (var (num, op) in Enumerable.Zip(numbers, operations))
                {
                    expressionBuilder.Append(num);
                    if (!op.Equals(' '))
                    {
                        expressionBuilder.Append(op);
                    }
                }
                expressionBuilder.Append(numbers[^1]);
                var expression = expressionBuilder.ToString();

                var total = Evaluate(expression);

                if (total == sum)
                {
                    yield return expression;
                }
            }
        }

        private static IEnumerable<string> Permutables(char[] root, int length)
        {
            // allocate an int array to hold the counts:
            int[] pos = new int[length];
            // allocate a char array to hold the current combination:
            char[] combo = new char[length];
            // initialize to the first value:
            for (int i = 0; i < length; i++)
            {
                combo[i] = root[0];
            }

            while (true)
            {
                // output the current combination:
                yield return String.Join(string.Empty, combo);

                // move on to the next combination:
                int place = length - 1;
                while (place >= 0)
                {
                    if (++pos[place] == root.Length)
                    {
                        // overflow, reset to zero
                        pos[place] = 0;
                        combo[place] = root[0];
                        place--; // and carry across to the next value
                    }
                    else
                    {
                        // no overflow, just set the char value and we're done
                        combo[place] = root[pos[place]];
                        break;
                    }
                }
                if (place < 0)
                    break;  // overflowed the last position, no more combinations
            }
        }
    }
}
