using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.CoreTypes;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Utility;

namespace Unicorn.Writer.Filters
{
    /// <summary>
    /// Filter encoder for "Flate" (ZLib or RFC1951) compression.  This encoder uses the SharpZipLib package from http://icsharpcode.github.io/SharpZipLib/ to carry
    /// out the encoding.  It provides a singleton <see cref="Instance" /> which uses the highest level of compression available, but other instances using different
    /// levels of compression offered by the library can be constructed.
    /// </summary>
    public class FlateEncoder : IPdfFilterEncoder
    {
        private static readonly Lazy<PdfName> _name = new Lazy<PdfName>(() => new PdfName("FlateDecode"));

        /// <summary>
        /// The compression level used by this encoder.
        /// </summary>
        public FlateCompressionLevel CompressionLevel { get; private set; }

        /// <summary>
        /// The name of this filter, <c>/FlateDecode</c>.
        /// </summary>
        public PdfName FilterName => _name.Value;

        private static readonly Lazy<FlateEncoder> _instance = new Lazy<FlateEncoder>(() => new FlateEncoder(FlateCompressionLevel.Best));

        /// <summary>
        /// Pseudo-singleton instance.
        /// </summary>
        public static FlateEncoder Instance => _instance.Value;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="compressionLevel">The compression level to use.  The valid values are defined by the SharpZipLib library.</param>
        public FlateEncoder(FlateCompressionLevel compressionLevel)
        {
            CompressionLevel = compressionLevel;
        }

        /// <summary>
        /// Compress a sequence of bytes using the Deflate algorithm (aka zlib or RFC1951).
        /// </summary>
        /// <param name="data">The data to be compressed.</param>
        /// <returns>A byte enumeration containing the compressed data.</returns>
        public IEnumerable<byte> Encode(IEnumerable<byte> data)
        {
            byte[] outputData;
            using (EnumerableStream inputStream = new EnumerableStream(data))
            using (MemoryStream outputStream = new MemoryStream())
            using (DeflaterOutputStream flateStream = new DeflaterOutputStream(outputStream, new Deflater(CompressionLevel.ToSharpZipLibInt())))
            {
                inputStream.CopyTo(flateStream);
                flateStream.Finish();
                outputData = outputStream.ToArray();
            }

            return outputData;
        }
    }
}
