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
        using var enumerator = PrimeNumbers.Generate().Take(200_000).GetEnumerator();

        // ACT & ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(enumerator.MoveNext(), Is.True);
            Assert.That(line, Is.EqualTo(enumerator.Current.ToString()));
        }
    }

    [Test]
    public async Task Between_0And1000000_AllArePrimes()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, TEST_FILE_PATH);
        var primeEnumerator = File.ReadLinesAsync(path).GetAsyncEnumerator();
        using var enumerator = PrimeNumbers.Between(0, 200_000).GetEnumerator();

        // ACT & ASSERT
        while (enumerator.MoveNext())
        {
            await primeEnumerator.MoveNextAsync();

            Assert.That(primeEnumerator.Current, Is.EqualTo(enumerator.Current.ToString()));
        }

        Assert.That(enumerator.MoveNext, Is.False);
    }
}