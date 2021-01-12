using System;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// Font descriptor flags, with values taken from the PDF specification.
    /// </summary>
    [Flags]
    public enum FontProperties
    {
        /// <summary>
        /// Monospaced font.
        /// </summary>
        FixedPitch = 1,

        /// <summary>
        /// Serif font.
        /// </summary>
        Serif = 2,

        /// <summary>
        /// Symbol font that does not use the Adobe Latin character set.  A valid <see cref="IFontDescriptor.Flags" /> property must have either this or the 
        /// <see cref="Nonsymbolic" /> flag set, and not both.
        /// </summary>
        Symbolic = 4,

        /// <summary>
        /// Script font (ie, imitates handwriting).
        /// </summary>
        Script = 8,

        /// <summary>
        /// Uses the Adobe Latin character set or a subset of it.  A valid <see cref="IFontDescriptor.Flags" /> property must have either this or the 
        /// <see cref="Symbolic" /> flag set, and not both.
        /// </summary>
        Nonsymbolic = 0x20,

        /// <summary>
        /// Italic or slanted font.
        /// </summary>
        Italic = 0x40,

        /// <summary>
        /// Font does not include lowercase (typically used for display fonts).
        /// </summary>
        AllCap = 0x10000,

        /// <summary>
        /// The lowercase glyphs in the font are smaller forms of the uppercase glyphs, not true miniscule forms.
        /// </summary>
        SmallCap = 0x20000,

        /// <summary>
        /// Always thicken glyphs when the font is bolded, even when rendered at small resolutions where rounding would normally result in regular and bold glyphs
        /// having the same weight.
        /// </summary>
        ForceBold = 0x40000,
    }
}
