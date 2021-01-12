using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.FontTools.OpenType.Extensions;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// This character mapping is OpenType cmap format 6, which maps a contiguous range of 16-bit codepoints to glyphs and returns 0 for any codepoint outside that
    /// contiguous range.  The <see cref="FirstCodePoint" /> and <see cref="LastCodePoint" /> properties describe the range that is mapped.
    /// </summary>
    public class TrimmedTableCharacterMapping : CharacterMapping
    {
        /// <summary>
        /// The lowest code point supported by this mapping.  Will be within the range of a <see cref="ushort" />.
        /// </summary>
        public int FirstCodePoint { get; }

        /// <summary>
        /// The highest code point supported by this mapping.  Will be within the range of a <see cref="ushort" />.
        /// </summary>
        public int LastCodePoint => (ushort)(FirstCodePoint + _arr.Length - 1);

        private readonly ushort[] _arr;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">The platform that this mapping applies to.</param>
        /// <param name="encoding">The encoding of this mapping.</param>
        /// <param name="language">The language (if any) that this mapping applies to.</param>
        /// <param name="firstCodePoint">The lowest code point that is mapped.</param>
        /// <param name="data">The array of glyph IDs that this mapping maps to.</param>
        public TrimmedTableCharacterMapping(PlatformId platform, int encoding, int language, int firstCodePoint, IEnumerable<int> data)
            : base(platform, encoding, language)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            FieldValidation.ValidateUShortParameter(firstCodePoint, nameof(firstCodePoint));
            FirstCodePoint = firstCodePoint;
            _arr = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(data, nameof(data));
            if (_arr.Length == 0)
            {
                throw new InvalidOperationException(Resources.TrimmedTableCharacterMapping_FromBytes_ArrayEmpty);
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">The platform that this mapping applies to.</param>
        /// <param name="encoding">The encoding of this mapping.</param>
        /// <param name="language">The language (if any) that this mapping applies to.</param>
        /// <param name="firstCodePoint">The lowest code point that is mapped.</param>
        /// <param name="data">The array of glyph IDs that this mapping maps to.</param>
        private TrimmedTableCharacterMapping(PlatformId platform, int encoding, int language, ushort firstCodePoint, IEnumerable<ushort> data) 
            : base(platform, encoding, language)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            FirstCodePoint = firstCodePoint;
            _arr = data.ToArray();
            if (_arr.Length == 0)
            {
                throw new InvalidOperationException(Resources.TrimmedTableCharacterMapping_FromBytes_ArrayEmpty);
            }
        }

        /// <summary>
        /// Construct a <see cref="TrimmedTableCharacterMapping" /> instance from an array of bytes.
        /// </summary>
        /// <param name="platform">The platform that this mapping applies to.</param>
        /// <param name="encoding">The encoding of this mapping. Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="arr">The source data.</param>
        /// <param name="offset">The starting location of the character mapping data. in the source data array.</param>
        /// <returns>A <see cref="TrimmedTableCharacterMapping" /> instance containing the data loaded from the array.</returns>
        public static CharacterMapping FromBytes(PlatformId platform, int encoding, byte[] arr, int offset)
        {
            ushort lang = arr.ToUShort(offset + 4);
            ushort fcp = arr.ToUShort(offset + 6);
            int count = arr.ToUShort(offset + 8);
            ushort[] data = new ushort[count];
            for (int i = 0; i < count; ++i)
            {
                data[i] = arr.ToUShort(offset + 10 + 2 * i);
            }
            return new TrimmedTableCharacterMapping(platform, encoding, lang, fcp, data);
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(byte codePoint) =>  MapCodePoint((int)codePoint);

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(int codePoint)
        {
            if (codePoint < FirstCodePoint)
            {
                return 0;
            }
            if (codePoint >= FirstCodePoint + _arr.Length)
            {
                return 0;
            }
            return _arr[codePoint - FirstCodePoint];
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override int MapCodePoint(long codePoint)
        {
            if (codePoint < FirstCodePoint + _arr.Length)
            {
                return MapCodePoint((int)codePoint);
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
            writer.WriteLine($"Character mapping for {Platform} encoding {Encoding} language {Language} (type 6)");
            writer.WriteLine("Code point | Glyph");
            writer.WriteLine("-----------|------");
            for (int i = 0; i < _arr.Length; ++i)
            {
                writer.WriteLine($"     {i + FirstCodePoint,5} | {_arr[i],5}");
            }
        }
    }
}
