using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0021 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var sumOfAmicableNumbers = GetSumOfAmicableNumbersInRange(1, 10000);
        return Task.FromResult<Answer>(sumOfAmicableNumbers);
    }

    private static int GetSumOfAmicableNumbersInRange(int start, int end)
    {
        var numbersSums = new Dictionary<int, int>();

        for (var number = start; number < end; number++)
        {
            var divisors = GetDivisorsOf(number);
            var sum = divisors.Sum();

            numbersSums.Add(number, sum);
        }

        var total = 0;

        foreach (var (firstNumber, firstSum) in numbersSums)
        {
            // skip already processed numbers
            if (firstNumber >= firstSum)
            {
                continue;
            }

            // skip if there are no other number equal to the sum of divisors of the first number
            if (!numbersSums.TryGetValue(firstSum, out var secondSum))
            {
                continue;
            }

            // skip if sum of divisors of second number is not equal to first number
            if (secondSum != firstNumber)
            {
                continue;
            }

            total += firstSum + secondSum;
        }

        return total;
    }

    private static IEnumerable<int> GetDivisorsOf(int number)
    {
        for (var divisor = 1; divisor < number; divisor++)
        {
            if (number % divisor == 0)
            {
                yield return divisor;
            }
        }
    }
}