using System;
using System.Collections.Generic;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Filters
{
    public class JpegFakeEncoder : IPdfFilterEncoder
    {
        private static readonly Lazy<PdfName> _name = new Lazy<PdfName>(() => new PdfName("DCTDecode"));
        private static readonly Lazy<JpegFakeEncoder> _encoder = new Lazy<JpegFakeEncoder>(() => new JpegFakeEncoder());

        public PdfName FilterName => _name.Value;

        public static JpegFakeEncoder Instance => _encoder.Value;

        private JpegFakeEncoder() { }

        public IEnumerable<byte> Encode(IEnumerable<byte> data) => data;
    }
}
