using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// PDF data type for a sequence of bytes.  In the PDF spec this is technically just another way to encode a string, but it is useful considered separately
    /// as a way to store arbitrary bytes.
    /// </summary>
    public class PdfByteString : PdfSimpleObject
    {
        private readonly byte[] _data;

        /// <summary>
        /// Constructor which takes a sequence of bytes.
        /// </summary>
        /// <param name="data">The content of this object.</param>
        public PdfByteString(IEnumerable<byte> data)
        {
            if (data is null)
            {
                _data = Array.Empty<byte>();
            }
            else
            {
                _data = data.ToArray();
            }
        }

        /// <summary>
        /// Constructor which takes an array of bytes.
        /// </summary>
        /// <param name="data">The content of this object.</param>
        public PdfByteString(byte[] data)
        {
            _data = data ?? Array.Empty<byte>();
        }

        /// <summary>
        /// Format this object as an array of bytes.  It is important not to confuse the array of bytes that makes up the content of this object with the array of 
        /// bytes produced by formatting it for output!
        /// </summary>
        /// <returns>An array of bytes consisting of the content converted to hexadecimal ASCII digits, bracketed by &lt; and &gt; and followed by a space.</returns>
        protected override byte[] FormatBytes()
        {
            List<byte> output = new List<byte>(_data.Length * 2 + 2)
            {
                0x3c // "<" character.
            };
            foreach (byte b in _data)
            {
                output.AddRange(Encoding.ASCII.GetBytes($"{b:X2}"));
            }
            output.Add(0x3e); // ">" character.
            output.Add(0x20);
            return output.ToArray();
        }       
    }
}
