using System.Numerics;

namespace ProjectEuler.Extensions.Collections;

public static class SpanExtensions
{
    /// <summary>
    /// Computes the sum of a span of numeric values.
    /// </summary>
    /// <typeparam name="TNumber">The type of numeric value.</typeparam>
    /// <param name="span">A span of <typeparamref name="TNumber"/> values to calculate the sum of.</param>
    /// <returns>The sum of the values in the span.</returns>
    public static TNumber Sum<TNumber>(this Span<TNumber> span)
        where TNumber : INumber<TNumber>
    {
        if (span.IsEmpty)
        {
            return TNumber.Zero;
        }

        var currentSum = span[0];
        for (var index = 1; index < span.Length; index++)
        {
            currentSum += span[index];
        }

        return currentSum;
    }

    /// <inheritdoc cref="Sum{TNumber}(Span{TNumber})"/>
    public static TNumber Sum<TNumber>(this ReadOnlySpan<TNumber> span)
        where TNumber : INumber<TNumber>
    {
        if (span.IsEmpty)
        {
            return TNumber.Zero;
        }

        var currentSum = span[0];
        for (var index = 1; index < span.Length; index++)
        {
            currentSum += span[index];
        }

        return currentSum;
    }

    /// <summary>
    /// Computes the product of a span of numeric values.
    /// </summary>
    /// <typeparam name="TNumber">The type of numeric value.</typeparam>
    /// <param name="span">A span of <typeparamref name="TNumber"/> values to calculate the product of.</param>
    /// <returns>The product of the values in the span.</returns>
    public static TNumber Product<TNumber>(this Span<TNumber> span)
        where TNumber : INumber<TNumber>
    {
        if (span.IsEmpty)
        {
            return TNumber.Zero;
        }

        var currentProduct = span[0];
        for (var index = 1; index < span.Length; index++)
        {
            currentProduct *= span[index];
        }

        return currentProduct;
    }

    /// <inheritdoc cref="Product{TNumber}(Span{TNumber})"/>
    public static TNumber Product<TNumber>(this ReadOnlySpan<TNumber> span)
        where TNumber : INumber<TNumber>
    {
        if (span.IsEmpty)
        {
            return TNumber.Zero;
        }

        var currentProduct = span[0];
        for (var index = 1; index < span.Length; index++)
        {
            currentProduct *= span[index];
        }

        return currentProduct;
    }

    /// <summary>
    /// Finds the minimum numeric value in a span.
    /// </summary>
    /// <typeparam name="T">The type of value in the span.</typeparam>
    /// <param name="span">A span of <typeparamref name="T"/> values to find the minimum of.</param>
    /// <returns>The minimum of the values in the span.</returns>
    public static T Min<T>(this Span<T> span)
        where T : IComparable<T>
    {
        ThrowIfSpanIsEmpty(span, nameof(span));

        var currentMinimum = span[0];
        for (var index = 1; index < span.Length; index++)
        {
            var nextValue = span[index];
            if (nextValue.CompareTo(currentMinimum) == -1)
            {
                currentMinimum = nextValue;
            }
        }

        return currentMinimum;
    }

    /// <inheritdoc cref="Min{TNumber}(Span{TNumber})"/>
    public static T Min<T>(this ReadOnlySpan<T> span)
        where T : IComparable<T>
    {
        ThrowIfSpanIsEmpty(span, nameof(span));

        var currentMaximum = span[0];
        for (var index = 1; index < span.Length; index++)
        {
            var nextValue = span[index];
            if (nextValue.CompareTo(currentMaximum) == -1)
            {
                currentMaximum = nextValue;
            }
        }

        return currentMaximum;
    }

    /// <summary>
    /// Finds the maximum numeric value in a span.
    /// </summary>
    /// <typeparam name="T">The type of value in the span.</typeparam>
    /// <param name="span">A span of <typeparamref name="T"/> values to find the maximum of.</param>
    /// <returns>The maximum of the values in the span.</returns>
    public static T Max<T>(this Span<T> span)
        where T : IComparable<T>
    {
        ThrowIfSpanIsEmpty(span, nameof(span));

        var currentMaximum = span[0];
        for (var index = 1; index < span.Length; index++)
        {
            var nextValue = span[index];
            if (nextValue.CompareTo(currentMaximum) == 1)
            {
                currentMaximum = nextValue;
            }
        }

        return currentMaximum;
    }

    /// <inheritdoc cref="Max{TNumber}(Span{TNumber})"/>
    public static T Max<T>(this ReadOnlySpan<T> span)
        where T : IComparable<T>
    {
        ThrowIfSpanIsEmpty(span, nameof(span));

        var currentMaximum = span[0];
        for (var index = 1; index < span.Length; index++)
        {
            var nextValue = span[index];
            if (nextValue.CompareTo(currentMaximum) == 1)
            {
                currentMaximum = nextValue;
            }
        }

        return currentMaximum;
    }

    private static void ThrowIfSpanIsEmpty<T>(Span<T> span, string paramName) where T : IComparable<T>
    {
        if (span.IsEmpty)
        {
            throw new ArgumentException("The span was empty.", paramName);
        }
    }

    private static void ThrowIfSpanIsEmpty<T>(ReadOnlySpan<T> span, string paramName) where T : IComparable<T>
    {
        if (span.IsEmpty)
        {
            throw new ArgumentException("The span was empty.", paramName);
        }
    }
}