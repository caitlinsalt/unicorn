using Unicorn.CoreTypes;
using Unicorn.FontTools.OpenType;

namespace Unicorn.FontTools.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="OS2StyleProperties" /> type.
    /// </summary>
    public static class OS2StyleFlagsExtensions
    {
        /// <summary>
        /// Convert a <see cref="OS2StyleProperties" /> value to a <see cref="CoreTypes.FontProperties" /> value.
        /// </summary>
        /// <param name="flags">The flags value to convert.</param>
        /// <param name="isSymbolic">Whether or not this font is a symbolic font.  This is not specified by the <see cref="OS2StyleProperties" /> type but must be 
        /// specified in order for a <see cref="CoreTypes.FontProperties" /> value to be valid.</param>
        /// <param name="isMonospaced">Whether or not this font is monospaced.  THis is not specified by the <see cref="OS2StyleProperties" /> type.</param>
        /// <returns>A <see cref="CoreTypes.FontProperties" /> value constructed from the parameters.</returns>
        public static CoreTypes.FontProperties ToFontDescriptorFlags(this OS2StyleProperties flags, bool isSymbolic, bool isMonospaced)
        {
            CoreTypes.FontProperties output = isSymbolic ? CoreTypes.FontProperties.Symbolic : CoreTypes.FontProperties.Nonsymbolic;
            if (isMonospaced)
            {
                output |= CoreTypes.FontProperties.FixedPitch;
            }
            if (flags.HasFlag(OS2StyleProperties.Italic) || flags.HasFlag(OS2StyleProperties.Oblique))
            {
                output |= CoreTypes.FontProperties.Italic;
            }
            return output;
        }
    }
}
