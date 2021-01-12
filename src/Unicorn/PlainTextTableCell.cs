using System;
using Unicorn.CoreTypes;

namespace Unicorn
{
    /// <summary>
    /// A table cell that contains a single string of text.
    /// </summary>
    public class PlainTextTableCell : TableCell
    {
        /// <summary>
        /// The cell content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Constructor for cell with no margins.
        /// </summary>
        /// <param name="content">The cell content.</param>
        /// <param name="font">The font to use to draw the content.</param>
        /// <param name="graphicsContext">The graphics context which will be used to draw the cell.</param>
        public PlainTextTableCell(string content, IFontDescriptor font, IGraphicsContext graphicsContext) : this(content, font, null, graphicsContext)
        {

        }

        /// <summary>
        /// Constructor for cell with margins.
        /// </summary>
        /// <param name="content">The cell content.</param>
        /// <param name="font">The font to use to draw the content.</param>
        /// <param name="margins">The cell margins.</param>
        /// <param name="graphicsContext">The graphics context which will be used to draw the cell.</param>
        public PlainTextTableCell(string content, IFontDescriptor font, MarginSet margins, IGraphicsContext graphicsContext)
        {
            Content = content;
            Font = font;
            if (margins != null)
            {
                MarginLeft = margins.Left;
                MarginRight = margins.Right;
                MarginTop = margins.Top;
                MarginBottom = margins.Bottom;
            }
            MeasureSize(graphicsContext);
        }

        /// <summary>
        /// Measure the size of the cell when drawn.
        /// </summary>
        /// <param name="context">The graphics context which will be used to measure and draw the cell.</param>
        public override void MeasureSize(IGraphicsContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            string content = Content ?? string.Empty;
            UniTextSize metrics = context.MeasureString(content, Font);
            ContentWidth = metrics.Width;
            ContentAscent = metrics.HeightAboveBaseline;
            ContentDescent = metrics.HeightBelowBaseline;
            ComputedBaseline = ContentAscent;
            ComputedHeight = MinHeight;
            ComputedWidth = MinWidth;
        }

        /// <summary>
        /// Draw the cell (without borders) at a given location on the graphics context.
        /// </summary>
        /// <param name="context">The graphics context to use to draw the cell contents.</param>
        /// <param name="x">The X coordinate of the top-left corner of the cell.</param>
        /// <param name="y">The Y coordinate of the top-left corner of the cell.</param>
        public override void DrawContentsAt(IGraphicsContext context, double x, double y)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            double xOffset = (ComputedWidth - MinWidth) / 2 + MarginLeft;
            context.DrawString(Content, Font, x + xOffset, y + ComputedBaseline); // this always top-aligns content in cells that are higher than the minimum
        }
    }
}
