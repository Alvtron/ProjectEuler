using System.Collections;

namespace ProjectEuler.Mathematics.Numbers
{
    public static class BinaryNumbers
    {
        /// <summary>
        /// Generates all possible binary numbers of a given length.
        /// </summary>
        /// <param name="length">The length of the binary numbers.</param>
        /// <returns>A collection of binary numbers.</returns>
        public static IEnumerable<BitArray> OfLength(int length)
        {
            for (var @decimal = 0; @decimal <= Math.Pow(2, length) - 1; @decimal++)
            {
                yield return new BitArray(BitConverter.GetBytes(@decimal))
                {
                    Length = length,
                };
            }
        }

        /// <summary>
        /// Generates all possible binary numbers within a given range and length.
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="end">The end of the range.</param>
        /// <param name="length">The length of the binary numbers.</param>
        /// <returns>A collection of binary numbers.</returns>
        public static IEnumerable<BitArray> Range(long start, long end, int length)
        {
            for (var @decimal = start; @decimal <= end; @decimal++)
            {
                yield return new BitArray(BitConverter.GetBytes(@decimal))
                {
                    Length = length,
                };
            }
        }
    }
}
