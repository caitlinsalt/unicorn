namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The type of an OpenType font, as per its magic number.  This determines which tables need to be present in order for the font to be valid.
    /// </summary>
    public enum FontKind
    {
        /// <summary>
        /// TrueType.
        /// </summary>
        TrueType,

        /// <summary>
        /// Compact Font Format.
        /// </summary>
        Cff
    }
}
