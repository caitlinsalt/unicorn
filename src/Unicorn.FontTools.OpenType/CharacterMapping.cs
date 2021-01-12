using System;
using System.IO;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Class representing a mapping from character set code points to font glyph IDs.
    /// </summary>
    public abstract class CharacterMapping
    {
        /// <summary>
        /// The platform that this mapping applies to.
        /// </summary>
        public PlatformId Platform { get; }

        /// <summary>
        /// The character encoding that this mapping is for.  Must be within the range of a <see cref="ushort"/>.
        /// </summary>
        public int Encoding { get; }

        /// <summary>
        /// The language to which this mapping applies, if any.  Only relevant where the <see cref="Platform" /> property is set to <see cref="PlatformId.Macintosh" />;
        /// should be zero otherwise.  Must be within the range of a <see cref="ushort"/>.
        /// </summary>
        public int Language { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">The valeue for the <see cref="Platform" /> property.</param>
        /// <param name="encoding">The valeue for the <see cref="Encoding" /> property.  Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="lang">The valeue for the <see cref="Language" /> property.  Must be within the range of a <see cref="ushort" />.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if either the <c>encoding</c> or <c>lang</c> parameters are less than 0 or greater than 
        ///   65,535.</exception>
        protected CharacterMapping(PlatformId platform, int encoding, int lang)
        {
            FieldValidation.ValidateUShortParameter(encoding, nameof(encoding));
            FieldValidation.ValidateUShortParameter(lang, nameof(lang));
            Platform = platform;
            Encoding = encoding;
            Language = lang;
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.  The glyph ID must be within the range of a <see cref="ushort" />.</returns>
        public abstract int MapCodePoint(byte codePoint);

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.  Implementations should expect this parameter to be within the range of a <see cref="ushort" />.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.  The glyph ID must be within the range of a <see cref="ushort" />.</returns>
        public abstract int MapCodePoint(int codePoint);

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.  Implementations should expect this parameter to be within the range of a <see cref="uint" />.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.  The glyph ID must be within the range of a <see cref="ushort" />.</returns>
        public abstract int MapCodePoint(long codePoint);

        /// <summary>
        /// Dump the content of this mapping to a <see cref="TextWriter" />.
        /// </summary>
        /// <param name="writer">The writer to dump to.</param>
        public abstract void Dump(TextWriter writer);
    }
}
