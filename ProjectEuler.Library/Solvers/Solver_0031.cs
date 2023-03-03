using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

public class Solver_0031 : ISolver
{
    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var coins = new Coin[]
        {
            new() { Value = 1 },
            new() { Value = 2 },
            new() { Value = 5 },
            new() { Value = 10 },
            new() { Value = 20 },
            new() { Value = 50 },
            new() { Value = 100 },
            new() { Value = 200 },
        };

        var numberOfCombinations = FindCombinationsOfCoinsMatchingSum(coins, 200);

        return await Task.FromResult(numberOfCombinations);
    }

    private static int FindCombinationsOfCoinsMatchingSum(IEnumerable<Coin> coins, int targetSum)
    {
        static int FindCombinationsOfCoins(ReadOnlySpan<Coin> coins, int currentSum, int targetSum)
        {
            var numberOfCombinations = 0;

            for (var index = 0; index < coins.Length; index++)
            {
                var newSum = currentSum + coins[index].Value;
                switch (newSum.CompareTo(targetSum))
                {
                    case -1:
                        numberOfCombinations += FindCombinationsOfCoins(coins[index..], newSum, targetSum);
                        break;
                    case 0:
                        numberOfCombinations++;
                        break;
                    case +1:
                        continue;
                }
            }

            return numberOfCombinations;
        }

        var sortedUniqueCoins = coins.Distinct().OrderDescending().ToArray();
        return FindCombinationsOfCoins(sortedUniqueCoins, 0, targetSum);
    }

    private readonly record struct Coin(int Value) : IComparable<Coin>
    {
        public int CompareTo(Coin other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
