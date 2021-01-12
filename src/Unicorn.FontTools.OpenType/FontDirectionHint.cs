namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Value that indicates typical directionality of a font's characters.  Generally deprecated.
    /// </summary>
    public enum FontDirectionHint
    {
        /// <summary>
        /// Mixed direction font.
        /// </summary>
        MixedDirection = 0,

        /// <summary>
        /// Font only contains left-to-right characters.
        /// </summary>
        LeftToRight = 1,

        /// <summary>
        /// Font contains left-to-right characters, and also neutral characters (such as space or punctuation)
        /// </summary>
        NeutralOrLeftToRight = 2,

        /// <summary>
        /// Font only contains right-to-left characters.
        /// </summary>
        RightToLeft = -1,

        /// <summary>
        /// Font contains right-to-left characters and neutral characters.
        /// </summary>
        NeutralOrRightToLeft = -2,
    }
}
