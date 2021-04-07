namespace Unicorn.Base
{
    /// <summary>
    /// Describes the various kinds of font program formats that are generally understood by PDF viewers.
    /// </summary>
    public enum FontImplementation
    {
        /// <summary>
        /// The subset of Type 1 fonts that all PDF viewers are expected to implement, without the fonts having to be embedded in the PDF file or 
        /// installed on the device.
        /// </summary>
        StandardType1,

        /// <summary>
        /// Type 1 fonts not included in the set of 14 standard PDF fonts.
        /// </summary>
        Type1,

        /// <summary>
        /// OpenType and/or TrueType fonts.
        /// </summary>
        OpenType,

        /// <summary>
        /// Other font types (provided for future extension).
        /// </summary>
        Other
    }
}
