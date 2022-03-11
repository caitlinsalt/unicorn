using System.IO;
using System.Threading.Tasks;

namespace Unicorn.Images.Jpeg
{
    internal class JpegDataSegment
    {
        internal long StartOffset { get; }

        internal int Length { get; }   

        internal JpegDataSegmentType BlockType { get; }

        internal JpegDataSegment(long startOffset, int length, JpegDataSegmentType kind)
        {
            StartOffset = startOffset;
            Length = length;
            BlockType = kind;
        }

        internal virtual Task PopulateSegmentAsync(Stream dataStream) => Task.CompletedTask;
    }
}
