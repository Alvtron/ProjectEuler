using System;
using System.IO;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers;

public class Solver_0008 : ISolver
{
    private static readonly string NumberFilePath = Path.Combine(Environment.CurrentDirectory, @"Resources\problem_0008_number.txt");

    public Answer Solve()
    {
        var number = File.ReadAllText(NumberFilePath);
        return GreatestProductOfAdjacentDigits(number, 13);
    }

    private static long GreatestProductOfAdjacentDigits(string largeNumber, int numberOfDigits)
    {
        long largestProduct = 0;

        for (var i = 0; i < largeNumber.Length - numberOfDigits + 1; i++)
        {
            var currentDigits = largeNumber.Substring(i, numberOfDigits);
            long currentProduct = 1;

            foreach (var digit in currentDigits)
            {
                currentProduct *= long.Parse(digit.ToString());
            }

            if (largestProduct < currentProduct)
            {
                largestProduct = currentProduct;
            }
        }

        return largestProduct;
    }
}