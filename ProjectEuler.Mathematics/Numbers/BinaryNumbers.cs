using System.Collections;

namespace ProjectEuler.Mathematics.Numbers
{
    public static class BinaryNumbers
    {
        public static IEnumerable<BitArray> Range(int length)
        {
            var maxPattern = 1 << length;
            for (var i = 1; i < maxPattern; i++)
            {
                var pattern = new BitArray(length);
                for (var j = 0; j < length; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        pattern[j] = true;
                    }
                }
                yield return pattern;
            }
        }

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
