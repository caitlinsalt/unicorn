namespace Unicorn
{
    /// <summary>
    /// Data describing the margins around a block.
    /// </summary>
    public class MarginSet
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MarginSet()
        {
        }

        /// <summary>
        /// Constructor with initial property values.
        /// </summary>
        /// <param name="top">Top margin size.</param>
        /// <param name="right">Right margin size.</param>
        /// <param name="bottom">Bottom margin size.</param>
        /// <param name="left">Left margin size.</param>
        public MarginSet(double top, double right, double bottom, double left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        /// <summary>
        /// Constructor which sets all four margins to the same width.
        /// </summary>
        /// <param name="margin">The width of the margin on all four sides.</param>
        public MarginSet(double margin) : this(margin, margin, margin, margin)
        {
        }

        /// <summary>
        /// Left margin size.
        /// </summary>
        public double Left { get; set; }

        /// <summary>
        /// Right margin size.
        /// </summary>
        public double Right { get; set; }

        /// <summary>
        /// Top margin size.
        /// </summary>
        public double Top { get; set; }

        /// <summary>
        /// Bottom margin size.
        /// </summary>
        public double Bottom { get; set; }
    }
}
