using System;
using Unicorn.CoreTypes;
using Unicorn.FontTools.Afm;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.FontTools
{
    /// <summary>
    /// A font descriptor for one of the PDF standard fonts.  Instances are created by calling <see cref="GetByName(string, double)"/>.
    /// </summary>
    public class PdfStandardFontDescriptor : IFontDescriptor
    {
        private readonly AfmFontMetrics _metrics;

        /// <summary>
        /// The PostScript name of this font.
        /// </summary>
        public string BaseFontName => _metrics.FontName;

        /// <summary>
        /// Unique identifier for the underlying font.
        /// </summary>
        public string UnderlyingKey => $"Standard_{BaseFontName}";

        /// <summary>
        /// Preferred encoding for text using this font.  <see cref="Encoding.ASCII" /> is set here; the actual encoding of the standard fonts is an 8-bit
        /// ASCII-compatible encoding that is not directly supported by .NET Core.
        /// </summary>
        public Encoding PreferredEncoding => Encoding.ASCII;

        /// <summary>
        /// The point size of this font.
        /// </summary>
        public double PointSize { get; private set; }

        /// <summary>
        /// The height of the largest ascender above the baseline.  By convention the ascender of 'd' is used.
        /// </summary>
        public double Ascent => PointSizeTransform(_metrics.Ascender ?? 0m);

        /// <summary>
        /// The height of the largest ascender above the baseline, in glyph units.
        /// </summary>
        public double AscentGlyphUnits => (double)(_metrics.Ascender ?? 0m);

        /// <summary>
        /// The depth of the largest descender below the baseline.  By convention the descender of 'p' is used.
        /// </summary>
        public double Descent => PointSizeTransform(_metrics.Descender ?? 0m);

        /// <summary>
        /// The depth of the largest descender below the baseline, in glyph units.
        /// </summary>
        public double DescentGlyphUnits => (double)(_metrics.Descender ?? 0m);

        /// <summary>
        /// Standard interline white space in this font.
        /// </summary>
        public double InterlineSpacing => PointSize - (Ascent - Descent);

        /// <summary>
        /// A bounding box that encloses any character in the font.
        /// </summary>
        public UniRectangle BoundingBox
        {
            get
            {
                return new UniRectangle(_metrics.FontBoundingBox.Left, _metrics.FontBoundingBox.Bottom, _metrics.FontBoundingBox.Right - _metrics.FontBoundingBox.Left,
                    _metrics.FontBoundingBox.Top - _metrics.FontBoundingBox.Bottom);
            }
        }

        /// <summary>
        /// The height of a typical capital letter above the baseline, in glyph units.
        /// </summary>
        public decimal CapHeight => _metrics.CapHeight ?? 0m;

        /// <summary>
        /// Font style flags.
        /// </summary>
        public FontProperties Flags
        {
            get
            {
                bool isSymbolic = _metrics.CharacterSet == "Special" && _metrics.EncodingScheme == "FontSpecific";
                FontProperties output = isSymbolic ? FontProperties.Symbolic : FontProperties.Nonsymbolic;
                if (_metrics.Direction0Metrics.Value.IsFixedPitch)
                {
                    output |= FontProperties.FixedPitch;
                }
                if (_metrics.Direction0Metrics.Value.ItalicAngle != 0)
                {
                    output |= FontProperties.Italic;
                }
                return output;
            }
        }

        /// <summary>
        /// The angle off-vertical of typical upright stems in this font.  This is zero for fonts that are not italic or oblique.
        /// </summary>
        public decimal ItalicAngle => _metrics.Direction0Metrics.Value.ItalicAngle ?? 0m;

        /// <summary>
        /// The thickness of typical upright stems in this font.
        /// </summary>
        public decimal VerticalStemThickness => _metrics.StdVW ?? 0m;

        /// <summary>
        /// Whether or not this font requires a font descriptor dictionary to be included in PDF files in addition to a font dictionary.  This is always <c>false</c>
        /// for standard fonts.
        /// </summary>
        public bool RequiresFullDescription => false;

        /// <summary>
        /// Whether or not the font's raw data should be embedded in PDF files.  This is always <c>false</c> for standard false.
        /// </summary>
        public bool RequiresEmbedding => false;

        /// <summary>
        /// If the font's raw data is to be embedded in PDF files, this property is the key name used to refer to the raw data stream in the font descriptor dictionary.
        /// For <see cref="PdfStandardFontDescriptor" /> this property is an empty string.
        /// </summary>
        public string EmbeddingKey => "";

        /// <summary>
        /// If the font's raw data is to be embedded in PDF files, this property is the length of the raw data in bytes, before any stream filters are applied.  For
        /// <see cref="PdfStandardFontDescriptor" /> and other non-embeddable fonts, this property is zero.
        /// </summary>
        public long EmbeddingLength => 0;

        /// <summary>
        /// If the font's raw data is to be embedded in PDF files, this property is the data itself.  For <see cref="PdfStandardFontDescriptor" /> and other 
        /// non-embeddable fonts, this property is an empty enumeration.
        /// </summary>
        public IEnumerable<byte> EmbeddingData => Array.Empty<byte>();

        /// <summary>
        /// The size of an empty string rendered in this font.  This is expected to be a zero-width <see cref="UniTextSize" /> value with its vertical metrics
        /// properties populated.
        /// </summary>
        public UniTextSize EmptyStringMetrics => new UniTextSize(0d, PointSize, Ascent + InterlineSpacing / 2, Ascent, -Descent);

        /// <summary>
        /// Constructor.
        /// </summary>
        internal PdfStandardFontDescriptor(AfmFontMetrics metrics, double pointSize)
        {
            _metrics = metrics;
            PointSize = pointSize;
        }

        /// <summary>
        /// Create a <see cref="PdfStandardFontDescriptor" /> instance from a font name and point size.  This method can only create descriptors for fonts that 
        /// have been coded into the library: it assumes that the <see cref="StandardFontMetrics" /> class will have a static property which matches the paramter,
        /// once that name has been normalised by removing hyphens.
        /// </summary>
        /// <param name="name">The name of the font to load, such as "Times-Roman".</param>
        /// <param name="pointSize"></param>
        /// <returns></returns>
        public static PdfStandardFontDescriptor GetByName(string name, double pointSize)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new FontException(Resources.PdfStandardFontDescriptor_GetByName_EmptyStringParameter);
            }
            string typeName = NormaliseName(name);
            PropertyInfo property = typeof(StandardFontMetrics).GetProperty(typeName, BindingFlags.Public | BindingFlags.Static);
            if (property is null)
            {
                throw new FontException(string.Format(CultureInfo.CurrentCulture, Resources.PdfStandardFontDescriptor_GetByName_FontNotFoundByReflection, typeName));
            }
            return new PdfStandardFontDescriptor((AfmFontMetrics)property.GetValue(null), pointSize);
        }

        /// <summary>
        /// Returns an enumeration of the font names supported by the <see cref="GetByName(string, double)"/> method.  Only one form of each name is returned: 
        /// for example, the <see cref="GetByName(string, double)"/> method returns the same results for both "Times-Roman" and "TimesRoman", but only the 
        /// first is included in the output of this method, as that is the name described in the font's AFM file.
        /// </summary>
        /// <returns>An enumeration of strings that are valid standard font names.</returns>
        public static IEnumerable<string> GetSupportedFontNames()
        {
            return StandardFontMetrics.GetSupportedFontNames();
        }

        /// <summary>
        /// Get the width of a space character in this font, in a specific graphics context.
        /// </summary>
        /// <param name="context">The graphics context in which this should be measured.</param>
        /// <returns>The width of a space character in graphics context units.</returns>
        public double GetNormalSpaceWidth(IGraphicsContext context)
        {
            if (context is null)
            {
                return MeasureStringWidth(Resources.SpaceCharacter);
            }
            return context.MeasureString(Resources.SpaceCharacter, this).Width;
        }

        /// <summary>
        /// Measure the width of a string, in points.
        /// </summary>
        /// <param name="str">The string to measure.</param>
        /// <returns>The width of the string, in points.</returns>
        public double MeasureStringWidth(string str)
        {
            return PointSizeTransform(_metrics.MeasureStringWidth(str));
        }

        /// <summary>
        /// Measure the size of a string, in Unicorn points.
        /// </summary>
        /// <param name="str">The string to be measured.</param>
        /// <returns>A <see cref="UniSize" /> instance describing the size of the rendered string.</returns>
        public UniTextSize MeasureString(string str)
        {
            return new UniTextSize(MeasureStringWidth(str), PointSize, Ascent + InterlineSpacing / 2, Ascent, Descent);
        }

        private static string NormaliseName(string fontName)
        {
            return fontName.Replace("-", "");
        }

        private double PointSizeTransform(decimal fontUnitValue)
        {
            return (double)(fontUnitValue * (decimal)PointSize / 1000);
        }
    }
}
