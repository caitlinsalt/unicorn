using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.CoreTypes;

namespace Unicorn
{
    /// <summary>
    /// A paragraph of text, consisting of a number of lines.
    /// </summary>
    public class Paragraph : IDrawable
    {
        /// <summary>
        /// The ideal maximum width of this paragraph.
        /// </summary>
        public double MaximumWidth { get; set; }

        /// <summary>
        /// The ideal maximum height of this paragraph.
        /// </summary>
        public double? MaximumHeight { get; set; }

        /// <summary>
        /// Flag to indicate if the actual width of this paragraph overspills the ideal maximum width.
        /// </summary>
        public bool OverspillWidth { get; set; }

        /// <summary>
        /// Flag to indicate if the actual height of this paragraph overspills the ideal maximum height.
        /// </summary>
        public bool OverspillHeight { get; set; }

        /// <summary>
        /// The margins of this paragraph.
        /// </summary>
        public MarginSet Margins { get; set; }

        /// <summary>
        /// Orientation of this paragraph.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// The horizontal alignment of the content of this paragraph.
        /// </summary>
        public HorizontalAlignment HorizontalAlignment { get; set; }

        /// <summary>
        /// The vertical alignment of the content of this paragraph.
        /// </summary>
        public VerticalAlignment VerticalAlignment { get; set; }

        /// <summary>
        /// The computed height of the object: equal to the maximum height if that is set, or the sum of all line heights if not.
        /// </summary>
        public double ComputedHeight
        {
            get
            {
                return MaximumHeight ?? ContentHeight;
            }
        }

        /// <summary>
        /// The height of the content of this paragraph, being the sum of the individual line heights plus the height of the margins.  This may be less than the computed height if a height has 
        /// been manually set, and may be more than the computed height if there is vertical overspill.
        /// </summary>
        public double ContentHeight
        {
            get
            {
                return _lines.Sum(l => l.ContentHeight) + Margins.Top + Margins.Bottom;
            }
        }

        /// <summary>
        /// The width of the content of this paragraph, being the minimum width of the widest line.
        /// </summary>
        public double ContentWidth
        {
            get
            {
                double marginSum = Margins.Left + Margins.Right;
                if (_lines != null)
                {
                    return _lines.Max(l => l.MinWidth) + marginSum;
                }
                return marginSum;
            }
        }

        /// <summary>
        /// The paragraph content.
        /// </summary>
        public IList<Line> Lines => _lines;

        private readonly List<Line> _lines = new List<Line>();

        /// <summary>
        /// Constructor which specified ideal maximum sizes.
        /// </summary>
        /// <param name="maxWidth">The ideal maximum width.</param>
        /// <param name="maxHeight">The ideal maximum height, or null if not specified.</param>
        public Paragraph(double maxWidth, double? maxHeight)
        {
            MaximumWidth = maxWidth;
            MaximumHeight = maxHeight;
            Margins = new MarginSet();
        }

        /// <summary>
        /// Constructor with all available parameters.
        /// </summary>
        /// <param name="maxWidth">The ideal paragraph width.</param>
        /// <param name="maxHeight">The ideal paragraph height, or null if not specified.</param>
        /// <param name="orientation">The orientation of the paragraph.</param>
        /// <param name="hAlignment">The horizontal alignment of the paragraph content.</param>
        /// <param name="vAlignment">The vertical alignment of the paragraph content.</param>
        public Paragraph(double maxWidth, double? maxHeight, Orientation orientation, HorizontalAlignment hAlignment, VerticalAlignment vAlignment) : this(maxWidth, maxHeight)
        {
            Orientation = orientation;
            VerticalAlignment = vAlignment;
            HorizontalAlignment = hAlignment;
        }

        /// <summary>
        /// Constructor with all available parameters.
        /// </summary>
        /// <param name="maxWidth">The ideal paragraph width.</param>
        /// <param name="maxHeight">The ideal paragraph height, or null if not specified.</param>
        /// <param name="orientation">The orientation of the paragraph.</param>
        /// <param name="hAlignment">The horizontal alignment of the paragraph content.</param>
        /// <param name="vAlignment">The vertical alignment of the paragraph content.</param>
        /// <param name="margins">The margins to use for this paragraph.</param>
        public Paragraph(double maxWidth, double? maxHeight, Orientation orientation, HorizontalAlignment hAlignment, VerticalAlignment vAlignment, MarginSet margins)
            : this(maxWidth, maxHeight, orientation, hAlignment, vAlignment)
        {
            Margins = margins;
        }

        /// <summary>
        /// Add text to this paragraph.
        /// </summary>
        /// <param name="text">The text to be added.</param>
        /// <param name="font">The font to be used to write the text.</param>
        /// <param name="graphicsContext">The context to be used for metrics.</param>
        public void AddText(string text, IFontDescriptor font, IGraphicsContext graphicsContext)
        {
            var words = Word.MakeWords(text, font, graphicsContext);
            _lines.AddRange(Line.MakeLines(words, MaximumWidth - (Margins.Left + Margins.Right)));
            if (_lines.Any(l => l.OverspillWidth))
            {
                OverspillWidth = true;
            }
            if (_lines.Sum(l => l.ContentHeight) > MaximumHeight)
            {
                OverspillHeight = true;
            }
        }

        /// <summary>
        /// Draw this paragraph onto a context.
        /// </summary>
        /// <param name="context">The context to use for drawing.</param>
        /// <param name="x">The X-coordinate of the top left corner of the paragraph.</param>
        /// <param name="y">The Y-coordinate of the top-left corner of the paragraph.</param>
        public void DrawAt(IGraphicsContext context, double x, double y)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            IGraphicsState state = context.Save();
            Reorientate(context, x, y, false);
            try
            {
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Centred:
                        y += (ComputedHeight - ContentHeight) / 2;
                        break;
                    case VerticalAlignment.Bottom:
                        y += (ComputedHeight - ContentHeight);
                        break;
                }

                foreach (Line line in _lines)
                {
                    double xPos;
                    switch (HorizontalAlignment)
                    {
                        case HorizontalAlignment.Left:
                        case HorizontalAlignment.Justified:
                        default:
                            xPos = x + Margins.Left;
                            break;
                        case HorizontalAlignment.Centred:
                            xPos = x + Margins.Left + (MaximumWidth - (line.MinWidth + Margins.Left + Margins.Right)) / 2;
                            break;
                        case HorizontalAlignment.Right:
                            xPos = x + (MaximumWidth - line.MinWidth) - Margins.Right;
                            break;
                    }
                    line.DrawAt(context, xPos, y);
                    y += line.ContentHeight;
                }
            }
            finally
            {
                context.Restore(state);
            }
        }

        private void Reorientate(IGraphicsContext context, double x, double y, bool reverse)
        {
            double xRotate;
            double yRotate;
            double angle;
            switch (Orientation)
            {
                default:
                    return;
                case Orientation.RotatedRight:
                    xRotate = x + ComputedHeight / 2.0;
                    yRotate = y + ComputedHeight / 2.0;
                    angle = 90;
                    break;
                case Orientation.RotatedLeft:
                    xRotate = x + MaximumWidth / 2.0;
                    yRotate = y + MaximumWidth / 2.0;
                    angle = -90;
                    break;
                case Orientation.UpsideDown:
                    xRotate = x + MaximumWidth / 2.0;
                    yRotate = y + ComputedHeight / 2.0;
                    angle = 180;
                    break;
            }

            context.RotateAt(reverse ? -angle : angle, xRotate, yRotate);
        }
    }
}
