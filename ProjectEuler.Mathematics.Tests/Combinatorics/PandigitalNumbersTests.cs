using ProjectEuler.Mathematics.Numbers;

namespace ProjectEuler.Mathematics.Tests.Combinatorics;

[TestFixture]
public class PandigitalNumbersTests
{
    [Test]
    public async Task IsPandigital_PandigitalNumbers_ReturnsTrue()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\PandigitalNumbersTests_0_9.txt");

        // ACT & ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var number), Is.True);
            Assert.That(PandigitalNumbers.IsPandigital(number), Is.True, $"{number} is not pandigital.");
        }
    }

    [Test, Explicit]
    public async Task IsPandigital_NonPandigitalNumbers_ReturnsFalse()
    {
        // ACT
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\PandigitalNumbersTests_0_9.txt");
        var enumerator = File.ReadLinesAsync(path).GetAsyncEnumerator();

        // ACT & ASSERT
        await enumerator.MoveNextAsync();
        var previous = long.Parse(enumerator.Current);
        while (await enumerator.MoveNextAsync())
        {
            var next = long.Parse(enumerator.Current);
            foreach (var number in GenerateLongRange(previous + 1, next - 1))
            {
                Assert.That(PandigitalNumbers.IsPandigital(number), Is.False, $"{number} is pandigital.");
            }

            previous = next;
        }
    }

    [Test]
    public async Task IsZeroLessPandigital_ZeroLessPandigitalNumbers_ReturnsTrue()
    {
        // ARRANGE
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\PandigitalNumbersTests_1_9.txt");

        // ACT & ASSERT
        await foreach (var line in File.ReadLinesAsync(path))
        {
            Assert.That(long.TryParse(line, out var number), Is.True);
            Assert.That(PandigitalNumbers.IsZeroLessPandigital(number), Is.True, $"{number} is not zero-less pandigital.");
        }
    }

    [Test, Explicit]
    public async Task IsZeroLessPandigital_NoneZeroLessPandigitalNumbers_ReturnsFalse()
    {
        // ACT
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assets\PandigitalNumbersTests_1_9.txt");
        var enumerator = File.ReadLinesAsync(path).GetAsyncEnumerator();

        // ACT & ASSERT
        await enumerator.MoveNextAsync();
        var previous = long.Parse(enumerator.Current);
        while (await enumerator.MoveNextAsync())
        {
            var next = long.Parse(enumerator.Current);
            foreach (var number in GenerateLongRange(previous + 1, next - 1))
            {
                Assert.That(PandigitalNumbers.IsPandigital(number), Is.False, $"{number} is pandigital.");
            }

            previous = next;
        }
    }

    private static IEnumerable<long> GenerateLongRange(long min, long max)
    {
        for (var number = min; number <= max; number++)
        {
            yield return number;
        }
    }
}