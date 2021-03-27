using System;
using System.Linq;
using Unicorn.FontTools;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    /// <summary>
    /// Extensions methods for the <see cref="OpenTypeFontDescriptor" /> type.
    /// </summary>
    public static class OpenTypeFontDescriptorExtensions
    {
        /// <summary>
        /// Build a metadata dictionary for this font, only containing keys that are specific to this kind of font.
        /// </summary>
        /// <param name="font">The font to generate metadata for.</param>
        /// <returns>A <see cref="PdfDictionary" /> containing font metadata.</returns>
        public static PdfDictionary MakeFontDictionary(this OpenTypeFontDescriptor font)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            PdfDictionary d = new PdfDictionary
            {
                { CommonPdfNames.Subtype, new PdfName("TrueType") },
                { new PdfName("Encoding"), new PdfName("WinAnsiEncoding") },
                { new PdfName("FirstChar"), new PdfInteger(font.FirstMappedByte()) },
                { new PdfName("LastChar"), new PdfInteger(font.LastMappedByte()) },
                { new PdfName("Widths"), new PdfArray(font.CharWidths().Select(w => new PdfReal(w))) }
            };
            return d;
        }
    }
}
