using System;
using Unicorn.CoreTypes;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// A specialised PDF dictionary containing font metadata and generic metrics.  Units in this dictionary are generally in normalised glyph units, where 1000
    /// units equal 1 em.
    /// </summary>
    public class PdfFontDescriptor : PdfSpecialisedDictionary
    {
        /// <summary>
        /// Name of the font.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Font style flags.
        /// </summary>
        public FontProperties Flags { get; private set; }

        /// <summary>
        /// Most inclusive bounding box of all glyphs in the font.
        /// </summary>
        public PdfRectangle BoundingBox { get; private set; }

        /// <summary>
        /// The angle off vertical of typical upright stems in this font, in the clockwise direction.  Zero for non-italic or -oblique fonts.
        /// </summary>
        public decimal ItalicAngle { get; private set; }

        /// <summary>
        /// The ascent of the font.
        /// </summary>
        public decimal Ascent { get; private set; }

        /// <summary>
        /// The descent of the font.
        /// </summary>
        public decimal Descent { get; private set; }

        /// <summary>
        /// The height of a typical capital letter in this font.
        /// </summary>
        public decimal CapHeight { get; private set; }

        /// <summary>
        /// The thickness of a typical vertical stem in this font, or zero if not known (this figure is not straightforward to determine for TrueType fonts).
        /// </summary>
        public decimal StemV { get; private set; }

        private readonly string _embeddingKey;

        /// <summary>
        /// The stream containing the raw data of the font.
        /// </summary>
        public PdfStream EmbeddedData { get; private set; }

        private static readonly Lazy<PdfName> _fontNameName = new Lazy<PdfName>(() => new PdfName("FontName"));
        private static readonly Lazy<PdfName> _flagsName = new Lazy<PdfName>(() => new PdfName("Flags"));
        private static readonly Lazy<PdfName> _fontBBoxName = new Lazy<PdfName>(() => new PdfName("FontBBox"));
        private static readonly Lazy<PdfName> _italicAngleName = new Lazy<PdfName>(() => new PdfName("ItalicAngle"));
        private static readonly Lazy<PdfName> _ascentName = new Lazy<PdfName>(() => new PdfName("Ascent"));
        private static readonly Lazy<PdfName> _descentName = new Lazy<PdfName>(() => new PdfName("Descent"));
        private static readonly Lazy<PdfName> _capHeightName = new Lazy<PdfName>(() => new PdfName("CapHeight"));
        private static readonly Lazy<PdfName> _stemVName = new Lazy<PdfName>(() => new PdfName("StemV"));

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="objectId">The object ID of the descriptor within the file.</param>
        /// <param name="font">The font that this font descriptor applies to.</param>
        /// <param name="embeddingKey">The key in this dictionary that refers to the <see cref="EmbeddedData" /> stream (this key varies depending on the font 
        /// format), or an empty string if the font data should not be embedded.</param>
        /// <param name="embeddingData">The stream that contains the font's raw data, or <c>null</c> if the font data should not be embedded.</param>
        /// <param name="generation">The generation number of the dictionary.  This should always be zero at present, as Unicorn does not support editing
        /// existing files.</param>
        public PdfFontDescriptor(int objectId, IFontDescriptor font, string embeddingKey, PdfStream embeddingData, int generation = 0) : base(objectId, generation)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            Name = font.BaseFontName;
            Flags = font.Flags;
            BoundingBox = new PdfRectangle(font.BoundingBox.MinX, font.BoundingBox.MinY, font.BoundingBox.MinX + font.BoundingBox.Width,
                font.BoundingBox.MinY + font.BoundingBox.Height);
            ItalicAngle = font.ItalicAngle;
            Ascent = (decimal)font.AscentGlyphUnits;
            Descent = (decimal)font.DescentGlyphUnits;
            CapHeight = font.CapHeight;
            StemV = font.VerticalStemThickness;
            _embeddingKey = embeddingKey;
            EmbeddedData = embeddingData;
        }

        /// <summary>
        /// Construct the dictionary which will be written to the output to represent this object.
        /// </summary>
        /// <returns>A <see cref="PdfDictionary" /> containing the properties of this object in the correct format.</returns>
        protected override PdfDictionary MakeDictionary()
        {
            PdfDictionary d = new PdfDictionary
            {
                { CommonPdfNames.Type, new PdfName("FontDescriptor") },
                { _fontNameName.Value, new PdfName(Name) },
                { _flagsName.Value, new PdfInteger((int)Flags) },
                { _fontBBoxName.Value, BoundingBox },
                { _italicAngleName.Value, new PdfReal(ItalicAngle) },
                { _ascentName.Value, new PdfReal(Ascent) },
                { _descentName.Value, new PdfReal(Descent) },
                { _capHeightName.Value, new PdfReal(CapHeight) },
                { _stemVName.Value, new PdfReal(StemV) }
            };
            if (_embeddingKey.Length != 0 && EmbeddedData != null)
            {
                d.Add(new PdfName(_embeddingKey), EmbeddedData.GetReference());
            }
            return d;
        }
    }
}
