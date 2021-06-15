using System;
using System.Linq;
using Unicorn.Base;
using Unicorn.FontTools.StandardFonts;

namespace Unicorn.TextConvert
{
    public class StandardFontFinder : IFontFinder
    {
        private const string _defaultName = "Times-Roman";

        public IFontDescriptor FindFont(string name, double size)
        {
            if (string.IsNullOrEmpty(name))
            {
                return PdfStandardFontDescriptor.GetByName(_defaultName, size);
            }
            if (!PdfStandardFontDescriptor.GetSupportedFontNames().Contains(name))
            {
                return null;
            }
            return PdfStandardFontDescriptor.GetByName(name, size);
        }
    }
}
