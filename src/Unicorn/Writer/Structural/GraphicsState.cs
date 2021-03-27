using Unicorn.CoreTypes;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// A saved state of the PDF graphics context.  The data stored here is not used directly by the PDF renderer; it is used by Unicorn.Writer as a memo of
    /// what the PDF renderer's internal state will be following a state pop operation.
    /// </summary>
    public class GraphicsState : IGraphicsState
    {
        /// <summary>
        /// The current line drawing width.
        /// </summary>
        public double LineWidth { get; private set; }

        /// <summary>
        /// The current line drawing dash style.
        /// </summary>
        public UniDashStyle DashStyle { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="lineWidth">The value for the <see cref="LineWidth" /> property.</param>
        /// <param name="dashStyle">The value for the <see cref="DashStyle" /> property.</param>
        public GraphicsState(double lineWidth, UniDashStyle dashStyle)
        {
            LineWidth = lineWidth;
            DashStyle = dashStyle;
        }
    }
}
