using System.Numerics;

namespace ProjectEuler.Mathematics.Functions;

/// <summary>
/// A class containing methods for calculating the number of ways to partition an integer.
/// </summary>
public class IntegerPartitions
{
    private readonly Dictionary<int, BigInteger> partitionCounts = new()
    {
        [0] = 1, // 1 way to partition 0.
    };

    private int highestPartitionedNumber;

    /// <summary>
    /// Returns the number of ways to partition the specified number.
    /// </summary>
    /// <param name="number">The number to partition.</param>
    /// <returns>The number of ways to partition the specified number.</returns>
    public BigInteger NumberOfPartitionsOf(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(number);

        if (number <= highestPartitionedNumber)
        {
            return this.partitionCounts[number];
        }

        for (var n = highestPartitionedNumber + 1; n <= number; n++)
        {
            partitionCounts[n] = this.CalculatePartitionsFor(n);
            highestPartitionedNumber = n;
        }

        return partitionCounts[number];
    }

    /// <summary>
    /// Enumerates the number of ways to partition each integer.
    /// </summary>
    public IEnumerable<BigInteger> EnumerateNumberOfPartitions()
    {
        for (var n = 0; n < int.MaxValue; n++)
        {
            if (this.partitionCounts.TryGetValue(n, out var cachedPartitions))
            {
                yield return cachedPartitions;
                continue;
            }

            var partitions = this.CalculatePartitionsFor(n);
            
            partitionCounts[n] = partitions;
            highestPartitionedNumber = n;
            
            yield return partitions;
        }
    }

    private BigInteger CalculatePartitionsFor(int n)
    {
        var sum = BigInteger.Zero;
        var k = 1;

        while (true)
        {
            var pentagonal1 = n - PentagonalNumber(k);
            var pentagonal2 = n - PentagonalNumber(-k);

            if (pentagonal1 < 0) break;

            sum += Sign(k) * this.partitionCounts[pentagonal1];

            if (pentagonal2 >= 0)
            {
                sum += Sign(k) * this.partitionCounts[pentagonal2];
            }

            k++;
        }

        return sum;
    }

    private static int PentagonalNumber(int k)
    {
        return k * (3 * k - 1) / 2;
    }

    private static int Sign(int k)
    {
        return k % 2 == 0 ? -1 : 1;
    }
}