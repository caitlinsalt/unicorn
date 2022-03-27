namespace Unicorn.FontTools.OpenType
{

#pragma warning disable CA1027 // Mark enums with FlagsAttribute - false positive in this case.

    /// <summary>
    /// The predefined fields that can exist in a 'name' table.
    /// </summary>
    public enum NameField
    {
        /// <summary>
        /// Legal copyright notice.
        /// </summary>
        CopyrightNotice = 0,

        /// <summary>
        /// Font family name.
        /// </summary>
        Family = 1,

        /// <summary>
        /// Font subfamily name.
        /// </summary>
        Subfamily = 2,

        /// <summary>
        /// Font unique ID.
        /// </summary>
        UniqueID = 3,

        /// <summary>
        /// Font full name.
        /// </summary>
        FullName = 4,

        /// <summary>
        /// Version number.
        /// </summary>
        Version = 5,

        /// <summary>
        /// Name used to refer to the font in PostScript.
        /// </summary>
        PostScriptName = 6,

        /// <summary>
        /// Trademark notice.
        /// </summary>
        TrademarkNotice = 7,

        /// <summary>
        /// Manufacturer's name.
        /// </summary>
        Manufacturer = 8,

        /// <summary>
        /// Designer's name.
        /// </summary>
        Designer = 9,

        /// <summary>
        /// Description of the font.
        /// </summary>
        Description = 10,

        /// <summary>
        /// URI of the font vendor.
        /// </summary>
        VendorURI = 11,

        /// <summary>
        /// URI of the font designer.
        /// </summary>
        DesignerURI = 12,

        /// <summary>
        /// Font licensing information.
        /// </summary>
        LicenceDescription = 13,

        /// <summary>
        /// URI of the definitive text of the licence.
        /// </summary>
        LicenceURI = 14,

        /// <summary>
        /// Family name (freeform).
        /// </summary>
        TypographicFamily = 16,

        /// <summary>
        /// Subfamily name (freeform).
        /// </summary>
        TypographicSubfamily = 17,

        /// <summary>
        /// Label used for this font in Apple Mac font selection menus.
        /// </summary>
        MacintoshMenuName = 18,

        /// <summary>
        /// A sample string that shows this font's features off to best effect.
        /// </summary>
        SampleText = 19,

        /// <summary>
        /// If this name is provided, this name is used by the PostScript "findfont" function and the PostScriptName field is used by the 
        /// PostScript "composefont" function.
        /// </summary>
        PostScriptCIDName = 20,

        /// <summary>
        /// Family name in a form compatible with the weight-width-stroke naming model.
        /// </summary>
        WWSFamilyName = 21,

        /// <summary>
        /// Subfamily name in a form compatible with the weight-width-stroke naming model.
        /// </summary>
        WWSSubfamilyName = 22,

        /// <summary>
        /// UI string associated with the palette flagged in the 'CPAL' table as the Light Background Palette, should the font have it.
        /// </summary>
        LightBackgroundPalette = 23,

        /// <summary>
        /// UI string associated with the palette flagged in the 'CPAL' table as the Dark Background Palette, should the font have it.
        /// </summary>
        DarkBackgroundPalette = 24,

        /// <summary>
        /// For variable fonts, this is used as the family name prefix by the PostScript name generation algorithm.
        /// </summary>
        PostScriptFamilyPrefix = 25
    }

#pragma warning restore CA1027 // Mark enums with FlagsAttribute

}
