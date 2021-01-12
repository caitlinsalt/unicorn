using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.FontTools.OpenType.Extensions;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// OpenType character mapping type 4, which is one of the most common, at least for fonts in the BMP range.  It is logically similar to type 2, but has a very 
    /// different disk layout.  The supported codepoint ranges are mapped either by specifying an offset from codepoint to glyph ID for the range, or by specifying
    /// an offset into a table that maps code points to base glyph values to which a second offset is then added.
    /// </summary>
    public class SegmentedCharacterMapping : CharacterMapping
    {
        private SegmentSubheaderRecordCollection Segments { get; }

        private readonly ushort[] _glyphData;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">The platform that this mapping is for.</param>
        /// <param name="encoding">The encoding that this mapping is for. Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="lang">The language that this mapping is for (if applicable). Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="segments">The codepoint range segments that make up this mapping.</param>
        /// <param name="glyphData">The glyph mapping data table.</param>
        public SegmentedCharacterMapping(PlatformId platform, int encoding, int lang, IEnumerable<SegmentSubheaderRecord> segments, IEnumerable<int> glyphData)
            : base(platform, encoding, lang)
        {
            Segments = new SegmentSubheaderRecordCollection(segments);
            if (glyphData is null)
            {
                _glyphData = Array.Empty<ushort>();
            }
            else
            {
                _glyphData = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(glyphData, nameof(glyphData));
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">The platform that this mapping is for.</param>
        /// <param name="encoding">The encoding that this mapping is for.</param>
        /// <param name="lang">The language that this mapping is for (if applicable).</param>
        /// <param name="segments">The codepoint range segments that make up this mapping.</param>
        /// <param name="glyphData">The glyph mapping data table.</param>
        private SegmentedCharacterMapping(PlatformId platform, int encoding, int lang, IEnumerable<SegmentSubheaderRecord> segments, IEnumerable<ushort> glyphData) 
            : base(platform, encoding, lang)
        {
            Segments = new SegmentSubheaderRecordCollection(segments);
            if (glyphData is null)
            {
                _glyphData = Array.Empty<ushort>();
            }
            else
            {
                _glyphData = glyphData.ToArray();
            }
        }

        /// <summary>
        /// Construct a <see cref="SegmentedCharacterMapping" /> instance from an array of bytes.
        /// </summary>
        /// <param name="platform">The platform that this mapping applies to.</param>
        /// <param name="encoding">The encoding this mapping is for. Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="arr">Source data for the mapping.</param>
        /// <param name="offset">The location in the source data at which the mapping data starts.</param>
        /// <returns></returns>
        public static SegmentedCharacterMapping FromBytes(PlatformId platform, int encoding, byte[] arr, int offset)
        {
            ushort len = arr.ToUShort(offset + 2);
            ushort lang = arr.ToUShort(offset + 4);
            int segCount = arr.ToUShort(offset + 6) / 2;
            List<SegmentSubheaderRecord> segments = new List<SegmentSubheaderRecord>(segCount);
            for (int i = 0; i < segCount; ++i)
            {
                int glyphIdxOffset = arr.ToUShort(offset + 16 + 6 * segCount + 2 * i);
                if (glyphIdxOffset != 0)
                {
                    glyphIdxOffset = (glyphIdxOffset / 2) - (segCount - i);
                }
                else
                {
                    glyphIdxOffset = -1;
                }
                segments.Add(new SegmentSubheaderRecord(arr.ToUShort(offset + 16 + 2 * segCount + 2 * i), arr.ToUShort(offset + 14 + 2 * i),
                    arr.ToShort(offset + 16 + 4 * segCount + 2 * i), glyphIdxOffset));
            }
            int glyphCount = (len - (16 + 8 * segCount)) / 2;
            List<ushort> glyphData = new List<ushort>(glyphCount);
            for (int i = 0; i < glyphCount; ++i)
            {
                glyphData.Add(arr.ToUShort(offset + 16 + 8 * segCount + 2 * i));
            }
            return new SegmentedCharacterMapping(platform, encoding, lang, segments, glyphData);
        }

        /// <summary>
        /// Dump the content of this subtable to a <see cref="TextWriter" />.  Returns silently if the parameter is null.  At present this only dumps the segment table,
        /// not the glyph mapping table.
        /// </summary>
        /// <param name="writer">The writer to dump output to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine($"Character mapping for {Platform} encoding {Encoding} language {Language} (type 4)");
            writer.WriteLine($"There are {Segments.Count} segments.");
            writer.WriteLine($"Segment | Start |   End |  Delta | Offset");
            writer.WriteLine($"--------|-------|-------|--------|-------");
            for (int i = 0; i < Segments.Count; ++i)
            {
                writer.WriteLine($"  {i,5} | {Segments[i].StartCode,5} | {Segments[i].EndCode,5} | {Segments[i].IdDelta,6} | {Segments[i].StartOffset,6}");
            }
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(byte codePoint) => MapCodePoint((int)codePoint);

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert. Must be within the range of a <see cref="ushort" />.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <c>codePoint</c> parameter is outside the range of a <see cref="ushort" />.</exception>
        public override int MapCodePoint(int codePoint)
        {
            FieldValidation.ValidateUShortParameter(codePoint, nameof(codePoint));
            SegmentSubheaderRecord segment = Segments.FirstOrDefault(s => s.EndCode >= codePoint && s.StartCode <= codePoint);
            if (segment == default)
            {
                return 0;
            }
            ushort glyphVal;
            if (segment.StartOffset == -1)
            {
                glyphVal = (ushort)codePoint;
            }
            else
            {
                glyphVal = _glyphData[segment.StartOffset + (codePoint - segment.StartCode)];
                if (glyphVal == 0)
                {
                    return 0;
                }
            }
            return (ushort)((glyphVal + segment.IdDelta) % 65536);
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(long codePoint)
        {
            if (codePoint > ushort.MaxValue)
            {
                return 0;
            }
            return MapCodePoint((ushort)codePoint);
        }
    }
}
