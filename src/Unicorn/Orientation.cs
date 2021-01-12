namespace Unicorn
{
    /// <summary>
    /// The orientation of an object on the page.
    /// </summary>
    public enum Orientation
    {
        /// <summary>
        /// The default orientation.
        /// </summary>
        Normal,

        /// <summary>
        /// The object is rotated clockwise 90 degrees, so that text in a left-to-right language will read from top to bottom.
        /// </summary>
        RotatedRight,

        /// <summary>
        /// The object is rotated anticlockwise 90 degrees, so that text in a left-to-right language will read from bottom to top.
        /// </summary>
        RotatedLeft,

        /// <summary>
        /// The object is rotated 180 degrees.
        /// </summary>
        UpsideDown,

        /// <summary>
        /// The object is rotated by an arbitrary amount.
        /// </summary>
        Freestyle,
    }
}
