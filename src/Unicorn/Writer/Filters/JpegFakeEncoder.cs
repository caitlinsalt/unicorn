using System;
using System.Collections.Generic;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Filters
{
    /// <summary>
    /// An "encoding" filter for marking JPEG data streams as being DCT-encoded.  As far as encoding is concerned,
    /// this is a pass-through filter whose <see cref="Encode(IEnumerable{byte})"/> method does not alter the data
    /// passed to it; it is intended to be the first filter in the filter chain for existing JPEG files.
    /// </summary>
    public class JpegFakeEncoder : IPdfFilterEncoder
    {
        private static readonly Lazy<PdfName> _name = new Lazy<PdfName>(() => new PdfName("DCTDecode"));
        private static readonly Lazy<JpegFakeEncoder> _encoder = new Lazy<JpegFakeEncoder>(() => new JpegFakeEncoder());

        /// <summary>
        /// THe name of the filter used to decode JPEG data, /DCTDecode
        /// </summary>
        public PdfName FilterName => _name.Value;

        /// <summary>
        /// Singleton instance of this encoder.
        /// </summary>
        public static JpegFakeEncoder Instance => _encoder.Value;

        private JpegFakeEncoder() { }

        /// <summary>
        /// Pass-through encoding method.
        /// </summary>
        /// <param name="data">The data to encode.</param>
        /// <returns>The data passed to the filter, unchanged.</returns>
        public IEnumerable<byte> Encode(IEnumerable<byte> data) => data;
    }
}
