using System;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Flags used by the <see cref="OS2MetricsTable.FontSelection" /> field to advertise properties of this font, such as italic, bold, etc.
    /// </summary>
    [Flags]
    public enum OS2StyleProperties
    {
        /// <summary>
        /// Font is italic.
        /// </summary>
        Italic = 1,

        /// <summary>
        /// Font has an underscore.
        /// </summary>
        Underscore = 2,

        /// <summary>
        /// Font is negative (white on black).
        /// </summary>
        Negative = 4,

        /// <summary>
        /// Font has outlined letterforms.
        /// </summary>
        Outlined = 8,

        /// <summary>
        /// Font has a strikethrough.
        /// </summary>
        Strikeout = 16,

        /// <summary>
        /// Font is boldface.
        /// </summary>
        Bold = 32,

        /// <summary>
        /// Font is regular weight.
        /// </summary>
        Regular = 64,

        /// <summary>
        /// Applications should always compute line spacing using the properties of the <see cref="OS2MetricsTable" />.
        /// </summary>
        UseOS2LineGapMetrics = 128,

        /// <summary>
        /// Font's name follows a consistent naming scheme using the "weight-width-slope" model.  Entries in the 'name' table with IDs 21 and 22 should be ignored.
        /// </summary>
        ConsistentNamingSceheme = 256,

        /// <summary>
        /// Font is oblique.
        /// </summary>
        Oblique = 512,
    }
}
