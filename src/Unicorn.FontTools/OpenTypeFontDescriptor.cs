using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicorn.CoreTypes;
using Unicorn.FontTools.CharacterEncoding;
using Unicorn.FontTools.Extensions;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Interfaces;

namespace Unicorn.FontTools
{
    /// <summary>
    /// An <see cref="IFontDescriptor" /> implementation for OpenType fonts.
    /// </summary>
    public class OpenTypeFontDescriptor : IFontDescriptor
    {
        private readonly IOpenTypeFont _underlyingFont;

        /// <summary>
        /// The PostScript font name of the underlying font.
        /// </summary>
        public string BaseFontName
        {
            get
            {
                NameRecord psName = _underlyingFont.Naming.Search(NameField.PostScriptName).FirstOrDefault();
                if (psName is null)
                {
                    psName = _underlyingFont.Naming.Search(NameField.Family).FirstOrDefault();
                }
                return psName?.Content;
            }
        }

        /// <summary>
        /// Bounding box that will enclose any glyph in this font, in normalised "glyph units" where 1,000 units equal 1 em.
        /// </summary>
        public UniRectangle BoundingBox => new UniRectangle(PdfScaleTransform(_underlyingFont.Header.XMin), PdfScaleTransform(_underlyingFont.Header.YMin),
            PdfScaleTransform(_underlyingFont.Header.XMax - _underlyingFont.Header.XMin), PdfScaleTransform(_underlyingFont.Header.YMax - _underlyingFont.Header.YMin));

        /// <summary>
        /// Height of the top of typical capital letters in this font above the baseline, in normalised "glyph units" where 1,000 units equal 1 em.
        /// </summary>
        public decimal CapHeight
        {
            get
            {
                if (_underlyingFont.OS2Metrics.CapHeight.HasValue)
                {
                    return (decimal)PdfScaleTransform(_underlyingFont.OS2Metrics.CapHeight.Value);
                }
                return (decimal)AscentGlyphUnits;
            }
        }

        /// <summary>
        /// Angle off-vertical of upright strokes in this font.
        /// </summary>
        public decimal ItalicAngle => _underlyingFont.PostScriptData.ItalicAngle;

        /// <summary>
        /// Typical thickness of upright strokes in this font - hardcoded to zero because this is not stored in TrueType fonts in any useful way.
        /// </summary>
        public decimal VerticalStemThickness => 0m;

        /// <summary>
        /// Whether or not this font requires a font descriptor dictionary (as well as a font dictionary) to be written to the PDF file.  This should normally be 
        /// <c>true</c> for any fonts other than the built-in PDF fonts.
        /// </summary>
        public bool RequiresFullDescription => true;

        /// <summary>
        /// Flags describing this font's visual style.
        /// </summary>
        public CoreTypes.FontProperties Flags
        {
            get
            {
                CoreTypes.FontProperties output;
                if (CalculationStyle == CalculationStyle.Windows)
                {
                    bool isSymbolic = _underlyingFont.CharacterMapping.SelectExactMapping(PlatformId.Windows, 0) != null;
                    output = _underlyingFont.OS2Metrics.FontSelection.ToFontDescriptorFlags(isSymbolic, _underlyingFont.PostScriptData.IsFixedPitch);
                    if (_underlyingFont.OS2Metrics.IBMFontFamily >= IBMFamily.OldstyleSerif_None && _underlyingFont.OS2Metrics.IBMFontFamily < IBMFamily.SansSerif_None)
                    {
                        output |= CoreTypes.FontProperties.Serif;
                    }
                    if (_underlyingFont.OS2Metrics.IBMFontFamily >= IBMFamily.Scripts_None && _underlyingFont.OS2Metrics.IBMFontFamily < IBMFamily.Symbolic_None)
                    {
                        output |= CoreTypes.FontProperties.Script;
                    }
                }
                else
                {
                    output = CoreTypes.FontProperties.Nonsymbolic;
                    if (_underlyingFont.Header.StyleFlags.HasFlag(MacStyleProperties.Italic))
                    {
                        output |= CoreTypes.FontProperties.Italic;
                    }
                    if (_underlyingFont.PostScriptData.IsFixedPitch)
                    {
                        output |= CoreTypes.FontProperties.FixedPitch;
                    }
                }
                return output;
            }
        }

