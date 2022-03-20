using System;
using System.Collections.Generic;
using Unicorn.Base;
using Unicorn.Images;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Streams
{
    internal static class ImageStreamFactory
    {
        internal static PdfImageStream CreateImageStream(ISourceImage sourceImage, int objectId, IEnumerable<IPdfFilterEncoder> filters = null, int generation = 0)
        {
            if (sourceImage is null)
            {
                throw new ArgumentNullException(nameof(sourceImage));
            }
            if (sourceImage is SingleColourSourceImage mockImage)
            {
                return new PdfMockImageStream(objectId, mockImage.ImageColour, filters, generation);
            }
            if (sourceImage is JpegSourceImage jpegImage)
            {
                return new PdfJpegImageStream(objectId, jpegImage, generation);
            }
            throw new NotSupportedException($"Unspoorted image type {sourceImage.GetType().Name}");
        }
    }
}
