namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The "platform ID" values used to identify the applicability of platform-specific data in an OpenType font.
    /// </summary>
    public enum PlatformId
    {
        /// <summary>
        /// The generic "Unicode" platform.
        /// </summary>
        Unicode= 0,

        /// <summary>
        /// Apple Macintosh systems.
        /// </summary>
        Macintosh = 1,

        /// <summary>
        /// Microsoft Windows systems.
        /// </summary>
        Windows = 3,

        /// <summary>
        /// Used in some fonts for Windows NT compatibility purposes.
        /// </summary>
        Custom = 4,
    }
}
