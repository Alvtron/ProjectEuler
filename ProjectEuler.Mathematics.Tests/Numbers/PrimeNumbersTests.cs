using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Numbers;

[TestFixture]
public class PrimeNumbersTests
{
    private const string TEST_FILE_PATH = @"Assets\PrimeNumbersTests_200_000_primes.txt";

    [Test]
    public async Task IsPrime_200000Primes_ReturnsTrue()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);

        // ACT & ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var primeNumber), Is.True);
            Assert.That(PrimeNumbers.IsPrime(primeNumber), Is.True, $"{primeNumber} is not a prime.");
        }
    }

    [Test]
    public async Task Generate_200000_AllArePrimes()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        var actualPrimes = await File.ReadAllLinesAsync(path);
        var generatedPrimes = PrimeNumbers.Generate().Take(200_000);

        // ACT & ASSERT
        foreach (var (generated, actual) in generatedPrimes.Zip(actualPrimes))
        {
            Assert.That(generated.ToString(), Is.EqualTo(actual));
        }
    }

    [Test]
    public async Task Between_0And200000_AllArePrimes()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        var actualPrimes = await File.ReadAllLinesAsync(path);
        var generatedPrimes = PrimeNumbers.Between(0, 200_000);

        // ACT & ASSERT
        foreach (var (generated, actual) in generatedPrimes.Zip(actualPrimes))
        {
            Assert.That(generated.ToString(), Is.EqualTo(actual));
        }
    }

    [Test]
    public async Task Between_200000And0_AllArePrimes()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        var actualPrimes = await File.ReadAllLinesAsync(path);
        Array.Reverse(actualPrimes);

        var generatedPrimes = PrimeNumbers.Between(200_000, 0);

        // ACT & ASSERT
        foreach (var (generated, actual) in generatedPrimes.Zip(actualPrimes))
        {
            Assert.That(generated.ToString(), Is.EqualTo(actual));
        }
    }
}