using System;
using Unicorn.CoreTypes;
using Unicorn.FontTools;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    /// <summary>
    /// Extensions methods for the <see cref="IFontDescriptor" /> interface.
    /// </summary>
    public static class IFontDescriptorExtensions
    {
        private static readonly Lazy<PdfName> _type1Name = new Lazy<PdfName>(() => new PdfName("Type1"));

        /// <summary>
        /// Build a metadata dictionary for this font.
        /// </summary>
        /// <param name="descriptor">The font to build a dictionary for.</param>
        /// <returns>A <see cref="PdfDictionary" /> containing metadata about the given font.</returns>
        public static PdfDictionary MakeFontDictionary(this IFontDescriptor descriptor)
        {
            if (descriptor is null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }
            PdfDictionary d = new PdfDictionary { { CommonPdfNames.BaseFont, new PdfName(descriptor.BaseFontName) } };
            if (descriptor is PdfStandardFontDescriptor)
            {
                d.Add(CommonPdfNames.Subtype, _type1Name.Value);
            }
            else if (descriptor is OpenTypeFontDescriptor otfd)
            {
                d.AddRange(otfd.MakeFontDictionary());
            }
            return d;
        }
    }
}
