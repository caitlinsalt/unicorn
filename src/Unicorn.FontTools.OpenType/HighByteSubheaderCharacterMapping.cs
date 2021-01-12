using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// OpenType character mapping format 2.  This character mapping is designed for use with encodings in which some codepoints are encoded as single bytes, others
    /// as two bytes, with certain bytes being valid as the first byte of a 16-bit codepoint, but not as the only byte of an 8-bit codepoint.
    /// </summary>
    public class HighByteSubheaderCharacterMapping : CharacterMapping
    {
        private readonly int[] _highByteIndex;

        private readonly int[] _lowByteMap;

        HighByteSubheaderRecordCollection Subheaders { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">Value for the <see cref="CharacterMapping.Platform" /> property.</param>
        /// <param name="encoding">Value for the <see cref="CharacterMapping.Encoding" /> property.  Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="lang">Value for the <see cref="CharacterMapping.Language" /> property.  Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="highBytePointers">Sequence of 256 indexes into an array of <see cref="HighByteSubheaderRecord" /> values, each decribing how to map 
        /// a set of codepoints.</param>
        /// <param name="subHeaders"><see cref="HighByteSubheaderRecord" /> data describing how to map sets of codepoints, the first item applying to 
        /// single-byte codepoints.</param>
        /// <param name="lowByteMap">Codepoint-to-glyph mapping data.</param>
        public HighByteSubheaderCharacterMapping(PlatformId platform, int encoding, int lang, IEnumerable<int> highBytePointers, 
            IEnumerable<HighByteSubheaderRecord> subHeaders, IEnumerable<int> lowByteMap) 
            : base(platform, encoding, lang)
        {
            if (highBytePointers is null)
            {
                throw new ArgumentNullException(nameof(highBytePointers));
            }
            if (subHeaders is null)
            {
                throw new ArgumentNullException(nameof(subHeaders));
            }
            _highByteIndex = highBytePointers.ToArray();
            if (_highByteIndex.Length != 256)
            {
                throw new ArgumentException(Resources.HighByteSubheaderCharacterMapping_FromBytes_ArrayLengthError, nameof(highBytePointers));
            }
            Subheaders = new HighByteSubheaderRecordCollection(subHeaders);
            _lowByteMap = lowByteMap?.ToArray() ?? Array.Empty<int>();
        }

        /// <summary>
        /// Construct a <see cref="HighByteSubheaderCharacterMapping" /> object from an array of bytes.
        /// </summary>
        /// <param name="platform">The platform to which this mapping applies.</param>
        /// <param name="encoding">The encoding that this mapping is for.  Must be within the range of a <see cref="ushort"/>.</param>
        /// <param name="arr">Source data.</param>
        /// <param name="offset">Location in the source data at which the data for this subtable starts.</param>
        /// <returns>A <see cref="HighByteSubheaderCharacterMapping" /> object containing data loaded from the source array.</returns>
        public static CharacterMapping FromBytes(PlatformId platform, int encoding, byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            ushort len = arr.ToUShort(offset + 2);
            ushort lang = arr.ToUShort(offset + 4);
            int[] highByteTable = new int[256];
            for (int i = 0; i < 256; ++i)
            {
                highByteTable[i] = arr[offset + 6 + i] / 8;
            }
            int subheaderCount = highByteTable.Max() + 1;
            List<HighByteSubheaderRecord> subheaderRecords = new List<HighByteSubheaderRecord>(subheaderCount);
            for (int i = 0; i < subheaderCount; ++i)
            {
                subheaderRecords.Add(HighByteSubheaderRecord.FromBytes(arr, offset + 262 + i * 8, (subheaderCount - (i + 1)) * 8 + 2));
            }
            int lowByteTableStart = 262 + subheaderCount * 8;
            int[] lowByteTable = new int[len - lowByteTableStart];
            for (int i = lowByteTableStart; i < len; ++i)
            {
                lowByteTable[i - lowByteTableStart] = arr[i];
            }
            return new HighByteSubheaderCharacterMapping(platform, encoding, lang, highByteTable, subheaderRecords, lowByteTable);
        }

        /// <summary>
        /// Dump the content of this subtable to a <see cref="TextWriter" />.  Returns silently if the parameter is null.
        /// </summary>
        /// <param name="writer">The writer to dump output to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine($"Character mapping for {Platform} encoding {Encoding} language {Language} is a Type 2.");
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(byte codePoint)
        {
            if (_highByteIndex[codePoint] != 0)
            {
                return 0;
            }
            return MapCodePoint(Subheaders[0], codePoint);
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(int codePoint)
        {
            int highByte = (codePoint & 0xff00) >> 8;
            HighByteSubheaderRecord subheader = Subheaders[highByte];
            return MapCodePoint(subheader, (byte)(codePoint & 0xff));
        }
        
        private ushort MapCodePoint(HighByteSubheaderRecord subheader, byte lowByte)
        {
            if (lowByte < subheader.FirstByte || lowByte > subheader.LastByte)
            {
                return 0;
            }
            int mappedVal = _lowByteMap[subheader.StartIndex + (lowByte - subheader.FirstByte)];
            if (mappedVal == 0)
            {
                return 0;
            }
            return (ushort)((mappedVal + subheader.IdDelta) % 65536);
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
            return MapCodePoint((int)codePoint);
        }
    }
}
