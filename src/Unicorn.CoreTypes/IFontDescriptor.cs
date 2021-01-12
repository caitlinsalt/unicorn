using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// Wrapper object for a font, exposing its metadata.
    /// </summary>
    public interface IFontDescriptor
    {
        /// <summary>
        /// The PostScript name of the underlying font.
        /// </summary>
        string BaseFontName { get; }

        /// <summary>
        /// A string that can be used to uniquely determine the underlying font.  Two <see cref="IFontDescriptor" /> instances that refer to the same font at different
        /// point sizes should have the same <see cref="UnderlyingKey" /> value.  Two <see cref="IFontDescriptor" /> instances that refer to different styles of the
        /// same face, even when the style is expected to be created dynamically by the OS, should have different <see cref="UnderlyingKey" /> values.
        /// </summary>
        string UnderlyingKey { get; }

        /// <summary>
        /// Preferred text encoding when using this font.
        /// </summary>
        Encoding PreferredEncoding { get; }

        /// <summary>
        /// The point size of this font.
        /// </summary>
        double PointSize { get; }

        /// <summary>
        /// The ascent of the font above the baseline.
        /// </summary>
        double Ascent { get; }

        /// <summary>
        /// The ascent of the font above the baseline, in glyph units.
        /// </summary>
        double AscentGlyphUnits { get; }

        /// <summary>
        /// The descent of the font below the baseline.
        /// </summary>
        double Descent { get; }

        /// <summary>
        /// The descent of the font below the baseline, in glyph units.
        /// </summary>
        double DescentGlyphUnits { get; }

        /// <summary>
        /// The amount of white space between the bottom of th descenders of one line and the top of the ascenders of the next, where the leading is zero.  Should
        /// normally be equal to <see cref="PointSize" /><c> - (</c><see cref="Ascent" /><c> - </c><see cref="Descent" /><c>)</c>.  
        /// </summary>
        double InterlineSpacing { get; }

        /// <summary>
        /// The size of an empty string rendered in this font.  This is expected to be a zero-width <see cref="UniTextSize" /> value with its vertical metrics
        /// properties populated.
        /// </summary>
        UniTextSize EmptyStringMetrics { get; }

        /// <summary>
        /// The maximal bounding box of all characters in this font.
        /// </summary>
        UniRectangle BoundingBox { get; }

        /// <summary>
        /// The angle off-vertical of italic stems in this font.
        /// </summary>
        decimal ItalicAngle { get; }

        /// <summary>
        /// The height of a typical capital letter in this font, in glyph units.
        /// </summary>
        decimal CapHeight { get; }

        /// <summary>
        /// The thickness of a typical vertical stem in this font.
        /// </summary>
        decimal VerticalStemThickness { get; }

        /// <summary>
        /// Flags describing this font's visual style.
        /// </summary>
        FontProperties Flags { get; }

        /// <summary>
        /// Whether or not this font requires a font descriptor dictionary to be written to the PDF output.  This is true for most fonts other than those that
        /// all PDF readers are required to support, including all fonts that are embeddable.
        /// </summary>
        bool RequiresFullDescription { get; }

        /// <summary>
        /// Whether or not this font should be embedded in PDF files
        /// </summary>
        bool RequiresEmbedding { get; }

        /// <summary>
        /// The length of the raw data of this font, if it is embeddable.
        /// </summary>
        long EmbeddingLength { get; }

        /// <summary>
        /// If the font is embedded in a PDF file, this property contains the name of key in the font descriptor dictionary which refers to the embedded data 
        /// (the name of this key varies according to the font type).
        /// </summary>
        string EmbeddingKey { get; }

        /// <summary>
        /// If the font is embeddable, this property contains the raw data which should be embedded.
        /// </summary>
        IEnumerable<byte> EmbeddingData { get; }

        /// <summary>
        /// Measure the size of a string when rendered in this font.
        /// </summary>
        /// <param name="str">The string to be measured.</param>
        /// <returns>A <see cref="UniSize" /> instance containing the size of the string.</returns>
        UniTextSize MeasureString(string str);

        /// <summary>
        /// Return the width of a "normal space" - ASCII 0x20 - in this font, using the given graphics context to render it.
        /// </summary>
        /// <param name="context">The context used to render the font.</param>
        /// <returns>The width of the ASCII space character.</returns>
        double GetNormalSpaceWidth(IGraphicsContext context);
    }
}
