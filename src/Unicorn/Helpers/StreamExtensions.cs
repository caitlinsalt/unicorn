using System;
using System.IO;

namespace Unicorn.Helpers
{
    internal static class StreamExtensions
    {
        internal static int ReadBigEndianUShort(this Stream stream) => ReadTranslatedUShort(stream, (f, s) => (f << 8) | s);

        internal static int ReadLittleEndianUShort(this Stream stream) => ReadTranslatedUShort(stream, (f, s) => (s << 8) | f);

        private static int ReadTranslatedUShort(this Stream stream, Func<int, int, int> converter)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            int firstByte = stream.ReadByte();
            int secondByte = stream.ReadByte();
            if (secondByte == -1)
            {
                return -1;
            }
            return converter(firstByte, secondByte);
        }
    }
}
