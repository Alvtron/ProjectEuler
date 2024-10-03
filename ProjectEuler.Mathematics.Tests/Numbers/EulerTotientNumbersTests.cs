using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class EulerTotientNumbersTests
{
    [Test]
    public void Generate_WithRangeNegative_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        long limit = -10;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => EulerTotientNumbers.Generate(limit));
    }

    [Test]
    public void Generate_WithRangeZero_ThrowsException()
    {
        // Arrange
        var limit = 0;

        // Act & Assert
        Assert.That(() => EulerTotientNumbers.Generate(limit), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void Generate_WithRangeOne_ReturnsOne()
    {
        // Arrange
        var limit = 1;

        // Act
        var result = EulerTotientNumbers.Generate(limit);

        // Assert
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(1)); // φ(1) = 1
    }

    [Test]
    public void Generate_WithRangeTwo_ReturnsCorrectValues()
    {
        // Arrange
        var limit = 2;

        // Act
        var result = EulerTotientNumbers.Generate(limit);

        // Assert
        Assert.That(result.Count, Is.EqualTo(limit));
        Assert.That(result[0], Is.EqualTo(1)); // φ(1) = 1
        Assert.That(result[1], Is.EqualTo(1)); // φ(2) = 1
    }

    [Test]
    public void Generate_WithRangeFive_ReturnsCorrectValues()
    {
        // Arrange
        var limit = 5;

        // Act
        var result = EulerTotientNumbers.Generate(limit);

        // Assert
        Assert.That(result.Count, Is.EqualTo(limit));
        Assert.That(result[0], Is.EqualTo(1)); // φ(1) = 1
        Assert.That(result[1], Is.EqualTo(1)); // φ(2) = 1
        Assert.That(result[2], Is.EqualTo(2)); // φ(3) = 2
        Assert.That(result[3], Is.EqualTo(2)); // φ(4) = 2
        Assert.That(result[4], Is.EqualTo(4)); // φ(5) = 4
    }

    [Test]
    public void Generate_WithRangeTen_ReturnsCorrectValues()
    {
        // Arrange
        var limit = 10;

        // Act
        var result = EulerTotientNumbers.Generate(limit);

        // Assert
        Assert.That(result.Count, Is.EqualTo(limit));
        Assert.That(result[0], Is.EqualTo(1)); // φ(1) = 1
        Assert.That(result[1], Is.EqualTo(1)); // φ(2) = 1
        Assert.That(result[2], Is.EqualTo(2)); // φ(3) = 2
        Assert.That(result[3], Is.EqualTo(2)); // φ(4) = 2
        Assert.That(result[4], Is.EqualTo(4)); // φ(5) = 4
        Assert.That(result[5], Is.EqualTo(2)); // φ(6) = 2
        Assert.That(result[6], Is.EqualTo(6)); // φ(7) = 6
        Assert.That(result[7], Is.EqualTo(4)); // φ(8) = 4
        Assert.That(result[8], Is.EqualTo(6)); // φ(9) = 6
        Assert.That(result[9], Is.EqualTo(4)); // φ(10) = 4
    }

    [Test]
    public void Generate_WithRangeTwenty_ReturnsCorrectValues()
    {
        // Arrange
        var limit = 20;

        // Act
        var result = EulerTotientNumbers.Generate(limit);

        // Assert
        Assert.That(result.Count, Is.EqualTo(20));
        Assert.That(result[0], Is.EqualTo(1)); // φ(1) = 1
        Assert.That(result[1], Is.EqualTo(1)); // φ(2) = 1
        Assert.That(result[2], Is.EqualTo(2)); // φ(3) = 2
        Assert.That(result[3], Is.EqualTo(2)); // φ(4) = 2
        Assert.That(result[4], Is.EqualTo(4)); // φ(5) = 4
        Assert.That(result[5], Is.EqualTo(2)); // φ(6) = 2
        Assert.That(result[6], Is.EqualTo(6)); // φ(7) = 6
        Assert.That(result[7], Is.EqualTo(4)); // φ(8) = 4
        Assert.That(result[8], Is.EqualTo(6)); // φ(9) = 6
        Assert.That(result[9], Is.EqualTo(4)); // φ(10) = 4
        Assert.That(result[10], Is.EqualTo(10)); // φ(11) = 10
        Assert.That(result[11], Is.EqualTo(4)); // φ(12) = 4
        Assert.That(result[12], Is.EqualTo(12)); // φ(13) = 12
        Assert.That(result[13], Is.EqualTo(6)); // φ(14) = 6
        Assert.That(result[14], Is.EqualTo(8)); // φ(15) = 8
        Assert.That(result[15], Is.EqualTo(8)); // φ(16) = 8
        Assert.That(result[16], Is.EqualTo(16)); // φ(17) = 16
        Assert.That(result[17], Is.EqualTo(6)); // φ(18) = 6
        Assert.That(result[18], Is.EqualTo(18)); // φ(19) = 18
        Assert.That(result[19], Is.EqualTo(8)); // φ(20) = 8
    }

    [Test]
    public void Generate_WithRangeHundred_ReturnsCorrectCount()
    {
        // Arrange
        var limit = 100;

        // Act
        var result = EulerTotientNumbers.Generate(limit);

        // Assert
        Assert.That(result.Count, Is.EqualTo(limit));
        Assert.That(result[0], Is.EqualTo(1));    // φ(1) = 1
        Assert.That(result[limit - 1], Is.EqualTo(40));   // φ(100) = 40
    }

    [Test]
    public void Generate_WithRangeThousand_ReturnsExpectedValues()
    {
        // Arrange
        var limit = 1_000;

        // Act
        var result = EulerTotientNumbers.Generate(limit);

        // Assert
        Assert.That(result.Count, Is.EqualTo(limit));
        Assert.That(result[0], Is.EqualTo(1));    // φ(1) = 1
        Assert.That(result[limit - 1], Is.EqualTo(400));   // φ(1_000) = 400
    }

    [Test]
    public void Generate_WithRangeHundredThousand_ReturnsCorrectValues()
    {
        // Arrange
        var limit = 100_000;

        // Act
        var result = EulerTotientNumbers.Generate(limit);

        // Assert
        Assert.That(result.Count, Is.EqualTo(limit));
        Assert.That(result[0], Is.EqualTo(1));    // φ(1) = 1
        Assert.That(result[limit - 1], Is.EqualTo(40000));   // φ(100_000) = 40000
    }

    [Test]
    public void Generate_WithRangeMillion_ReturnsCorrectCount()
    {
        // Arrange
        var limit = 1_000_000;

        // Act
        var result = EulerTotientNumbers.Generate(limit);

        // Assert
        Assert.That(result.Count, Is.EqualTo(limit));
        Assert.That(result[0], Is.EqualTo(1));    // φ(1) = 1
        Assert.That(result[limit - 1], Is.EqualTo(400000));   // φ(1_000_000) = 400000
    }

    [Test]
    public void Generate_WithRangeTenMillion_ReturnsCorrectCount()
    {
        // Arrange
        var limit = 10_000_000;

        // Act
        var result = EulerTotientNumbers.Generate(limit);

        // Assert
        Assert.That(result.Count, Is.EqualTo(limit));
        Assert.That(result[0], Is.EqualTo(1));    // φ(1) = 1
        Assert.That(result[limit - 1], Is.EqualTo(4000000));   // φ(10_000_000) = 4000000
    }
}