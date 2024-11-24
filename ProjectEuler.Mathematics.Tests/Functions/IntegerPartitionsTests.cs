using System.Numerics;
using ProjectEuler.Mathematics.Functions;

namespace ProjectEuler.Mathematics.Tests.Functions;

[TestFixture]
public class IntegerPartitionsTests
{
    // The integer partitions of 0 to 49 (50 partitions, see https://oeis.org/A000041)
    private readonly int[] A000041 =
    [
        1, 1, 2, 3, 5, 7, 11, 15, 22, 30, 42, 56, 77, 101, 135, 176, 231, 297, 385, 490, 627, 792, 1002, 1255, 1575,
        1958, 2436, 3010, 3718, 4565, 5604, 6842, 8349, 10143, 12310, 14883, 17977, 21637, 26015, 31185, 37338, 44583,
        53174, 63261, 75175, 89134, 105558, 124754, 147273, 173525,
    ];

    [Test]
    public void NumberOfPartitionsOf_GivenNegativeNumber_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var integerPartitions = new IntegerPartitions();
        const int NUMBER = -1;

        // Act & Assert
        Assert.That(() => integerPartitions.NumberOfPartitionsOf(NUMBER), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void NumberOfPartitionsOf_GivenZero_ReturnsOne()
    {
        // Arrange
        var integerPartitions = new IntegerPartitions();
        const int NUMBER = 0;

        // Act
        var result = integerPartitions.NumberOfPartitionsOf(NUMBER);

        // Assert
        Assert.That(result, Is.EqualTo(BigInteger.One), "The number of partitions for 0 should be 1.");
    }

    [Test]
    public void NumberOfPartitionsOf_GivenSmallNumber_ReturnsExpectedValue()
    {
        // Arrange
        var integerPartitions = new IntegerPartitions();
        const int NUMBER = 5;

        // Act
        var result = integerPartitions.NumberOfPartitionsOf(NUMBER);

        // Assert
        Assert.That(result, Is.EqualTo(new BigInteger(7)));
    }

    [Test]
    public void NumberOfPartitionsOf_GivenBigNumber_ReturnsExpectedValue()
    {
        // Arrange
        var integerPartitions = new IntegerPartitions();
        const int NUMBER = 100_000;

        // Act
        var result = integerPartitions.NumberOfPartitionsOf(NUMBER);

        // Assert
        Assert.That(result, Is.EqualTo(BigInteger.Parse("27493510569775696512677516320986352688173429315980054758203125984302147328114964173055050741660736621590157844774296248940493063070200461792764493033510116079342457190155718943509725312466108452006369558934464248716828789832182345009262853831404597021307130674510624419227311238999702284408609370935531629697851569569892196108480158600569421098519")));
    }

    [Test]
    public void EnumerateNumberOfPartitions_FirstFifty_IsCorrect()
    {
        // Arrange
        var integerPartitions = new IntegerPartitions();
        const int COUNT = 50; // Test up to 100 numbers

        // Act
        var results = integerPartitions.EnumerateNumberOfPartitions().Take(COUNT).Select(b => (int)b).ToList();

        // Assert
        Assert.That(results, Is.EqualTo(this.A000041));
    }
}