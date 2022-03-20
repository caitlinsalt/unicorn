using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Helpers;
using Unicorn.Images;
using Unicorn.Writer.Filters;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Streams
{
    public class PdfJpegImageStream : PdfImageStream
    {
        public PdfJpegImageStream(int objectId, JpegSourceImage sourceImage, int generation = 0) : base(objectId, GetJpegFilterEncoders(), generation)
        {
            MetaDictionary.Add(CommonPdfNames.Width, new PdfInteger(sourceImage.DotWidth));
            MetaDictionary.Add(CommonPdfNames.Height, new PdfInteger(sourceImage.DotHeight));
            MetaDictionary.Add(CommonPdfNames.ColourSpace, new PdfName("DeviceRGB"));
            MetaDictionary.Add(CommonPdfNames.BitsPerComponent, new PdfInteger(8));
            InternalContents.AddRange(sourceImage.RawData);
        }

        private static IEnumerable<IPdfFilterEncoder> GetJpegFilterEncoders()
        {
            var encoders = new List<IPdfFilterEncoder>() { JpegFakeEncoder.Instance };
            if (Features.SelectedStreamFeatures.HasFlag(Features.StreamFeatures.AsciiEncodeBinaryStreams))
            {
                encoders.Add(Ascii85Encoder.Instance);
            }
            return encoders;
        }
    }
}
