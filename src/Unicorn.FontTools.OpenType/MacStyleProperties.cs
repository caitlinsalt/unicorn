using System;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Flags indicating font style.
    /// </summary>
    [Flags]
    public enum MacStyleProperties
    {
        /// <summary>
        /// Boldface font.
        /// </summary>
        Bold = 1,

        /// <summary>
        /// Italic or oblique font.
        /// </summary>
        Italic = 2,

        /// <summary>
        /// Underlined font.
        /// </summary>
        Underline = 4,

        /// <summary>
        /// Outline font.
        /// </summary>
        Outline = 8,

        /// <summary>
        /// Shadowed font.
        /// </summary>
        Shadow = 16,

        /// <summary>
        /// Condensed font.
        /// </summary>
        Condensed = 32,

        /// <summary>
        /// Extended font.
        /// </summary>
        Extended = 64,
    }
}
