namespace Unicorn.CoreTypes
{
    /// <summary>
    /// Describes a page within a document.
    /// </summary>
    public interface IPageDescriptor
    {
        /// <summary>
        /// The graphics context for carrying out low level drawing operations to this page.
        /// </summary>
        IGraphicsContext PageGraphics { get; }

        /// <summary>
        /// The vertical coordinate of the top margin edge.
        /// </summary>
        double TopMarginPosition { get; }

        /// <summary>
        /// The vertical coordinate of the bottom margin edge.
        /// </summary>
        double BottomMarginPosition { get; }

        /// <summary>
        /// The horizontal coordinate of the left margin edge.
        /// </summary>
        double LeftMarginPosition { get; }

        /// <summary>
        /// The horizontal coordinate of the right margin edge.
        /// </summary>
        double RightMarginPosition { get; }

        /// <summary>
        /// The available width between left and right margin edges.
        /// </summary>
        double PageAvailableWidth { get; }

        /// <summary>
        /// A counter to keep track of the current vertical position on a page that is being composed.
        /// </summary>
        double CurrentVerticalCursor { get; set; }
    }
}
