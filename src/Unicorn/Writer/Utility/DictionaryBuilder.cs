using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.Base;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Utility
{
    public static class DictionaryBuilder
    {
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
