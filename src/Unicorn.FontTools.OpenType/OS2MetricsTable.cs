using System;
using System.IO;
using Unicorn.FontTools.OpenType.Extensions;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The "OS/2" table, containing Windows- and OS/2- specific metric information, and also information about design classification, licensing and character 
    /// range support.
    /// </summary>
    public class OS2MetricsTable : Table
    {
        /// <summary>
        /// Table version number.  If this field is 5, this implies all nullable fields will have values.
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// Average character width across all characters in the font.
        /// </summary>
        public short AverageCharWidth { get; private set; }

        /// <summary>
        /// Weight classification value.
        /// </summary>
        public int WeightClass { get; private set; }

        /// <summary>
        /// Character width classification value.
        /// </summary>
        public int WidthClass { get; private set; }

        /// <summary>
        /// Font embedding permissions.
        /// </summary>
        public EmbeddingPermissions EmbeddingPermissions { get; private set; }

        /// <summary>
        /// If regular characters in this font are used as subscripts, they should be horizontally scaled by this field divided by <see cref="HeaderTable.FontUnitScale" />.
        /// </summary>
        public short SubscriptXSize { get; private set; }

        /// <summary>
        /// If regular characters in this font are used as subscripts, they should be vertically scaled by this field divided by <see cref="HeaderTable.FontUnitScale"/>.
        /// </summary>
        public short SubscriptYSize { get; private set; }

        /// <summary>
        /// If regular characters in this font are used as subscripts, they should be horizontally offset by this number of font design units.
        /// </summary>
        public short SubscriptXOffset { get; private set; }

        /// <summary>
        /// If regular characters in this font are used as subscripts, they should be vertically offset by this number of font design units.
        /// </summary>
        public short SubscriptYOffset { get; private set; }

        /// <summary>
        /// If regular characters in this font are used as superscripts, they should be horizontally scaled by this field divided by <see cref="HeaderTable.FontUnitScale" />.
        /// </summary>
        public short SuperscriptXSize { get; private set; }

        /// <summary>
        /// If regular characters in this font are used as subscripts, they should be vertically scaled by this field divided by <see cref="HeaderTable.FontUnitScale"/>.
        /// </summary>
        public short SuperscriptYSize { get; private set; }

        /// <summary>
        /// If regular characters in this font are used as subscripts, they should be horizontally offset by this number of font design units.
        /// </summary>
        public short SuperscriptXOffset { get; private set; }

        /// <summary>
        /// If regular characters in this font are used as subscripts, they should be vertically offset by this number of font design units.
        /// </summary>
        public short SuperscriptYOffset { get; private set; }

        /// <summary>
        /// Thickness of strikeout line for this font.
        /// </summary>
        public short StrikeoutSize { get; private set; }

        /// <summary>
        /// Position of strikeout line for this font.
        /// </summary>
        public short StrikeoutPosition { get; private set; }

        /// <summary>
        /// The IBM font classification of this font.
        /// </summary>
        public IBMFamily IBMFontFamily { get; private set; }

        /// <summary>
        /// The PANOSE font classification of this font.
        /// </summary>
        public PanoseFamily PanoseFontFamily { get; private set; }

        /// <summary>
        /// A set of flags listing the Unicode codepoint blocks supported by this font.
        /// </summary>
        public UnicodeRanges UnicodeRanges { get; private set; }

        /// <summary>
        /// Font vendor tag.  See https://docs.microsoft.com/en-gb/typography/vendors/ for details of registered font vendors and their tags.
        /// </summary>
        public Tag VendorId { get; private set; }

        /// <summary>
        /// Font style flags.  Windows-style calculations use this field in preference to <see cref="HeaderTable.StyleFlags" />.
        /// </summary>
        public OS2StyleProperties FontSelection { get; private set; }

        /// <summary>
        /// The lowest Unicode code point supported by this font for platform 3, encoding 0 or 1 (or 0xFFFF if the actual lowest supported code point is higher 
        /// than 0xFFFF).
        /// </summary>
        public int MinCodePoint { get; private set; }

        /// <summary>
        /// The highest Unicode code point supported by this font for platform 3, encoding 0 or 1 (or 0xFFFF if the actual highest supported code point is higher than
        /// 0xFFFF.
        /// </summary>
        public int MaxCodePoint { get; private set; }

        /// <summary>
        /// The typographical ascent of the font.  Windows-style calculations should use this field in preference to <see cref="HorizontalHeaderTable.Ascender" />.
        /// Not populated if this table uses the Apple variant of Version 0.
        /// </summary>
        public short? Ascender { get; private set; }

        /// <summary>
        /// The typographical descent of the font.  Windows-style calculations should use this field in preference to <see cref="HorizontalHeaderTable.Descender" />.
        /// Not populated if this table uses the Apple variant of Version 0.
        /// </summary>
        public short? Descender { get; private set; }

        /// <summary>
        /// The additional line gap, over and above the height of the font.  Windows-style calculations should use this field in preference to 
        /// <see cref="HorizontalHeaderTable.LineGap" />.  Not populated if this table uses the Apple variant of Version 0.
        /// </summary>
        public short? LineGap { get; private set; }

        /// <summary>
        /// Used on Windows platforms to determine the upper boundary of the glyph clipping region.  Not populated if this table uses the Apple variant of Version 0.
        /// </summary>
        public int? WindowsAscender { get; private set; }

        /// <summary>
        /// Used on Windows platforms to determine the lower boundary of the glyph clipping region.  Not populated if this table uses the Apple variant of Version 0.
        /// </summary>
        public int? WindowsDescender { get; private set; }

        /// <summary>
        /// Code pages supported by this font.  Not populated if this table is Version 0.
        /// </summary>
        public SupportedCodePages CodePages { get; private set; }

        /// <summary>
        /// X-height of this font.  Not populated if this table is Version 0 or 1.
        /// </summary>
        public short? XHeight { get; private set; }

        /// <summary>
        /// Cap height of this font.  Not populated if this table is Version 0 or 1.
        /// </summary>
        public short? CapHeight { get; private set; }

        /// <summary>
        /// The code point of a character to be displayed in place of unsupported characters.  If this field is 0, glyph ID 0 should be used.  Not populated if this
        /// table is Version 0 or 1.
        /// </summary>
        public int? DefaultChar { get; private set; }

        /// <summary>
        /// The code point of a character that can be used as a word-breaking character, such as 0x20.  Not populated if this table is Version 0 or 1.
        /// </summary>
        public int? BreakChar { get; private set; }

        /// <summary>
        /// The maximum length target glyph context for this font; in other words, the maximum amount of character look-ahead needed to determine the metrics and
        /// positioning of a specific glyph.
        /// </summary>
        public int? MaxContext { get; private set; }

        /// <summary>
        /// The lowest optical size for which this font was designed to be used, measured in 1/20ths of a point.  Not populated in versions prior to Version 5.
        /// </summary>
        public int? LowerOpticalPointSize { get; private set; }

        /// <summary>
        /// The highest optical size for which this font was designed to be used, measured in 1/20ths of a point.  Not populated in versions prior to Version 5.
        /// </summary>
        public int? UpperOpticalPointSize { get; private set; }

        /// <summary>
        /// Constructor for Version 5 format tables.
        /// </summary>
        /// <param name="avgCharWidth">The value for the <see cref="AverageCharWidth" /> property.</param>
        /// <param name="weightClass">The value for the <see cref="WeightClass" /> property.</param>
        /// <param name="widthClass">The value for the <see cref="WidthClass" /> property.</param>
        /// <param name="permissions">The value for the <see cref="EmbeddingPermissions" /> property.</param>
        /// <param name="subscriptXSize">The value for the <see cref="SubscriptXSize" /> property.</param>
        /// <param name="subscriptYSize">The value for the <see cref="SubscriptYSize" /> property.</param>
        /// <param name="subscriptXOffset">The value for the <see cref="SubscriptXOffset" /> property.</param>
        /// <param name="subscriptYOffset">The value for the <see cref="SubscriptYOffset" /> property.</param>
        /// <param name="superscriptXSize">The value for the <see cref="SuperscriptXSize" /> property.</param>
        /// <param name="superscriptYSize">The value for the <see cref="SuperscriptYSize" /> property.</param>
        /// <param name="superscriptXOffset">The value for the <see cref="SuperscriptXOffset" /> property.</param>
        /// <param name="superscriptYOffset">The value for the <see cref="SuperscriptYOffset" /> property.</param>
        /// <param name="strikeoutSize">The value for the <see cref="StrikeoutSize" /> property.</param>
        /// <param name="strikeoutPosition">The value for the <see cref="StrikeoutPosition" /> property.</param>
        /// <param name="ibmFamily">The value for the <see cref="IBMFontFamily" /> property.</param>
        /// <param name="panoseFamily">The value for the <see cref="PanoseFontFamily" /> property.</param>
        /// <param name="unicodeRanges">The value for the <see cref="UnicodeRanges" /> property.</param>
        /// <param name="vendorId">The value for the <see cref="VendorId" /> property.</param>
        /// <param name="fontSelection">The value for the <see cref="FontSelection" /> property.</param>
        /// <param name="minCodePoint">The value for the <see cref="MinCodePoint" /> property.</param>
        /// <param name="maxCodePoint">The value for the <see cref="MaxCodePoint" /> property.</param>
        /// <param name="ascender">The value for the <see cref="Ascender" /> property.</param>
        /// <param name="descender">The value for the <see cref="Descender" /> property.</param>
        /// <param name="lineGap">The value for the <see cref="LineGap" /> property.</param>
        /// <param name="winAscender">The value for the <see cref="WindowsAscender" /> property.</param>
        /// <param name="winDescender">The value for the <see cref="WindowsDescender" /> property.</param>
        /// <param name="codePages">The value for the <see cref="CodePages" /> property.</param>
        /// <param name="height">The value for the <see cref="XHeight" /> property.</param>
        /// <param name="capHeight">The value for the <see cref="CapHeight" /> property.</param>
        /// <param name="defaultChar">The value for the <see cref="DefaultChar" /> property.</param>
        /// <param name="breakChar">The value for the <see cref="BreakChar" /> property.</param>
        /// <param name="maxContext">The value for the <see cref="MaxContext" /> property.</param>
        /// <param name="lowerOpticalPointSize">The value for the <see cref="LowerOpticalPointSize" /> property.</param>
        /// <param name="upperOpticalPointSize">The value for the <see cref="UpperOpticalPointSize" /> property.</param>
        public OS2MetricsTable(short avgCharWidth, int weightClass, int widthClass, EmbeddingPermissions permissions, short subscriptXSize, short subscriptYSize, 
            short subscriptXOffset, short subscriptYOffset, short superscriptXSize, short superscriptYSize, short superscriptXOffset, short superscriptYOffset, 
            short strikeoutSize, short strikeoutPosition, IBMFamily ibmFamily, PanoseFamily panoseFamily, UnicodeRanges unicodeRanges, Tag vendorId, 
            OS2StyleProperties fontSelection, int minCodePoint, int maxCodePoint, short ascender, short descender, short lineGap, int winAscender, int winDescender, 
            SupportedCodePages codePages, short height, short capHeight, int defaultChar, int breakChar, int maxContext, int lowerOpticalPointSize, 
            int upperOpticalPointSize) 
            : this(5, avgCharWidth, weightClass, widthClass, permissions, subscriptXSize, subscriptYSize, subscriptXOffset, subscriptYOffset, superscriptXSize,
                  superscriptYSize, superscriptXOffset, superscriptYOffset, strikeoutSize, strikeoutPosition, ibmFamily, panoseFamily, unicodeRanges, vendorId, 
                  fontSelection, minCodePoint, maxCodePoint, ascender, descender, lineGap, winAscender, winDescender, codePages, height, capHeight, defaultChar, 
                  breakChar, maxContext)
        {
            FieldValidation.ValidateUShortParameter(lowerOpticalPointSize, nameof(lowerOpticalPointSize));
            FieldValidation.ValidateUShortParameter(upperOpticalPointSize, nameof(upperOpticalPointSize));

            LowerOpticalPointSize = lowerOpticalPointSize;
            UpperOpticalPointSize = upperOpticalPointSize;
        }

        /// <summary>
        /// Constructor for versions 2 to 4 inclusive.
        /// </summary>
        /// <param name="version">The value for the <see cref="Version" /> property.</param>
        /// <param name="avgCharWidth">The value for the <see cref="AverageCharWidth" /> property.</param>
        /// <param name="weightClass">The value for the <see cref="WeightClass" /> property.</param>
        /// <param name="widthClass">The value for the <see cref="WidthClass" /> property.</param>
        /// <param name="permissions">The value for the <see cref="EmbeddingPermissions" /> property.</param>
        /// <param name="subscriptXSize">The value for the <see cref="SubscriptXSize" /> property.</param>
        /// <param name="subscriptYSize">The value for the <see cref="SubscriptYSize" /> property.</param>
        /// <param name="subscriptXOffset">The value for the <see cref="SubscriptXOffset" /> property.</param>
        /// <param name="subscriptYOffset">The value for the <see cref="SubscriptYOffset" /> property.</param>
        /// <param name="superscriptXSize">The value for the <see cref="SuperscriptXSize" /> property.</param>
        /// <param name="superscriptYSize">The value for the <see cref="SuperscriptYSize" /> property.</param>
        /// <param name="superscriptXOffset">The value for the <see cref="SuperscriptXOffset" /> property.</param>
        /// <param name="superscriptYOffset">The value for the <see cref="SuperscriptYOffset" /> property.</param>
        /// <param name="strikeoutSize">The value for the <see cref="StrikeoutSize" /> property.</param>
        /// <param name="strikeoutPosition">The value for the <see cref="StrikeoutPosition" /> property.</param>
        /// <param name="ibmFamily">The value for the <see cref="IBMFontFamily" /> property.</param>
        /// <param name="panoseFamily">The value for the <see cref="PanoseFontFamily" /> property.</param>
        /// <param name="unicodeRanges">The value for the <see cref="UnicodeRanges" /> property.</param>
        /// <param name="vendorId">The value for the <see cref="VendorId" /> property.</param>
        /// <param name="fontSelection">The value for the <see cref="FontSelection" /> property.</param>
        /// <param name="minCodePoint">The value for the <see cref="MinCodePoint" /> property.</param>
        /// <param name="maxCodePoint">The value for the <see cref="MaxCodePoint" /> property.</param>
        /// <param name="ascender">The value for the <see cref="Ascender" /> property.</param>
        /// <param name="descender">The value for the <see cref="Descender" /> property.</param>
        /// <param name="lineGap">The value for the <see cref="LineGap" /> property.</param>
        /// <param name="winAscender">The value for the <see cref="WindowsAscender" /> property.</param>
        /// <param name="winDescender">The value for the <see cref="WindowsDescender" /> property.</param>
        /// <param name="codePages">The value for the <see cref="CodePages" /> property.</param>
        /// <param name="height">The value for the <see cref="XHeight" /> property.</param>
        /// <param name="capHeight">The value for the <see cref="CapHeight" /> property.</param>
        /// <param name="defaultChar">The value for the <see cref="DefaultChar" /> property.</param>
        /// <param name="breakChar">The value for the <see cref="BreakChar" /> property.</param>
        /// <param name="maxContext">The value for the <see cref="MaxContext" /> property.</param>
        public OS2MetricsTable(int version, short avgCharWidth, int weightClass, int widthClass, EmbeddingPermissions permissions, short subscriptXSize,
            short subscriptYSize, short subscriptXOffset, short subscriptYOffset, short superscriptXSize, short superscriptYSize, short superscriptXOffset,
            short superscriptYOffset, short strikeoutSize, short strikeoutPosition, IBMFamily ibmFamily, PanoseFamily panoseFamily, UnicodeRanges unicodeRanges, 
            Tag vendorId, OS2StyleProperties fontSelection, int minCodePoint, int maxCodePoint, short ascender, short descender, short lineGap, int winAscender, 
            int winDescender, SupportedCodePages codePages, short height, short capHeight, int defaultChar, int breakChar, int maxContext)
            : this(avgCharWidth, weightClass, widthClass, permissions, subscriptXSize, subscriptYSize, subscriptXOffset, subscriptYOffset, superscriptXSize,
                  superscriptYSize, superscriptXOffset, superscriptYOffset, strikeoutSize, strikeoutPosition, ibmFamily, panoseFamily, unicodeRanges, vendorId, 
                  fontSelection, minCodePoint, maxCodePoint, ascender, descender, lineGap, winAscender, winDescender, codePages)
        {
            FieldValidation.ValidateUShortParameter(version, nameof(version));
            FieldValidation.ValidateUShortParameter(defaultChar, nameof(defaultChar));
            FieldValidation.ValidateUShortParameter(breakChar, nameof(breakChar));
            FieldValidation.ValidateUShortParameter(maxContext, nameof(maxContext));

            Version = version;
            XHeight = height;
            CapHeight = capHeight;
            DefaultChar = defaultChar;
            BreakChar = breakChar;
            MaxContext = maxContext;
        }

        /// <summary>
        /// Constructor for version 1.
        /// </summary>
        /// <param name="avgCharWidth">The value for the <see cref="AverageCharWidth" /> property.</param>
        /// <param name="weightClass">The value for the <see cref="WeightClass" /> property.</param>
        /// <param name="widthClass">The value for the <see cref="WidthClass" /> property.</param>
        /// <param name="permissions">The value for the <see cref="EmbeddingPermissions" /> property.</param>
        /// <param name="subscriptXSize">The value for the <see cref="SubscriptXSize" /> property.</param>
        /// <param name="subscriptYSize">The value for the <see cref="SubscriptYSize" /> property.</param>
        /// <param name="subscriptXOffset">The value for the <see cref="SubscriptXOffset" /> property.</param>
        /// <param name="subscriptYOffset">The value for the <see cref="SubscriptYOffset" /> property.</param>
        /// <param name="superscriptXSize">The value for the <see cref="SuperscriptXSize" /> property.</param>
        /// <param name="superscriptYSize">The value for the <see cref="SuperscriptYSize" /> property.</param>
        /// <param name="superscriptXOffset">The value for the <see cref="SuperscriptXOffset" /> property.</param>
        /// <param name="superscriptYOffset">The value for the <see cref="SuperscriptYOffset" /> property.</param>
        /// <param name="strikeoutSize">The value for the <see cref="StrikeoutSize" /> property.</param>
        /// <param name="strikeoutPosition">The value for the <see cref="StrikeoutPosition" /> property.</param>
        /// <param name="ibmFamily">The value for the <see cref="IBMFontFamily" /> property.</param>
        /// <param name="panoseFamily">The value for the <see cref="PanoseFontFamily" /> property.</param>
        /// <param name="unicodeRanges">The value for the <see cref="UnicodeRanges" /> property.</param>
        /// <param name="vendorId">The value for the <see cref="VendorId" /> property.</param>
        /// <param name="fontSelection">The value for the <see cref="FontSelection" /> property.</param>
        /// <param name="minCodePoint">The value for the <see cref="MinCodePoint" /> property.</param>
        /// <param name="maxCodePoint">The value for the <see cref="MaxCodePoint" /> property.</param>
        /// <param name="ascender">The value for the <see cref="Ascender" /> property.</param>
        /// <param name="descender">The value for the <see cref="Descender" /> property.</param>
        /// <param name="lineGap">The value for the <see cref="LineGap" /> property.</param>
        /// <param name="winAscender">The value for the <see cref="WindowsAscender" /> property.</param>
        /// <param name="winDescender">The value for the <see cref="WindowsDescender" /> property.</param>
        /// <param name="codePages">The value for the <see cref="CodePages" /> property.</param>
        public OS2MetricsTable(short avgCharWidth, int weightClass, int widthClass, EmbeddingPermissions permissions, short subscriptXSize, short subscriptYSize, 
            short subscriptXOffset, short subscriptYOffset, short superscriptXSize, short superscriptYSize, short superscriptXOffset, short superscriptYOffset, 
            short strikeoutSize, short strikeoutPosition, IBMFamily ibmFamily, PanoseFamily panoseFamily, UnicodeRanges unicodeRanges, Tag vendorId, 
            OS2StyleProperties fontSelection, int minCodePoint, int maxCodePoint, short ascender, short descender,
            short lineGap, int winAscender, int winDescender, SupportedCodePages codePages)
            : this(avgCharWidth, weightClass, widthClass, permissions, subscriptXSize, subscriptYSize, subscriptXOffset, subscriptYOffset, superscriptXSize,
                  superscriptYSize, superscriptXOffset, superscriptYOffset, strikeoutSize, strikeoutPosition, ibmFamily, panoseFamily, unicodeRanges, vendorId, 
                  fontSelection, minCodePoint, maxCodePoint, ascender, descender, lineGap, winAscender, winDescender)
        {
            Version = 1;
            CodePages = codePages;
        }

        /// <summary>
        /// Constructor for Version 0 (Microsoft Variant).
        /// </summary>
        /// <param name="avgCharWidth">The value for the <see cref="AverageCharWidth" /> property.</param>
        /// <param name="weightClass">The value for the <see cref="WeightClass" /> property.</param>
        /// <param name="widthClass">The value for the <see cref="WidthClass" /> property.</param>
        /// <param name="permissions">The value for the <see cref="EmbeddingPermissions" /> property.</param>
        /// <param name="subscriptXSize">The value for the <see cref="SubscriptXSize" /> property.</param>
        /// <param name="subscriptYSize">The value for the <see cref="SubscriptYSize" /> property.</param>
        /// <param name="subscriptXOffset">The value for the <see cref="SubscriptXOffset" /> property.</param>
        /// <param name="subscriptYOffset">The value for the <see cref="SubscriptYOffset" /> property.</param>
        /// <param name="superscriptXSize">The value for the <see cref="SuperscriptXSize" /> property.</param>
        /// <param name="superscriptYSize">The value for the <see cref="SuperscriptYSize" /> property.</param>
        /// <param name="superscriptXOffset">The value for the <see cref="SuperscriptXOffset" /> property.</param>
        /// <param name="superscriptYOffset">The value for the <see cref="SuperscriptYOffset" /> property.</param>
        /// <param name="strikeoutSize">The value for the <see cref="StrikeoutSize" /> property.</param>
        /// <param name="strikeoutPosition">The value for the <see cref="StrikeoutPosition" /> property.</param>
        /// <param name="ibmFamily">The value for the <see cref="IBMFontFamily" /> property.</param>
        /// <param name="panoseFamily">The value for the <see cref="PanoseFontFamily" /> property.</param>
        /// <param name="unicodeRanges">The value for the <see cref="UnicodeRanges" /> property.</param>
        /// <param name="vendorId">The value for the <see cref="VendorId" /> property.</param>
        /// <param name="fontSelection">The value for the <see cref="FontSelection" /> property.</param>
        /// <param name="minCodePoint">The value for the <see cref="MinCodePoint" /> property.</param>
        /// <param name="maxCodePoint">The value for the <see cref="MaxCodePoint" /> property.</param>
        /// <param name="ascender">The value for the <see cref="Ascender" /> property.</param>
        /// <param name="descender">The value for the <see cref="Descender" /> property.</param>
        /// <param name="lineGap">The value for the <see cref="LineGap" /> property.</param>
        /// <param name="winAscender">The value for the <see cref="WindowsAscender" /> property.</param>
        /// <param name="winDescender">The value for the <see cref="WindowsDescender" /> property.</param>
        public OS2MetricsTable(short avgCharWidth, int weightClass, int widthClass, EmbeddingPermissions permissions, short subscriptXSize, short subscriptYSize, 
            short subscriptXOffset, short subscriptYOffset, short superscriptXSize, short superscriptYSize, short superscriptXOffset, short superscriptYOffset, 
            short strikeoutSize, short strikeoutPosition, IBMFamily ibmFamily, PanoseFamily panoseFamily, UnicodeRanges unicodeRanges, Tag vendorId, 
            OS2StyleProperties fontSelection, int minCodePoint, int maxCodePoint, short ascender, short descender,
            short lineGap, int winAscender, int winDescender)
            : this(avgCharWidth, weightClass, widthClass, permissions, subscriptXSize, subscriptYSize, subscriptXOffset, subscriptYOffset, superscriptXSize,
                  superscriptYSize, superscriptXOffset, superscriptYOffset, strikeoutSize, strikeoutPosition, ibmFamily, panoseFamily, unicodeRanges, vendorId, 
                  fontSelection, minCodePoint, maxCodePoint)
        {
            FieldValidation.ValidateUShortParameter(winAscender, nameof(winAscender));
            FieldValidation.ValidateUShortParameter(winDescender, nameof(winDescender));

            Ascender = ascender;
            Descender = descender;
            LineGap = lineGap;
            WindowsAscender = winAscender;
            WindowsDescender = winDescender;
        }

        /// <summary>
        /// Constructor for Version 0 (Apple Variant).
        /// </summary>
        /// <param name="avgCharWidth">The value for the <see cref="AverageCharWidth" /> property.</param>
        /// <param name="weightClass">The value for the <see cref="WeightClass" /> property.</param>
        /// <param name="widthClass">The value for the <see cref="WidthClass" /> property.</param>
        /// <param name="permissions">The value for the <see cref="EmbeddingPermissions" /> property.</param>
        /// <param name="subscriptXSize">The value for the <see cref="SubscriptXSize" /> property.</param>
        /// <param name="subscriptYSize">The value for the <see cref="SubscriptYSize" /> property.</param>
        /// <param name="subscriptXOffset">The value for the <see cref="SubscriptXOffset" /> property.</param>
        /// <param name="subscriptYOffset">The value for the <see cref="SubscriptYOffset" /> property.</param>
        /// <param name="superscriptXSize">The value for the <see cref="SuperscriptXSize" /> property.</param>
        /// <param name="superscriptYSize">The value for the <see cref="SuperscriptYSize" /> property.</param>
        /// <param name="superscriptXOffset">The value for the <see cref="SuperscriptXOffset" /> property.</param>
        /// <param name="superscriptYOffset">The value for the <see cref="SuperscriptYOffset" /> property.</param>
        /// <param name="strikeoutSize">The value for the <see cref="StrikeoutSize" /> property.</param>
        /// <param name="strikeoutPosition">The value for the <see cref="StrikeoutPosition" /> property.</param>
        /// <param name="ibmFamily">The value for the <see cref="IBMFontFamily" /> property.</param>
        /// <param name="panoseFamily">The value for the <see cref="PanoseFontFamily" /> property.</param>
        /// <param name="unicodeRanges">The value for the <see cref="UnicodeRanges" /> property.</param>
        /// <param name="vendorId">The value for the <see cref="VendorId" /> property.</param>
        /// <param name="fontSelection">The value for the <see cref="FontSelection" /> property.</param>
        /// <param name="minCodePoint">The value for the <see cref="MinCodePoint" /> property.</param>
        /// <param name="maxCodePoint">The value for the <see cref="MaxCodePoint" /> property.</param>
        public OS2MetricsTable(short avgCharWidth, int weightClass, int widthClass, EmbeddingPermissions permissions, short subscriptXSize, short subscriptYSize, 
            short subscriptXOffset, short subscriptYOffset, short superscriptXSize, short superscriptYSize, short superscriptXOffset, short superscriptYOffset, 
            short strikeoutSize, short strikeoutPosition, IBMFamily ibmFamily, PanoseFamily panoseFamily, UnicodeRanges unicodeRanges, Tag vendorId, 
            OS2StyleProperties fontSelection, int minCodePoint, int maxCodePoint)
            : base("OS/2")
        {
            FieldValidation.ValidateUShortParameter(weightClass, nameof(weightClass));
            FieldValidation.ValidateUShortParameter(widthClass, nameof(widthClass));
            FieldValidation.ValidateUShortParameter(minCodePoint, nameof(minCodePoint));
            FieldValidation.ValidateUShortParameter(maxCodePoint, nameof(maxCodePoint));

            Version = 0;
            AverageCharWidth = avgCharWidth;
            WeightClass = weightClass;
            WidthClass = widthClass;
            EmbeddingPermissions = permissions;
            SubscriptXSize = subscriptXSize;
            SubscriptXOffset = subscriptXOffset;
            SubscriptYSize = subscriptYSize;
            SubscriptYOffset = subscriptYOffset;
            SuperscriptXSize = superscriptXSize;
            SuperscriptXOffset = superscriptXOffset;
            SuperscriptYSize = superscriptYSize;
            SuperscriptYOffset = superscriptYOffset;
            StrikeoutSize = strikeoutSize;
            StrikeoutPosition = strikeoutPosition;
            IBMFontFamily = ibmFamily;
            PanoseFontFamily = panoseFamily;
            UnicodeRanges = unicodeRanges;
            VendorId = vendorId;
            FontSelection = fontSelection;
            MinCodePoint = minCodePoint;
            MaxCodePoint = maxCodePoint;
        }

        /// <summary>
        /// Load an <see cref="OS2MetricsTable"/> instance from an array of bytes.
        /// </summary>
        /// <param name="arr">The data array.</param>
        /// <param name="offset">The position of the start of the table within the array.</param>
        /// <param name="len">The length of the data making up the table.</param>
        /// <returns>An <see cref="OS2MetricsTable" /> instance consisting of the data loaded from the table.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>arr</c> parameter is <c>null</c>.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown if the <c>offset</c> parameter is negative.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the length of the <c>arr</c> parameter is less than the sum of the other two parameters.</exception>
        public static OS2MetricsTable FromBytes(byte[] arr, int offset, int len)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            FieldValidation.ValidateNonNegativeIntegerParameter(len, nameof(len));
            ushort version = arr.ToUShort(offset);
            switch (version)
            {
                case 5:
                    return FromBytesV5(arr, offset);
                case 4:
                case 3:
                case 2:
                    return FromBytesV4(arr, offset, version);
                case 1:
                    return FromBytesV1(arr, offset);
                case 0:
                    return FromBytesV0(arr, offset, len);
                default:
                    throw new OpenTypeFormatException($"Unknown OS/2 table version number {version}.");
            }
        }

        private static OS2MetricsTable FromBytesV5(byte[] arr, int offset) => new OS2MetricsTable(
                arr.ToShort(offset + 2),
                arr.ToUShort(offset + 4),
                arr.ToUShort(offset + 6),
                (EmbeddingPermissions)arr.ToUShort(offset + 8),
                arr.ToShort(offset + 10),
                arr.ToShort(offset + 12),
                arr.ToShort(offset + 14),
                arr.ToShort(offset + 16),
                arr.ToShort(offset + 18),
                arr.ToShort(offset + 20),
                arr.ToShort(offset + 22),
                arr.ToShort(offset + 24),
                arr.ToShort(offset + 26),
                arr.ToShort(offset + 28),
                (IBMFamily)arr.ToShort(offset + 30),
                new PanoseFamily(arr, offset + 32),
                UnicodeRanges.FromBytes(arr, offset + 42),
                new Tag(arr, offset + 58),
                (OS2StyleProperties)arr.ToUShort(offset + 62),
                arr.ToUShort(offset + 64),
                arr.ToUShort(offset + 66),
                arr.ToShort(offset + 68),
                arr.ToShort(offset + 70),
                arr.ToShort(offset + 72),
                arr.ToUShort(offset + 74),
                arr.ToUShort(offset + 76),
                SupportedCodePages.FromBytes(arr, offset + 78),
                arr.ToShort(offset + 86),
                arr.ToShort(offset + 88),
                arr.ToUShort(offset + 90),
                arr.ToUShort(offset + 92),
                arr.ToUShort(offset + 94),
                arr.ToUShort(offset + 96),
                arr.ToUShort(offset + 98));

        private static OS2MetricsTable FromBytesV4(byte[] arr, int offset, ushort version) => new OS2MetricsTable(
                version,
                arr.ToShort(offset + 2),
                arr.ToUShort(offset + 4),
                arr.ToUShort(offset + 6),
                (EmbeddingPermissions)arr.ToUShort(offset + 8),
                arr.ToShort(offset + 10),
                arr.ToShort(offset + 12),
                arr.ToShort(offset + 14),
                arr.ToShort(offset + 16),
                arr.ToShort(offset + 18),
                arr.ToShort(offset + 20),
                arr.ToShort(offset + 22),
                arr.ToShort(offset + 24),
                arr.ToShort(offset + 26),
                arr.ToShort(offset + 28),
                (IBMFamily)arr.ToShort(offset + 30),
                new PanoseFamily(arr, offset + 32),
                UnicodeRanges.FromBytes(arr, offset + 42),
                new Tag(arr, offset + 58),
                (OS2StyleProperties)arr.ToUShort(offset + 62),
                arr.ToUShort(offset + 64),
                arr.ToUShort(offset + 66),
                arr.ToShort(offset + 68),
                arr.ToShort(offset + 70),
                arr.ToShort(offset + 72),
                arr.ToUShort(offset + 74),
                arr.ToUShort(offset + 76),
                SupportedCodePages.FromBytes(arr, offset + 78),
                arr.ToShort(offset + 86),
                arr.ToShort(offset + 88),
                arr.ToUShort(offset + 90),
                arr.ToUShort(offset + 92),
                arr.ToUShort(offset + 94));

        private static OS2MetricsTable FromBytesV1(byte[] arr, int offset) => new OS2MetricsTable(
                arr.ToShort(offset + 2),
                arr.ToUShort(offset + 4),
                arr.ToUShort(offset + 6),
                (EmbeddingPermissions)arr.ToUShort(offset + 8),
                arr.ToShort(offset + 10),
                arr.ToShort(offset + 12),
                arr.ToShort(offset + 14),
                arr.ToShort(offset + 16),
                arr.ToShort(offset + 18),
                arr.ToShort(offset + 20),
                arr.ToShort(offset + 22),
                arr.ToShort(offset + 24),
                arr.ToShort(offset + 26),
                arr.ToShort(offset + 28),
                (IBMFamily)arr.ToShort(offset + 30),
                new PanoseFamily(arr, offset + 32),
                UnicodeRanges.FromBytes(arr, offset + 42),
                new Tag(arr, offset + 58),
                (OS2StyleProperties)arr.ToUShort(offset + 62),
                arr.ToUShort(offset + 64),
                arr.ToUShort(offset + 66),
                arr.ToShort(offset + 68),
                arr.ToShort(offset + 70),
                arr.ToShort(offset + 72),
                arr.ToUShort(offset + 74),
                arr.ToUShort(offset + 76),
                SupportedCodePages.FromBytes(arr, offset + 78));

        private static OS2MetricsTable FromBytesV0(byte[] arr, int offset, long len)
        {
            if (len >= 78)
            {
                return new OS2MetricsTable(
                    arr.ToShort(offset + 2),
                    arr.ToUShort(offset + 4),
                    arr.ToUShort(offset + 6),
                    (EmbeddingPermissions)arr.ToUShort(offset + 8),
                    arr.ToShort(offset + 10),
                    arr.ToShort(offset + 12),
                    arr.ToShort(offset + 14),
                    arr.ToShort(offset + 16),
                    arr.ToShort(offset + 18),
                    arr.ToShort(offset + 20),
                    arr.ToShort(offset + 22),
                    arr.ToShort(offset + 24),
                    arr.ToShort(offset + 26),
                    arr.ToShort(offset + 28),
                    (IBMFamily)arr.ToShort(offset + 30),
                    new PanoseFamily(arr, offset + 32),
                    UnicodeRanges.FromBytes(arr, offset + 42),
                    new Tag(arr, offset + 58),
                    (OS2StyleProperties)arr.ToUShort(offset + 62),
                    arr.ToUShort(offset + 64),
                    arr.ToUShort(offset + 66),
                    arr.ToShort(offset + 68),
                    arr.ToShort(offset + 70),
                    arr.ToShort(offset + 72),
                    arr.ToUShort(offset + 74),
                    arr.ToUShort(offset + 76));
            }
            return new OS2MetricsTable(
                arr.ToShort(offset + 2),
                arr.ToUShort(offset + 4),
                arr.ToUShort(offset + 6),
                (EmbeddingPermissions)arr.ToUShort(offset + 8),
                arr.ToShort(offset + 10),
                arr.ToShort(offset + 12),
                arr.ToShort(offset + 14),
                arr.ToShort(offset + 16),
                arr.ToShort(offset + 18),
                arr.ToShort(offset + 20),
                arr.ToShort(offset + 22),
                arr.ToShort(offset + 24),
                arr.ToShort(offset + 26),
                arr.ToShort(offset + 28),
                (IBMFamily)arr.ToShort(offset + 30),
                new PanoseFamily(arr, offset + 32),
                UnicodeRanges.FromBytes(arr, offset + 42),
                new Tag(arr, offset + 58),
                (OS2StyleProperties)arr.ToUShort(offset + 62),
                arr.ToUShort(offset + 64),
                arr.ToUShort(offset + 66));
        }

        /// <summary>
        /// Dump this table to a <see cref="TextWriter" />.  Returns silently if the parameter is <c>null</c>.
        /// </summary>
        /// <param name="writer">The writer to dump the table to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine("OS/2 table contents:");
            writer.WriteLine("Field                 | Value");
            writer.WriteLine("----------------------|------------------------");
            writer.WriteLine($"Version               | {Version}");
            writer.WriteLine($"AverageCharWidth      | {AverageCharWidth}");
            writer.WriteLine($"WeightClass           | {WeightClass}");
            writer.WriteLine($"WidthClass            | {WidthClass}");
            writer.WriteLine($"EmbeddingPermissions  | {EmbeddingPermissions}");
            writer.WriteLine($"SubscriptXSize        | {SubscriptXSize}");
            writer.WriteLine($"SubscriptYSize        | {SubscriptYSize}");
            writer.WriteLine($"SubscriptXOffset      | {SubscriptXOffset}");
            writer.WriteLine($"SubscriptYOffset      | {SubscriptYOffset}");
            writer.WriteLine($"SuperscriptXSize      | {SuperscriptXSize}");
            writer.WriteLine($"SuperscriptYSize      | {SuperscriptYSize}");
            writer.WriteLine($"SuperscriptXOffset    | {SuperscriptXOffset}");
            writer.WriteLine($"SuperscriptYOffset    | {SuperscriptYOffset}");
            writer.WriteLine($"StrikeoutSize         | {StrikeoutSize}");
            writer.WriteLine($"StrikeoutPosition     | {StrikeoutPosition}");
            writer.WriteLine($"IBMFontFamily         | {IBMFontFamily}");
            writer.WriteLine($"PanoseFontFamily      | {PanoseFontFamily}");
            writer.WriteLine($"UnicodeRanges         | {UnicodeRanges}");
            writer.WriteLine($"VendorId              | {VendorId}");
            writer.WriteLine($"FontSelection         | {FontSelection}");
            writer.WriteLine($"MinCodePoint          | {MinCodePoint}");
            writer.WriteLine($"MaxCodePoint          | {MaxCodePoint}");
            writer.WriteLine($"Ascender              | {Ascender}");
            writer.WriteLine($"Descender             | {Descender}");
            writer.WriteLine($"LineGap               | {LineGap}");
            writer.WriteLine($"WindowsAscender       | {WindowsAscender}");
            writer.WriteLine($"WindowsDescender      | {WindowsDescender}");
            if (Version >= 1)
            {
                writer.WriteLine($"CodePages             | {CodePages}");
            }
            if (Version >= 2)
            {
                writer.WriteLine($"Height                | {XHeight}");
                writer.WriteLine($"CapHeight             | {CapHeight}");
                writer.WriteLine($"DefaultChar           | {DefaultChar}");
                writer.WriteLine($"BreakChar             | {BreakChar}");
                writer.WriteLine($"MaxContext            | {MaxContext}");
            }
            if (Version >= 5)
            {
                writer.WriteLine($"UpperOpticalPointSize | {UpperOpticalPointSize}");
                writer.WriteLine($"LowerOpticalPointSize | {LowerOpticalPointSize}");
            }
        }
    }
}
