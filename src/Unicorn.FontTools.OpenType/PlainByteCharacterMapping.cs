using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// This character mapping is the OpenType cmap format 0, which is a straightforward mapping between an 8-bit codepoint and an 8-bit glyph index.
    /// It does not (really) support encoding schemes of more than 8 bits, and can only use the first 256 glyphs in a font.  Any codepoints outside the range
    /// 0-255 map to glyph 0.
    /// </summary>
    public class PlainByteCharacterMapping : CharacterMapping
    {
        private readonly ushort[] _data;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">Platform that this mapping applies to.</param>
        /// <param name="encoding">Encoding of this mapping. Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="language">Language that this mapping applies to (on some platforms). Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="data">Encoding data.</param>
        /// <exception cref="ArgumentException">Thrown if the <c>data</c> parameter is not exactly 256 elements long.</exception>
        public PlainByteCharacterMapping(PlatformId platform, int encoding, int language, IEnumerable<byte> data) : base(platform, encoding, language)
        {
            _data = data.Cast<ushort>().ToArray();
            if (_data.Length < 256)
            {
                throw new ArgumentException(Resources.PlainByteCharacterMapping_FromBytes_ArrayTooSmall, nameof(data));
            }
            if (_data.Length > 256)
            {
                throw new ArgumentException(Resources.PlainByteCharacterMapping_FromBytes_ArrayTooLarge, nameof(data));
            }
        }

        /// <summary>
        /// Construct a <see cref="PlainByteCharacterMapping" /> instance by loading it from an array of bytes.
        /// </summary>
        /// <param name="platform">Platform that this mapping applies to.</param>
        /// <param name="encoding">Encoding of this mapping. Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static CharacterMapping FromBytes(PlatformId platform, int encoding, byte[] data, int offset)
        {
            ushort lang = data.ToUShort(offset + 4);

            return new PlainByteCharacterMapping(platform, encoding, lang, data.Skip(offset + 6).Take(256));
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(byte codePoint) => _data[codePoint];

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
            if (codePoint <= byte.MaxValue)
            {
                return MapCodePoint((byte)codePoint);
            }
            return 0;
        }

        /// <summary>
        /// Dump the content of this mapping to a <see cref="TextWriter" />.
        /// </summary>
        /// <param name="writer">The writer to dump to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine($"Character mapping for {Platform} encoding {Encoding} language {Language} (type 0)");
            writer.WriteLine("   | 00 01 02 03 04 05 06 07 08 09 0a 0b 0c 0d 0e 0f");
            writer.WriteLine("---|------------------------------------------------");
            for (int i = 0; i < 256; i += 16)
            {
                writer.Write($"{i,2:x} | ");
                for (int j = 0; j < 16; ++j)
                {
                    writer.Write($"{_data[j],2:x} ");
                }
                writer.WriteLine();
            }
        }
    }
}
