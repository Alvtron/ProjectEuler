using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers;

public class Solver_0013 : ISolver
{
    private static readonly string NumbersFilePath = Path.Combine(Environment.CurrentDirectory, @"Resources\problem_0013_numbers.txt");

    public Answer Solve()
    {
        var numbersString = File.ReadAllText(NumbersFilePath);
        var numbers = GetNumbersFromString(numbersString);
        var sum = GetSumOf(numbers);

        return GetFirstDigitsOf(sum, 10);
    }

    private static IEnumerable<BigInteger> GetNumbersFromString(string numbers)
    {
        return numbers.Split(Environment.NewLine).Select(BigInteger.Parse);
    }

    private static BigInteger GetSumOf(IEnumerable<BigInteger> numbers)
    {
        var sum = new BigInteger();

        foreach (var number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    private static long GetFirstDigitsOf(BigInteger number, int count)
    {
        var firstNumbers = number.ToString().Substring(0, count);
        return long.Parse(firstNumbers);
    }
}