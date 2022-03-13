using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Base.Helpers.Extensions;

namespace Unicorn.Images.Jpeg
{
    internal static class JpegDataSegmentFactory
    {
        // Marker values for different types of JPEG "Start of frame" segments.
        private static readonly int[] START_OF_FRAME_MARKERS = { 0xc0, 0xc1, 0xc2, 0xc3, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xcb, 0xcd, 0xce, 0xcf };

        // Marker value and identification string for JFIF segments.  The marker value is the JPEG APP0 marker; the identification string is "JFIF" followed by a NUL byte.
        private const int JFIF_MARKER = 0xe0;
        private static readonly byte[] JFIF_IDENTIFICATION_STRING = { 0x4a, 0x46, 0x49, 0x46, 0 };

        // Marker value and identification string for EXIF segments.  The marker value is the JPEG APP1 marker; the identification string is "Exif" followed by two NUL bytes.
        private const int EXIF_MARKER = 0xe1;
        private static readonly byte[] EXIF_IDENTIFICATION_STRING = { 0x45, 0x78, 0x69, 0x66, 0, 0 };

        internal static async Task<JpegDataSegment> CreateSegmentAsync(Stream dataStream, long startOffset, int markerTypeByte)
        {
            const int lengthBytesOffset = 2;
            byte[] buffer = new byte[2];
            dataStream.Seek(startOffset + lengthBytesOffset, SeekOrigin.Begin);
            await dataStream.ReadAsync(buffer, 0, lengthBytesOffset).ConfigureAwait(false);
            int length = buffer.ReadBigEndianUShort() + 2;
            if (IsStartOfFrameMarker(markerTypeByte))
            {
                return await BuildPopulatableSegment(dataStream, () => new StartOfFrameSegment(startOffset, length)).ConfigureAwait(false);
            }
            if (await IsJfifSegmentAsync(dataStream, startOffset, markerTypeByte).ConfigureAwait(false))
            {
                return await BuildPopulatableSegment(dataStream, () => new JfifSegment(startOffset, length)).ConfigureAwait(false);
            }
            if (await IsExifSegmentAsync(dataStream, startOffset, markerTypeByte).ConfigureAwait(false))
            {
                return await BuildPopulatableSegment(dataStream, () => new ExifSegment(startOffset, length)).ConfigureAwait(false);
            }
            return new JpegDataSegment(startOffset, length, JpegDataSegmentType.Unknown);
        }

        private static async Task<JpegDataSegment> BuildPopulatableSegment(Stream dataStream, Func<JpegDataSegment> constructor)
        {
            JpegDataSegment segment = constructor();
            await segment.PopulateSegmentAsync(dataStream).ConfigureAwait(false);
            return segment;
        }

        private static bool IsStartOfFrameMarker(int markerByte) => START_OF_FRAME_MARKERS.Contains(markerByte);

        private static async Task<bool> IsJfifSegmentAsync(Stream dataStream, long startOffset, int marker)
            => await CheckSegmentIdentifiersAsync(dataStream, startOffset, marker, JFIF_MARKER, JFIF_IDENTIFICATION_STRING).ConfigureAwait(false);

        private static async Task<bool> IsExifSegmentAsync(Stream dataStream, long startOffset, int marker)
            => await CheckSegmentIdentifiersAsync(dataStream, startOffset, marker, EXIF_MARKER, EXIF_IDENTIFICATION_STRING).ConfigureAwait(false);

        private static async Task<bool> CheckSegmentIdentifiersAsync(Stream dataStream, long startOffset, int marker, int testMarker, byte[] testAgainst)
        {
            if (marker != testMarker)
            {
                return false;
            }
            byte[] testData = new byte[testAgainst.Length];
            dataStream.Seek(startOffset + 4, SeekOrigin.Begin);
            await dataStream.ReadAsync(testData, 0, testData.Length).ConfigureAwait(false);
            for (int i = 0; i < testData.Length; i++)
            {
                if (testData[i] != testAgainst[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
