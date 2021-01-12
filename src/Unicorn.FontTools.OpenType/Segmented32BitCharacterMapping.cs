using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Character mapping class for OpenType mapping types 8, 12 and 13.  Type 12 is the most common mapping for fonts supporting Unicode values greater than 0xffff;
    /// type 13 uses the same on-disk format but maps blocks of codepoints to single glyphs rather than to a range of glyphs.  The use of type 8 is "discouraged";
    /// it includes an 8k table indicating which 16-bit values are valid as the high 16 bits of a 32-bit codepoint and which are not, so that it can efficiently support 
    /// encodings that contain a stream of mixed 16-bit and 32-bit codepoints.
    /// </summary>
    public class Segmented32BitCharacterMapping : CharacterMapping
    {
        private readonly CharacterMappingFormat _version;

        private readonly SequentialMapGroupRecord[] _data;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">Platform that this mapping applies to.</param>
        /// <param name="encoding">Encoding that this mapping is for. Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="lang">Language that this mapping is for. Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="version">Table mapping version (either 8 or 12)</param>
        /// <param name="data">Mapping data.</param>
        public Segmented32BitCharacterMapping(PlatformId platform, int encoding, int lang, CharacterMappingFormat version, 
            IEnumerable<SequentialMapGroupRecord> data) 
            : base(platform, encoding, lang)
        {
            _version = version;
            if (data is null)
            {
                _data = Array.Empty<SequentialMapGroupRecord>();
            }
            else
            {
                _data = data.ToArray();
            }
        }

        /// <summary>
        /// Construct a <see cref="Segmented32BitCharacterMapping" /> instance from an array of bytes.
        /// </summary>
        /// <param name="platform">The platform that this mapping is for.</param>
        /// <param name="encoding">The encoding that this mapping applies to. Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="arr">The source data to construct the mapping from.</param>
        /// <param name="offset">The location in the source data at which the data for this mapping starts.</param>
        /// <returns></returns>
        public static Segmented32BitCharacterMapping FromBytes(PlatformId platform, int encoding, byte[] arr, int offset)
        {
            CharacterMappingFormat version = (CharacterMappingFormat)arr.ToUShort(offset);
            ushort lang = arr.ToUShort(offset + 4);
            int specificOffset = version == CharacterMappingFormat.Mixed32BitMapping ? offset + 8192 : offset;
            uint groupCount = arr.ToUInt(specificOffset + 12);
            SequentialMapGroupRecord[] data = new SequentialMapGroupRecord[groupCount];
            for (int i = 0; i < groupCount; ++i)
            {
                data[i] = new SequentialMapGroupRecord(arr.ToUInt(specificOffset + 16 + 12 * i), arr.ToUInt(specificOffset + 20 + 12 * i), 
                    (ushort)arr.ToUInt(specificOffset + 24 + 12 * i));
            }
            return new Segmented32BitCharacterMapping(platform, encoding, lang, version, data);
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
            writer.WriteLine($"Character mapping for {Platform} encoding {Encoding} language {Language} (type {_version})");
            writer.WriteLine("  Start |    End | Offset");
            writer.WriteLine("--------|--------|-------");
            foreach (SequentialMapGroupRecord group in _data)
            {
                writer.WriteLine($"{group.StartCode,7} | {group.EndCode,7} | {group.StartGlyphId,6}");
            }
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(byte codePoint) => MapCodePoint((long)codePoint);

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(int codePoint) => MapCodePoint((long)codePoint);

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(long codePoint)
        {
            SequentialMapGroupRecord group = _data.FirstOrDefault(g => g.StartCode <= codePoint && g.EndCode >= codePoint);
            if (group == default)
            {
                return 0;
            }
            if (_version == CharacterMappingFormat.ManyToOneMapping)
            {
                return group.StartGlyphId;
            }
            return (ushort)(group.StartGlyphId + (codePoint - group.StartCode));
        }
    }
}
