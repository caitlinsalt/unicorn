using System;
using System.Collections.Generic;
using Unicorn.Helpers;
using Unicorn.Images;
using Unicorn.Images.Jpeg;
using Unicorn.Writer.Filters;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Streams
{

#pragma warning disable CA1711 // Identifiers should not have incorrect suffix.  This is a stream in the PDF sense if not in the .NET sense.

    /// <summary>
    /// A data stream containing a JPEG image.
    /// </summary>
    public class PdfJpegImageStream : PdfImageStream
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
    {
        /// <summary>
        /// Construct an image stream from a source image.
        /// </summary>
        /// <param name="objectId">The ID of the stream.</param>
        /// <param name="sourceImage">The image that the stream shiuld contain.</param>
        /// <param name="generation">The object generation number (usually 0).</param>
        public PdfJpegImageStream(int objectId, JpegSourceImage sourceImage, int generation = 0) : 
            base(objectId, GetJpegFilterEncoders(sourceImage?.EncodingMode), generation)
        {
            if (sourceImage is null)
            {
                throw new ArgumentNullException(nameof(sourceImage));
            }
            MetaDictionary.Add(CommonPdfNames.Width, new PdfInteger(sourceImage.RawDotWidth));
            MetaDictionary.Add(CommonPdfNames.Height, new PdfInteger(sourceImage.RawDotHeight));
            MetaDictionary.Add(CommonPdfNames.ColourSpace, new PdfName("DeviceRGB"));
            MetaDictionary.Add(CommonPdfNames.BitsPerComponent, new PdfInteger(8));
            InternalContents.AddRange(sourceImage.RawData);
        }

        private static IEnumerable<IPdfFilterEncoder> GetJpegFilterEncoders(JpegEncodingMode? encodingMode)
        {
            var encoders = new List<IPdfFilterEncoder>() { JpegFakeEncoder.Instance };
            if (encodingMode != JpegEncodingMode.Progressive && Features.SelectedStreamFeatures.HasFlag(Features.StreamFeatures.AsciiEncodeBinaryStreams))
            {
                encoders.Add(Ascii85Encoder.Instance);
            }
            return encoders;
        }
    }
}
