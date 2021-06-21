using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Library
{
    public static class StreamReaderExtensions
    {
        public static IEnumerable<string> ReadWords(this StreamReader reader)
        {
            var wordBuffer = new Buffer<char>();

            foreach (var character in reader.ReadCharacters())
            {
                if (char.IsLetter(character))
                {
                    wordBuffer.Enqueue(character);
                }
                else if (wordBuffer.Count > 0)
                {
                    yield return string.Join(string.Empty, wordBuffer.Flush());
                }
            }

            if (wordBuffer.Count > 0)
            {
                yield return string.Join(string.Empty, wordBuffer.Flush());
            }
        }

        public static IEnumerable<string> ReadChunks(this StreamReader reader, char delimiter)
        {
            var wordBuffer = new Buffer<char>();

            foreach (var character in reader.ReadCharacters())
            {
                if (character == delimiter)
                {
                    yield return string.Join(string.Empty, wordBuffer.Flush());
                }
                else
                {
                    wordBuffer.Enqueue(character);
                }
            }

            if (wordBuffer.Count > 0)
            {
                yield return string.Join(string.Empty, wordBuffer.Flush());
            }
        }

        public static IEnumerable<char> ReadCharacters(this StreamReader reader)
        {
            while (true)
            {
                var character = reader.Read();
                if (character == -1)
                {
                    break;
                }

                yield return (char)character;
            }
        }

        private sealed class Buffer<T> : Queue<T>
        {
            public IEnumerable<T> Flush()
            {
                while (this.TryDequeue(out var character))
                {
                    yield return character;
                }
            }
        }
    }
}
