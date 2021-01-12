using Unicorn.CoreTypes;

namespace Unicorn
{
    /// <summary>
    /// A class representing a generic table cell.
    /// </summary>
    public abstract class TableCell
    {
        /// <summary>
        /// The width of the cell content.
        /// </summary>
        public double ContentWidth { get; set; }

        /// <summary>
        /// The ascent metric of the cell content.
        /// </summary>
        public double ContentAscent { get; set; }

        /// <summary>
        /// The descent metric of the cell content.
        /// </summary>
        public double ContentDescent { get; set; }

        /// <summary>
        /// The left margin width of the cell.
        /// </summary>
        public double MarginLeft { get; set; }

        /// <summary>
        /// The right margin width of the cell.
        /// </summary>
        public double MarginRight { get; set; }

        /// <summary>
        /// The top margin height of the cell.
        /// </summary>
        public double MarginTop { get; set; }

        /// <summary>
        /// THe bottom margin height of the cell.
        /// </summary>
        public double MarginBottom { get; set; }

        /// <summary>
        /// The minimum total width of the cell content, equal to the sum of the content with and the left and right margin widths.
        /// </summary>
        public double MinWidth
        {
            get
            {
                return ContentWidth + MarginLeft + MarginRight;
            }
        }

        /// <summary>
        /// The minimum total height of the cell content, equal to the sum of the content ascent, content descent, top margin and bottom margin heights.
        /// </summary>
        public double MinHeight
        {
            get
            {
                return ContentAscent + ContentDescent + MarginTop + MarginBottom;
            }
        }

        /// <summary>
        /// The minimum total cell ascent height, equal to the sum of the content ascent and the top margin.
        /// </summary>
        public double MinAscent
        {
            get
            {
                return ContentAscent + MarginTop;
            }
        }

        /// <summary>
        /// The minimum total cell descent height, equal to the sum of the content descent and the bottom margin.
        /// </summary>
        public double MinDescent
        {
            get
            {
                return ContentDescent + MarginBottom;
            }
        }

        /// <summary>
        /// The effective width of the cell, which should be set by the <see cref="MeasureSize(IGraphicsContext)"/> method.
        /// </summary>
        public double ComputedWidth { get; set; }

        /// <summary>
        /// The effective height of the cell, which should be set by the <see cref="MeasureSize(IGraphicsContext)"/> method.
        /// </summary>
        public double ComputedHeight { get; set; }

        /// <summary>
        /// The effective ascent of the cell, which should be set by the <see cref="MeasureSize(IGraphicsContext)"/> method.
        /// </summary>
        public double ComputedBaseline { get; set; }

        /// <summary>
        /// The font to use to draw the cell contents, assuming a single font will suffice.
        /// </summary>
        public IFontDescriptor Font { get; set; }

        /// <summary>
        /// Measure the size of the cell.
        /// </summary>
        /// <param name="context">The graphics context to use for measuring the cell.</param>
        public abstract void MeasureSize(IGraphicsContext context);

        /// <summary>
        /// Draw the cell contents at a given location.
        /// </summary>
        /// <param name="context">The graphics context to use to draw the cell.</param>
        /// <param name="x">The X coordinate of the top-left corner of the cell.</param>
        /// <param name="y">The Y coordinate of the top-left corner of the cell.</param>
        public abstract void DrawContentsAt(IGraphicsContext context, double x, double y);
    }
}