        /// <summary>
        /// Whether or not this font should be embedded in PDF files.
        /// </summary>
        public bool RequiresEmbedding => CheckEmbeddingAllowed();

        /// <summary>
        /// The key used to refer to the raw data stream for this font in the PDF font descriptor dictionary (this varies according to the file type of the font).
        /// </summary>
        public string EmbeddingKey => CheckEmbeddingAllowed() ? "FontFile2" : "";

        /// <summary>
        /// The length of the raw data for this font.
        /// </summary>
        public long EmbeddingLength => CheckEmbeddingAllowed() ? _underlyingFont.Length : 0L;

        /// <summary>
        /// The raw data comprising this font, as a sequence of bytes.
        /// </summary>
        public IEnumerable<byte> EmbeddingData => CheckEmbeddingAllowed() ? (IEnumerable<byte>)_underlyingFont : Array.Empty<byte>();

        /// <summary>
        /// A unique identifier for this font face, constructed from the filename of the underlying font program file.
        /// </summary>
        public string UnderlyingKey => "OpenType_" + _underlyingFont.Filename;

        /// <summary>
        /// Preferred text encoding when using this font.  FIXME this should be picked up from the cmap table and should match the encoding in the PDF 
        /// font resource table
        /// </summary>
        public Encoding PreferredEncoding => Encoding.GetEncoding(1252);

        /// <summary>
        /// The point size to render this font in.
        /// </summary>
        public double PointSize { get; }

        private CalculationStyle _calcStyle = CalculationStyle.Windows;

        /// <summary>
        /// Whether to use Windows-style or Macintosh-style calculations when doing platform-dependent metrics calculations.
        /// </summary>
        public CalculationStyle CalculationStyle
        {
            get => _calcStyle;
            set
            {
                _ascent = null;
                _descent = null;
                _calcStyle = value;
            }
        }

        private double? _ascent;

        /// <summary>
        /// The height of the ascenders of this font.
        /// </summary>
        public double Ascent
        {
            get
            {
                if (!_ascent.HasValue)
                {
                    if (CalculationStyle == CalculationStyle.Macintosh || !_underlyingFont.OS2Metrics.Ascender.HasValue)
                    {
                        _ascent = PointScaleTransform(_underlyingFont.HorizontalHeader.Ascender);
                    }
                    else
                    {
                        _ascent = PointScaleTransform(_underlyingFont.OS2Metrics.Ascender.Value);
                    }
                }
                return _ascent.Value;
            }
        }

        /// <summary>
        /// The <see cref="Ascent" /> property scaled to normalised "glyph units", with 1,000 glyph units per em.
        /// </summary>
        public double AscentGlyphUnits => PointToPdfScaleTransform(Ascent);

        private double? _descent;

        /// <summary>
        /// The height of the descenders of this font.
        /// </summary>
        public double Descent
        {
            get
            {
                if (!_descent.HasValue)
                {
                    if (CalculationStyle == CalculationStyle.Macintosh || !_underlyingFont.OS2Metrics.Descender.HasValue)
                    {
                        _descent = PointScaleTransform(_underlyingFont.HorizontalHeader.Descender);
                    }
                    else
                    {
                        _descent = PointScaleTransform(_underlyingFont.OS2Metrics.Descender.Value);
                    }
                }
                return _descent.Value;
            }
        }

        /// <summary>
        /// The <see cref="Descent" /> property scaled to normalised "glyph units", with 1,000 glyph units per em.
        /// </summary>
        public double DescentGlyphUnits => PointToPdfScaleTransform(Descent);

        /// <summary>
        /// Standard interline white space in this font.
        /// </summary>
        public double InterlineSpacing => PointSize - (Ascent - Descent);

        /// <summary>
        /// The size of an empty string rendered in this font.  This is expected to be a zero-width <see cref="UniTextSize" /> value with its vertical metrics
        /// properties populated.
        /// </summary>
        public UniTextSize EmptyStringMetrics => new UniTextSize(0d, PointSize, Ascent + InterlineSpacing / 2, Ascent, -Descent);

        private static bool _codePagesRegistered;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="font">The underlying font.</param>
        /// <param name="pointSize">The point size the font will be rendered at.</param>
        internal OpenTypeFontDescriptor(IOpenTypeFont font, double pointSize)
        {
            PointSize = pointSize;
            _underlyingFont = font;
            if (!_codePagesRegistered)
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                _codePagesRegistered = true;
            }
        }

