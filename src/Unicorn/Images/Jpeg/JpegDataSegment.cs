using System.IO;
using System.Threading.Tasks;

namespace Unicorn.Images.Jpeg
{
    internal class JpegDataSegment
    {
        internal long StartOffset { get; }
        
        // Segment Length in this library is the full length of the segment, from the start
        // of the segment marker to either the next segment marker, or the first byte of a block
        // of entropy-coded data.  This is two greater than the length field stored in the segment
        // itself, as that does not include the merker.
        internal int Length { get; }   

        internal JpegDataSegmentType SegmentType { get; }

        internal JpegDataSegment(long startOffset, int length, JpegDataSegmentType kind)
        {
            StartOffset = startOffset;
            Length = length;
            SegmentType = kind;
        }

        internal virtual Task PopulateSegmentAsync(Stream dataStream) => Task.CompletedTask;
    }
}
