using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.Base;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Utility
{
    /// <summary>
    /// Utility methods for building PDF dictionaries.
    /// </summary>
    public static class DictionaryBuilder
    {
        /// <summary>
        /// Build a font metadata dictionary by calling a font descriptor's <see cref="IFontDescriptor.GetFontMetadata"/> method.
        /// </summary>
        /// <remarks>At present the font needs to know what metadata is required in the PDF dictionary for that particular font type.  This is less than ideal.</remarks>
        /// <param name="font">The font descriptor.</param>
        /// <returns>A <see cref="PdfDictionary" /> containing the font's metadata.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is <c>null</c>.</exception>
        public static PdfDictionary MakeFontDictionary(IFontDescriptor font)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            PdfDictionary d = new PdfDictionary { { CommonPdfNames.BaseFont, new PdfName(font.BaseFontName) } };
            var fontMetadata = font.GetFontMetadata();
            if (fontMetadata != null)
            {
                foreach (var kvp in fontMetadata)
                {
                    if (kvp.Key == "BaseFont")
                    {
                        continue;
                    }
                    d.Add(ProcessKeyName(kvp.Key), ProcessValue(kvp.Value));
                }
            }
            return d;
        }

        private static IPdfPrimitiveObject ProcessValue(object value)
        {
            if (value is int i)
            {
                return new PdfInteger(i);
            }
            if (value is string s)
            {
                return new PdfName(s);
            }
            if (value is IEnumerable<double> doubleArray)
            {
                return new PdfArray(doubleArray.Select(v => new PdfReal(v)));
            }
            return new PdfName(value.GetType().Name);
        }

        private static PdfName ProcessKeyName(string key)
        {
            switch (key)
            {
                case "Subtype":
                    return CommonPdfNames.Subtype;
                default:
                    return new PdfName(key);
            }
        }
    }
}
