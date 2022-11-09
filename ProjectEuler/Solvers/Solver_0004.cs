using System;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers;

public class Solver_0004 : ISolver
{
    public Answer Solve()
    {
        return FindLargestPalindrome(3);
    }

    private static int FindLargestPalindrome(int productSize)
    {
        var largestNumber = (int)Math.Pow(10, productSize) - 1;
        var largestPalindrome = 0;

        for (var firstNumber = largestNumber; firstNumber >= 1; firstNumber--)
        {
            if (firstNumber * largestNumber < largestPalindrome)
            {
                break;
            }

            for (var secondNumber = largestNumber; secondNumber >= 1; secondNumber--)
            {
                var number = firstNumber * secondNumber;
                if (IsPalindrome(number) && largestPalindrome < number)
                {
                    largestPalindrome = number;
                }
            }
        }

        return largestPalindrome;
    }

    private static bool IsPalindrome(int number)
    {
        return number == ReverseNumber(number);
    }

    private static int ReverseNumber(int number)
    {
        var reversedNumber = 0;

        while (number > 0)
        {
            reversedNumber = reversedNumber * 10 + number % 10;
            number /= 10;
        }

        return reversedNumber;
    }
}