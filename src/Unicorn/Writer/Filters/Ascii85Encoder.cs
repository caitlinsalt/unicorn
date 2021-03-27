using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Filters
{
    /// <summary>
    /// Filter encoder for the ASCII-85 algorithm which renders binary data as ASCII printable characters and compresses zero-byte runs slghtly.  As this class has no
    /// construction parameters and maintains no state, it enforces a singleton pattern of use.
    /// </summary>
    public class Ascii85Encoder : IPdfFilterEncoder
    {
        private static readonly Lazy<PdfName> _name = new Lazy<PdfName>(() => new PdfName("ASCII85Decode"));

        /// <summary>
        /// The name of this filter, <c>/ASCII85Decode</c>.
        /// </summary>
        public PdfName FilterName => _name.Value;

        private static readonly Lazy<Ascii85Encoder> _encoder = new Lazy<Ascii85Encoder>(() => new Ascii85Encoder());

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static Ascii85Encoder Instance => _encoder.Value;

        private Ascii85Encoder()
        {
        }

        /// <summary>
        /// Encode a sequence of bytes using the ASCII 85 algorithm, which converts blocks of four bytes into blocks of five printable ASCII characters, with zero-byte
        /// blocks being compressed into a single character.
        /// </summary>
        /// <param name="data">The sequence of bytes to be encoded.</param>
        /// <returns>The encoded data.</returns>
        public IEnumerable<byte> Encode(IEnumerable<byte> data)
        {
            if (data is null)
            {
                return null;
            }
            List<byte> output = new List<byte>();
            IEnumerator<byte> enumerator = data.GetEnumerator();
            bool noMoreData = false;
            while (true)
            {
                List<byte> group = new List<byte>(4);
                for (int i = 0; i < 4; ++i)
                {
                    if (!(enumerator.MoveNext()))
                    {
                        noMoreData = true;
                        break;
                    }
                    group.Add(enumerator.Current);
                }
                EncodeGroup(group.ToArray(), output);
                if (noMoreData)
                {
                    output.AddRange(trailer);
                    return output;
                }
            }
        }

        private static readonly uint[] powers = new[] { 52_200_625U, 614_125U, 7_225U, 85U, 1U };

        // End-of-data marker.
        private static readonly byte[] trailer = new byte[] { 0x7e, 0x3e };

        private static void EncodeGroup(byte[] data, List<byte> outputTarget)
        {
            // Entire groups of four zero bytes compress to a single "z" byte.
            if (data.Length == 4 && data.All(b => b == 0))
            {
                outputTarget.Add(0x7a);
                return;
            }
            byte[] d;
            if (data.Length == 4)
            {
                d = data;
            }
            else
            {
                d = new byte[4];
                data.CopyTo(d, 0);
            }
            uint iv = ((uint)d[0] << 24) | ((uint)d[1] << 16) | ((uint)d[2] << 8) | d[3];
            for (int i = 0; i < data.Length + 1; ++i)
            {
                uint cb = iv / powers[i];
                outputTarget.Add((byte)(cb + 33));
                iv -= cb * powers[i];
            }
        }
    }
}