        /// <summary>
        /// Measure the width of a space in this font, using the value of the "break character" field in the "OS/2" table if it is populated.
        /// </summary>
        /// <param name="context">Ignored.</param>
        /// <returns>The width of this font's standard space character.</returns>
        public double GetNormalSpaceWidth(IGraphicsContext context)
        {
            if (_underlyingFont.OS2Metrics.BreakChar.HasValue)
            {
                return PointScaleTransform(_underlyingFont.AdvanceWidth(PlatformId.Windows, _underlyingFont.OS2Metrics.BreakChar.Value));
            }
            return PointScaleTransform(_underlyingFont.AdvanceWidth(PlatformId.Windows, 0x20));
        }

        /// <summary>
        /// Measure the rendered size of a string in this font.
        /// </summary>
        /// <param name="str">The string to be measured.</param>
        /// <returns>A <see cref="UniSize" /> value describing the height and width of the rendered string.</returns>
        public UniTextSize MeasureString(string str)
        {
            byte[] encodedBytes = PreferredEncoding.GetBytes(str);
            var codePoints = encodedBytes.Select(b => PdfCharacterMappingDictionary.WinAnsiEncoding.Transform(b));
            int totWidth = codePoints.Select(p => _underlyingFont.AdvanceWidth(PlatformId.Windows, (uint)p)).Sum();
            return new UniTextSize(PointScaleTransform(totWidth), EmptyStringMetrics.LineHeight, EmptyStringMetrics.HeightAboveBaseline, 
                EmptyStringMetrics.AscenderHeight, EmptyStringMetrics.DescenderHeight);
        }

        /// <summary>
        /// Returns the lowest value which, when using the PDF "WinAnsiEncoding", maps to a non-zero glyph.
        /// </summary>
        /// <returns></returns>
        public byte FirstMappedByte()
        {
            byte b = 0;
            while (!_underlyingFont.HasGlyphDefined(PlatformId.Windows, (uint)PdfCharacterMappingDictionary.WinAnsiEncoding.Transform(b)))
            {
                ++b;
            }
            return b;
        }

        /// <summary>
        /// Returns the highest value which, when using the PDF "WinAnsiEncoding", maps to a non-zero glyph.
        /// </summary>
        /// <returns></returns>
        public byte LastMappedByte()
        {
            byte b = 255;
            while (!_underlyingFont.HasGlyphDefined(PlatformId.Windows, (uint)PdfCharacterMappingDictionary.WinAnsiEncoding.Transform(b)))
            {
                --b;
            }
            return b;
        }

        /// <summary>
        /// Returns an enumeration of the widths of all of the characters that can be used in text encoded using the PDF "WinAnsiEncoding", in PDF-normalised font
        /// measurement units.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Double}" /> whose first element is the width of the character represented by the codepoint returned by the 
        /// <see cref="FirstMappedByte" /> method.</returns>
        public IEnumerable<double> CharWidths()
        {
            byte start = FirstMappedByte();
            byte end = LastMappedByte();
            for (int b = start; b <= end; ++b)
            {
                yield return PdfScaleTransform(_underlyingFont.AdvanceWidth(PlatformId.Windows, (uint)PdfCharacterMappingDictionary.WinAnsiEncoding.Transform((byte)b)));
            }
        }

        private double PointScaleTransform(double distInFontUnits) => PointSize * distInFontUnits / _underlyingFont.DesignUnitsPerEm;

        private double PdfScaleTransform(double distInFontUnits) => 1000 * distInFontUnits / _underlyingFont.DesignUnitsPerEm;

        private double PointToPdfScaleTransform(double distPoints) => distPoints * 1000 / PointSize;

        private bool CheckEmbeddingAllowed()
        {
            EmbeddingPermissions fontFlags = _underlyingFont.OS2Metrics.EmbeddingPermissions;
            if (fontFlags == EmbeddingPermissions.Installable)
            {
                return true;
            }
            return (fontFlags.HasFlag(EmbeddingPermissions.Editable) ||
                    fontFlags.HasFlag(EmbeddingPermissions.Printing)) 
                && !fontFlags.HasFlag(EmbeddingPermissions.BitmapOnly);
        }
    }
}
