using ProjectEuler.Mathematics.Functions;

namespace ProjectEuler.Mathematics.Tests.Functions;

[TestFixture]
public class EulerTotientFunctionTests
{
    [Test]
    public void Calculate_SmallPrime()
    {
        // Prime number: φ(7) = 6 (since all numbers less than 7 are relatively prime to 7)
        Assert.That(EulerTotientFunction.Calculate(7), Is.EqualTo(6));
    }

    [Test]
    public void Calculate_SmallComposite()
    {
        // Composite number: φ(12) = 4 (numbers relatively prime to 12: 1, 5, 7, 11)
        Assert.That(EulerTotientFunction.Calculate(12), Is.EqualTo(4));
    }

    [Test]
    public void Calculate_LargePrime()
    {
        // Prime number: φ(101) = 100
        Assert.That(EulerTotientFunction.Calculate(101), Is.EqualTo(100));
    }

    [Test]
    public void Calculate_LargeComposite()
    {
        // Composite number: φ(30) = 8 (numbers relatively prime to 30: 1, 7, 11, 13, 17, 19, 23, 29)
        Assert.That(EulerTotientFunction.Calculate(30), Is.EqualTo(8));
    }

    [Test]
    public void Calculate_NumberIsOne()
    {
        // Special case: φ(1) = 1 (1 is relatively prime to itself)
        Assert.That(EulerTotientFunction.Calculate(1), Is.EqualTo(1));
    }

    [Test]
    public void Calculate_PowerOfPrime()
    {
        // Power of prime: φ(8) = 4 (8 = 2^3, so φ(8) = 8 * (1 - 1/2) = 4)
        Assert.That(EulerTotientFunction.Calculate(8), Is.EqualTo(4));
    }

    [Test]
    public void Calculate_NumberIsTwo()
    {
        // Special case: φ(2) = 1 (since only 1 is relatively prime to 2)
        Assert.That(EulerTotientFunction.Calculate(2), Is.EqualTo(1));
    }

    [Test]
    public void Calculate_LargeCompositeWithMultiplePrimeFactors()
    {
        // Composite number with multiple prime factors: φ(100) = 40
        // Prime factors of 100: 2, 5
        // φ(100) = 100 * (1 - 1/2) * (1 - 1/5) = 40
        Assert.That(EulerTotientFunction.Calculate(100), Is.EqualTo(40));
    }

    [Test]
    public void Calculate_SquareOfPrime()
    {
        // Square of a prime number: φ(49) = 42 (since 49 = 7^2, so φ(49) = 49 * (1 - 1/7) = 42)
        Assert.That(EulerTotientFunction.Calculate(49), Is.EqualTo(42));
    }

    [Test]
    public void Calculate_LargeNumber()
    {
        // Large number to test performance and correctness
        Assert.That(EulerTotientFunction.Calculate(1000), Is.EqualTo(400));
    }

    [Test]
    public void Test_EulerTotient_ZeroInput_ThrowsException()
    {
        // Zero input should throw an exception
        Assert.That(() => EulerTotientFunction.Calculate(0), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void Test_EulerTotient_NegativeInput_ThrowsException()
    {
        // Negative input should throw an exception
        Assert.That(() => EulerTotientFunction.Calculate(-5), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }
}