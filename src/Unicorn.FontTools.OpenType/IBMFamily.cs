namespace Unicorn.FontTools.OpenType
{

#pragma warning disable CA1707 // Identifiers should not contain underscores

    /// <summary>
    /// IBM font classification and subclassification values.  These are officially defined as separate fields, each of one byte, but as the valid subclassification
    /// values vary according to the classification value, it makes sense here to consider them as a single enumeration which can be cast from short or ushort.  The
    /// underscores in the identifiers separate the classification and subclassification names.  The examples and descriptions are taken from the OpenType standards
    /// documents.
    /// </summary>
    public enum IBMFamily
    {
        /// <summary>
        /// No classification.
        /// </summary>
        None = 0,

        /// <summary>
        /// Based on 15th-17th century Latin printing styles, but with no subclassification.
        /// </summary>
        OldstyleSerif_None = 0x100,

        /// <summary>
        /// Fonts based on 15th-17th century styles with high x-height and short ascenders and descenders, with hand-tuned bitmaps.
        /// </summary>
        OldstyleSerif_IBMRoundedLegibility = 0x101,

        /// <summary>
        /// Fonts with tall ascenders such as ITC Garamond.
        /// </summary>
        OldstyleSerif_Garalde = 0x102,

        /// <summary>
        /// Fonts with a medium x-height and sweeping tails, inspired by early Venetian printers.
        /// </summary>
        OldstyleSerif_Venetian = 0x103,
        
        /// <summary>
        /// Fonts with a large x-height and sweeping tails such as Palatino.
        /// </summary>
        OldstyleSerif_ModifiedVenetian = 0x104,

        /// <summary>
        /// Fonts with a large x-height, wedge-shaped serifs, circular bowls and light strokes.
        /// </summary>
        OldstyleSerif_DutchModern = 0x105,

        /// <summary>
        /// Fonts with large x-height, wedge-shaped serifs and circular bowls such as IBM Press Roman.
        /// </summary>
        OldstyleSerif_DutchTraditional = 0x106,

        /// <summary>
        /// Fonts such as University.
        /// </summary>
        OldstyleSerif_Contemporary = 0x107,

        /// <summary>
        /// Oldstyle fonts with calligraphic styles.
        /// </summary>
        OldstyleSerif_Calligraphic = 0x108,

        /// <summary>
        /// Other Oldstyle fonts.
        /// </summary>
        OldstyleSerif_Miscellaneous = 0x10f,

        /// <summary>
        /// Serif fonts based on 18th-19th century printing styles generally with vertical strokes being noticeably heavier than horizontal strokes.
        /// </summary>
        TransitionalSerif_None = 0x200,

        /// <summary>
        /// Fonts such as Monotype Baskerville.
        /// </summary>
        TransitionalSerif_DirectLine = 0x201,

        /// <summary>
        /// Transitional Direct Line style fonts with a handwritten appearance.
        /// </summary>
        TransitionalSerif_Script = 0x202,

        /// <summary>
        /// Other transitional serif fonts.
        /// </summary>
        TransitionalSerif_Miscellaneous = 0x20f,

        /// <summary>
        /// Fonts inspired by 20th century Latin printing styles with very large contrasts between thick and thin strokes.
        /// </summary>
        ModernSerif_None = 0x300,

        /// <summary>
        /// Fonts such as Monotype Bodoni.
        /// </summary>
        ModernSerif_Italian = 0x301,

        /// <summary>
        /// Modern Serif Italian style fonts with a handwritten appearance.
        /// </summary>
        ModernSerif_Script = 0x302,

        /// <summary>
        /// Miscellaneous Modern Serif fonts.
        /// </summary>
        ModernSerif_Miscellaneous = 0x30f,

        /// <summary>
        /// Variants on Oldstyle and Transitional Serifs with mild vertical stroke contrast.
        /// </summary>
        ClarendonSerif_None = 0x400,

        /// <summary>
        /// Clarendon and similar fonts.
        /// </summary>
        ClarendonSerif_Clarendon = 0x401,

        /// <summary>
        /// Fonts such as Century Schoolbook.
        /// </summary>
        ClarendonSerif_Modern = 0x402,

        /// <summary>
        /// Fonts such as Century.
        /// </summary>
        ClarendonSerif_Traditional = 0x403,

        /// <summary>
        /// Fonts such as Linotype Excelsior.
        /// </summary>
        ClarendonSerif_Newspaper = 0x404,

        /// <summary>
        /// Fonts such as Cheltenham.
        /// </summary>
        ClarendonSerif_StubSerif = 0x405,

        /// <summary>
        /// Fonts such as ITC Korinna.
        /// </summary>
        ClarendonSerif_Monotone = 0x406,

        /// <summary>
        /// Typewriter-style fonts such as Prestige Elite.
        /// </summary>
        ClarendonSerif_Typewriter = 0x407,

        /// <summary>
        /// Miscellaneous Clarendon-style fonts.
        /// </summary>
        ClarendonSerif_Miscellaneous = 0x40f,

        /// <summary>
        /// Slab serif fonts with no subclassification.
        /// </summary>
        SlabSerif_None = 0x500,

        /// <summary>
        /// Slab serif fonts with strokes and serifs of equal weight, such as ITC Lubalin.
        /// </summary>
        SlabSerif_Monotone = 0x501,

        /// <summary>
        /// Slab serif fonts whose serifs are lighter weight than the strokes, such as Candida.
        /// </summary>
        SlabSerif_Humanist = 0x502,

        /// <summary>
        /// Slab serif fonts with strokes and serifs of equal weight and geometric designs, such as Rockwell.
        /// </summary>
        SlabSerif_Geometric = 0x503,

        /// <summary>
        /// Slab serif fonts with strokes and serifs of equal weight and an emphasis on the characters' negative space.
        /// </summary>
        SlabSerif_Swiss = 0x504,

        /// <summary>
        /// Typewriter-style slab serifs such as Courier.
        /// </summary>
        SlabSerif_Typewriter = 0x505,

        /// <summary>
        /// Miscellaneous slab serifs.
        /// </summary>
        SlabSerif_Miscellaneous = 0x50f,

        /// <summary>
        /// Serif fonts that do not fit into the lower-numbered classifications.
        /// </summary>
        FreeformSerif_None = 0x700,

        /// <summary>
        /// Serif fonts with medium x-height, light stroke contrast and rounded design, such as ITC Souvenir.
        /// </summary>
        FreeformSerif_Modern = 0x701,

        /// <summary>
        /// Miscellaneous freeform serif fonts.
        /// </summary>
        FreeformSerif_Miscellaneous = 0x70f,

        /// <summary>
        /// Sans fonts with no subclassification.
        /// </summary>
        SansSerif_None = 0x800,

        /// <summary>
        /// Sans fonts with large x-height, uniform stroke with, and provided with hand-tuned bitmaps.
        /// </summary>
        SansSerif_IBMNeoGrotesqueGothic = 0x801,

        /// <summary>
        /// Sans fonts with a medium x-height and classical letterforms, such as Optima.
        /// </summary>
        SansSerif_Humanist = 0x802,

        /// <summary>
        /// Fonts such as Futura.
        /// </summary>
        SansSerif_LowXRoundGeometric = 0x803,

        /// <summary>
        /// Fonts such as Avant Garde Gothic.
        /// </summary>
        SansSerif_HighXRoundGeometric = 0x804,

        /// <summary>
        /// Fonts such as Helvetica.
        /// </summary>
        SansSerif_NeoGrotesqueGothic = 0x805,

        /// <summary>
        /// Fonts such as Univers.
        /// </summary>
        SansSerif_ModifiedNeoGrotesqueGothic = 0x806,

        /// <summary>
        /// Monospaced sans fonts such as Letter Gothic.
        /// </summary>
        SansSerif_TypewriterGothic = 0x809,

        /// <summary>
        /// Dot-matrix style fonts such as Matrix Gothic.
        /// </summary>
        SansSerif_Matrix = 0x80a,

        /// <summary>
        /// Miscellaneous sans fonts.
        /// </summary>
        SansSerif_Miscellaneous = 0x80f,

        /// <summary>
        /// Highly-decorated or stylised and/or display fonts.
        /// </summary>
        Ornamentals_None = 0x900,

        /// <summary>
        /// Copperplate-style fonts.
        /// </summary>
        Ornamentals_Engraver = 0x901,

        /// <summary>
        /// Blackletter fonts.
        /// </summary>
        Ornamentals_BlackLetter = 0x902,

        /// <summary>
        /// Fonts with ornamental designs such as leaves or flowers incorporated into the characters.
        /// </summary>
        Ornamentals_Decorative = 0x903,

        /// <summary>
        /// Fonts whose letterforms have a 3D appearance.
        /// </summary>
        Ornamentals_ThreeDimensional = 0x904,

        /// <summary>
        /// Miscellaneous ornamental fonts.
        /// </summary>
        Ornamentals_Miscellaneous = 0x90f,

        /// <summary>
        /// Fonts with a handwritten appearance (other than those subclassifications listed above).
        /// </summary>
        Scripts_None = 0xa00,

        /// <summary>
        /// Fonts based on 6th-9th century monastic hands.
        /// </summary>
        Scripts_Uncials = 0xa01,

        /// <summary>
        /// Fonts that simulate the appearance of brush painting, with joined characters.
        /// </summary>
        Scripts_BrushJoined = 0xa02,

        /// <summary>
        /// Fonts that simulate the appearance of formal handwriting with joined characters.
        /// </summary>
        Scripts_FormalJoined = 0xa03,

        /// <summary>
        /// Fonts with joined characters and no contrast between strokes.
        /// </summary>
        Scripts_MonotoneJoined = 0xa04,

        /// <summary>
        /// Fonts that simulate being handwritten with a broad-nibbed pen in calligraphic unjoined style.
        /// </summary>
        Scripts_Calligraphic = 0xa05,

        /// <summary>
        /// Fonts that simulate the appearance of brush painting, with unjoined characters.
        /// </summary>
        Scripts_BrushUnjoined = 0xa06,

        /// <summary>
        /// Fonts that simulate the appearance of formal handwriting with unjoined characters.
        /// </summary>
        Scripts_FormalUnjoined = 0xa07,

        /// <summary>
        /// Fonts that consist of unjoined handwritten characters with little contrast between strokes.
        /// </summary>
        Scripts_MonotoneUnjoined = 0xa08,

        /// <summary>
        /// Miscellaneous script-style fonts.
        /// </summary>
        Scripts_Miscellaneous = 0xa0f,

        /// <summary>
        /// Symbolic fonts.
        /// </summary>
        Symbolic_None = 0xc00,

        /// <summary>
        /// Symbolic fonts containing mixed serif and sans characters.
        /// </summary>
        Symbolic_MixedSerif = 0xc03,

        /// <summary>
        /// Symbolic fonts containing oldstyle serif characters.
        /// </summary>
        Symbolic_OldStyleSerif = 0xc06,

        /// <summary>
        /// Symbolic fonts containing neo-grotesque sans characters.
        /// </summary>
        Symbolic_NeoGrotesqueSansSerif = 0xc07,

        /// <summary>
        /// Miscellaneous symbolic fonts.
        /// </summary>
        Symbolic_Miscellaneous = 0xc0f,
    }

#pragma warning restore CA1707 // Identifiers should not contain underscores

}
