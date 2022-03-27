using System.IO;
using System.Threading.Tasks;
using Unicorn.Base.Helpers.Extensions;

namespace Unicorn.Images.Jpeg
{
    internal class JfifSegment : JpegDataSegment
    {
        internal double HorizontalDotsPerPoint { get; private set; } = 1;

        internal double VerticalDotsPerPoint { get; private set; } = 1;

        internal JfifSegment(long startOffset, int length) : base(startOffset, length, JpegDataSegmentType.Jfif) { }

        internal override async Task PopulateSegmentAsync(Stream dataStream)
        {
            const int unitsOffset = 11;
            const int bufferLength = 5;
            const int unitsByteOffset = 0;
            const int xDensityByteOffset = 1;
            const int yDensityByteOffset = 3;

            dataStream.Seek(StartOffset + unitsOffset, SeekOrigin.Begin);
            byte[] buffer = new byte[bufferLength];
            await dataStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);

            int xDensity = buffer.ReadBigEndianUShort(xDensityByteOffset);
            int yDensity = buffer.ReadBigEndianUShort(yDensityByteOffset);

            double conversionConstant = 1;
            if (buffer[unitsByteOffset] == 1) // Resolution is in dots per in.
            {
                conversionConstant = 72;
            }
            else if (buffer[0] == 2) // Resolution is in dots per cm.
            {
                conversionConstant = 28.3464567;
            }

            HorizontalDotsPerPoint = xDensity / conversionConstant;
            VerticalDotsPerPoint = yDensity / conversionConstant;
        }
    }
}
