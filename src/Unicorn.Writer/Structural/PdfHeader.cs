using System;
using System.IO;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// A singleton class representing a PDF file header.
    /// </summary>
    public class PdfHeader : IPdfWriteable
    {
        /// <summary>
        /// The singleton instance of this class.
        /// </summary>
        public static readonly PdfHeader Value = new PdfHeader();

        private PdfHeader()
        {

        }

        /// <summary>
        /// Write this header to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            byte[] contents = { 0x25, 0x50, 0x44, 0x46, 0x2d, 0x31, 0x2e, 0x34, 0xa, 0x25, 0xf0, 0x9f, 0xa6, 0x84, 0xf0, 0x9f, 0x8c, 0x88, 0xa };
            stream.Write(contents, 0, contents.Length);
            return contents.Length;
        }
    }
}
