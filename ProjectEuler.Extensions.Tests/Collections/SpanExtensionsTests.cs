using ProjectEuler.Extensions.Collections;

namespace ProjectEuler.Extensions.Tests.Collections;

[TestFixture]
public class SpanExtensionsTests
{
    [TestCase(new int[0], 0)]
    [TestCase(new[] { 0 }, 0)]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { -1 }, -1)]
    [TestCase(new[] { 0, 1, 2, 3 }, 6)]
    [TestCase(new[] { 0, -1, -2, -3 }, -6)]
    [TestCase(new[] { 0, 1, -2, 3 }, 2)]
    public void Sum_DifferentSpans_ReturnsCorrectSum(int[] array, int expectedSum)
    {
        // ACT
        var spanSum = new Span<int>(array).Sum();
        var readOnlySpanSum = new ReadOnlySpan<int>(array).Sum();

        // ASSERT
        Assert.Multiple(() =>
        {
            Assert.That(spanSum, Is.EqualTo(expectedSum));
            Assert.That(readOnlySpanSum, Is.EqualTo(expectedSum));
        });
    }

    [TestCase(new int[0], 0)]
    [TestCase(new[] { 0 }, 0)]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { -1 }, -1)]
    [TestCase(new[] { 1, 2, 3 }, 6)]
    [TestCase(new[] { -1, -2, -3 }, -6)]
    [TestCase(new[] { 1, -2, 3 }, -6)]
    [TestCase(new[] { 0, 1, 2, 3, 4, 5, 10000}, 0)]
    public void Product_DifferentSpans_ReturnsCorrectProduct(int[] array, int expectedSum)
    {
        // ACT
        var spanProduct = new Span<int>(array).Product();
        var readOnlySpanProduct = new ReadOnlySpan<int>(array).Product();

        // ASSERT
        Assert.Multiple(() =>
        {
            Assert.That(spanProduct, Is.EqualTo(expectedSum));
            Assert.That(readOnlySpanProduct, Is.EqualTo(expectedSum));
        });
    }

    [TestCase(new[] { 0 }, 0)]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { -1 }, -1)]
    [TestCase(new[] { 6, 2, 4, 3, 1, 7, 5}, 1)]
    [TestCase(new[] { -6, -2, -4, -3, -1, -7, -5 }, -7)]
    [TestCase(new[] { -6, 2, -4, 3, -1, 7, -5 }, -6)]
    public void Min_DifferentSpans_ReturnsCorrectMinimum(int[] array, int expectedSum)
    {
        // ACT
        var spanMin = new Span<int>(array).Min();
        var readOnlySpanMin = new ReadOnlySpan<int>(array).Min();

        // ASSERT
        Assert.Multiple(() =>
        {
            Assert.That(spanMin, Is.EqualTo(expectedSum));
            Assert.That(readOnlySpanMin, Is.EqualTo(expectedSum));
        });
    }

    [TestCase(new[] { 0 }, 0)]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { -1 }, -1)]
    [TestCase(new[] { 6, 2, 4, 3, 1, 7, 5 }, 7)]
    [TestCase(new[] { -6, -2, -4, -3, -1, -7, -5 }, -1)]
    [TestCase(new[] { -6, 2, -4, 3, -1, 7, -5 }, 7)]
    public void Max_DifferentSpans_ReturnsCorrectMaximum(int[] array, int expectedSum)
    {
        // ACT
        var spanMax = new Span<int>(array).Max();
        var readOnlySpanMax = new ReadOnlySpan<int>(array).Max();

        // ASSERT
        Assert.Multiple(() =>
        {
            Assert.That(spanMax, Is.EqualTo(expectedSum));
            Assert.That(readOnlySpanMax, Is.EqualTo(expectedSum));
        });
    }
}