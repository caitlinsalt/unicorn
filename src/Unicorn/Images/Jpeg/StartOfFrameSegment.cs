using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Unicorn.Base.Helpers.Extensions;
using Unicorn.Exceptions;

namespace Unicorn.Images.Jpeg
{
    internal class StartOfFrameSegment : JpegDataSegment
    {
        internal int DotWidth { get; private set; }

        internal int DotHeight { get; private set; }

        internal StartOfFrameSegment(long startOffset, int length) : base(startOffset, length, JpegDataSegmentType.StartOfFrame) { }

        internal override async Task PopulateSegmentAsync(Stream dataStream)
        {
            const int bufferOffset = 5;
            const int bufferLength = 4;
            const int widthOffsetInBuffer = 2;
            byte[] buffer = new byte[bufferLength];
            dataStream.Seek(StartOffset + bufferOffset, SeekOrigin.Begin);
            int bytesRead = await dataStream.ReadAsync(buffer, 0, bufferLength).ConfigureAwait(false);
            if (bytesRead < bufferLength)
            {
                throw new InvalidImageException(ImageLoadResources.JpegSourceImage_DimensionsNotFound);
            }

            DotHeight = buffer.ReadBigEndianUShort();
            DotWidth = buffer.ReadBigEndianUShort(widthOffsetInBuffer);
        }
    }
}
