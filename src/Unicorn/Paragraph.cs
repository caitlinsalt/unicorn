using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.Base;
using Unicorn.Helpers;

namespace Unicorn
{
    /// <summary>
    /// A paragraph of text, consisting of a number of lines.
    /// </summary>
    public class Paragraph : ISplittable, ISplittable<Paragraph>
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
        public double ComputedHeight => MaximumHeight ?? ContentHeight;

        /// <summary>
        /// The total height of the object including margins.
        /// </summary>
        public double Height => ComputedHeight + Margins.Top + Margins.Bottom;

        /// <summary>
        /// The height of the content of this paragraph, being the sum of the individual line heights plus the height of the margins.  This may be less than the computed height if a height has 
        /// been manually set, and may be more than the computed height if there is vertical overspill.
        /// </summary>
        public double ContentHeight => _lines.Sum(l => l.ContentHeight) + Margins.Top + Margins.Bottom;

        /// <summary>
        /// The width of the content of this paragraph, being the minimum width of the widest line.
        /// </summary>
        public double ContentWidth
        {
            get
            {
                double marginSum = Margins.Left + Margins.Right;
                if (_lines != null && _lines.Any())
                {
                    return _lines.Max(l => l.MinWidth) + marginSum;
                }
                return marginSum;
            }
        }

        /// <summary>
        /// The paragraph content.
        /// </summary>
        public IReadOnlyList<Line> Lines => _lines;

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
        /// Constructor with maximun size, orientation and alignment parameters.
        /// </summary>
        /// <param name="maxWidth">The ideal paragraph width.</param>
        /// <param name="maxHeight">The ideal paragraph height, or null if not specified.</param>
        /// <param name="orientation">The orientation of the paragraph.</param>
        /// <param name="hAlignment">The horizontal alignment of the paragraph content.</param>
        /// <param name="vAlignment">The vertical alignment of the paragraph content.</param>
        public Paragraph(double maxWidth, double? maxHeight, Orientation orientation, HorizontalAlignment hAlignment, VerticalAlignment vAlignment) 
            : this(maxWidth, maxHeight)
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
            TestOverspills();
        }

        /// <summary>
        /// Add text to this paragraph, in the form of preformatted lines.
        /// </summary>
        /// <param name="lines">The lines to append to the paragraph.</param>
        public void AddLines(IEnumerable<Line> lines)
        {
            _lines.AddRange(lines);
            TestOverspills();
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

        /// <summary>
        /// Split an overflowing paragraph in two.  If the paragraph is split, this object will be modified in-place and will contain the start of the original
        /// paragraph, and the returned object will contain the end of the original paragraph.  The paragraph will not be split if it is not overspilling, if it
        /// already consists of a single line, or in various situations where the  <c>waoControl</c> parameter is set to <see cref="WidowsAndOrphans.Prevent" />.
        /// In these cases, <c>null</c> will be returned.
        /// </summary>
        /// <remarks>
        /// <para>There are various situations when an overflowing paragraph will not be split by this routine, depending on the length of the paragraph,
        /// the position of the split, and the value of the <c>waoControl</c> paramter.</para>
        /// <list type="bullet">
        /// <item><description>A one-line paragraph can never be split.</description></item>
        /// <item><description>A two-line paragraph can only be split if <c>waoControl</c> equals <see cref="WidowsAndOrphans.Allow"/>.</description></item>
        /// <item><description>A paragraph can only be split between the first and second lines if <c>waoControl</c> equals <see cref="WidowsAndOrphans.Allow"/> 
        /// or <see cref="WidowsAndOrphans.Avoid"/>.</description></item>
        /// </list>
        /// <para>In each of the above cases, if the paragraph cannot be split it will still be overflowing.</para>
        /// <list type="bullet">
        /// <item><description>A paragraph can only be split between the penultimate and last lines if <c>waoControl</c> equals <see cref="WidowsAndOrphans.Allow"/>.</description></item>
        /// </list>
        /// <para>In this case, if the paragraph cannot be split between the penultimate and last lines, the split will be made before the penultimate line,
        /// so that the new paragraph contains two lines of text.</para>
        /// <para>In all cases, if the paragraph is split then the original paragraph object will no longer be overflowing.  However, the new paragraph may be
        /// already overflowing, depending on the value of the <c>maxheight</c> parameter.  The calling code should always check the <see cref="OverspillHeight" />
        /// property of the new paragraph to determine if it needs to be split further.</para>
        /// </remarks>
        /// <param name="maxHeight">The maximum content height of the second paragraph, if one is created.</param>
        /// <param name="waoControl">Whether to permit, prevent or avoid creating "widow" or "orphan" paragraphs: part-paragraphs consisting of a single line.</param>
        /// <returns>A partial paragraph containing the second portion of a split paragraph, or <c>null</c> if no split occurred.  Any paragraph returned may
        /// also be overflowing.</returns>
        public Paragraph Split(double? maxHeight, WidowsAndOrphans waoControl = WidowsAndOrphans.Prevent)
        {
            if (!OverspillHeight || _lines.Count < 2)
            {
                return null;
            }
            if (waoControl != WidowsAndOrphans.Allow && _lines.Count < 3)
            {
                return null;
            }
            int splitIndex = FindOverspillLine();
            if (splitIndex == 1 && waoControl == WidowsAndOrphans.Prevent)
            {
                return null;
            }
            if (splitIndex == _lines.Count - 1 && waoControl != WidowsAndOrphans.Allow)
            {
                splitIndex--;
            }
            return SplitAt(splitIndex, maxHeight);
        }

        ISplittable ISplittable.Split(double? maxHeight, WidowsAndOrphans waoControl) => Split(maxHeight, waoControl);

        /// <summary>
        /// Split this paragraph at the given line, which becomes the first line of the new paragraph.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the <c>idx</c> parameter is 0, this object is not modified and <c>null</c> is returned.  If it is not but is within range, this object is modified
        /// in-place with line <c>idx</c> and those after it removed, and a new paragraph is returned with the line at <c>idx</c> as its first line.  This object
        /// will have its overspill flags reset, but either paragraph may still be overspilling.
        /// </para>
        /// <para>
        /// Unlike the <see cref="Split(double?, WidowsAndOrphans)" /> method, this method does not prevent single-line paragraphs being created.
        /// </para>
        /// </remarks>
        /// <param name="idx">The index of the line which will become the first line of the new paragraph.</param>
        /// <param name="maxHeight">The maximum height of the new paragraph.</param>
        /// <returns>A new paragraph split from this one, or <c>null</c> if the paragraph is not split.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The <c>idx</c> parameter is less than 0, or greater than or equal to the number of lines in the paragraph.</exception>
        public Paragraph SplitAt(int idx, double? maxHeight)
        {
            if (idx < 0 || idx >= _lines.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }
            if (idx == 0)
            {
                return null;
            }
            var newParagraph = new Paragraph(MaximumWidth, maxHeight, Orientation, HorizontalAlignment, VerticalAlignment, Margins.Clone());
            newParagraph.AddLines(_lines.Skip(idx));
            _lines.RemoveAfter(idx);
            RetestOverspills();
            return newParagraph;
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

        private int FindOverspillLine()
        {
            double runningTotalHeight = 0;
            for (int i = 0; i < _lines.Count; ++i)
            {
                runningTotalHeight += _lines[i].ContentHeight;
                if (runningTotalHeight > MaximumHeight)
                {
                    return i;
                }
            }
            return -1;
        }

        private void TestOverspills()
        {
            if (_lines.Any(l => l.OverspillWidth) || _lines.Any(l => l.MinWidth > MaximumWidth))
            {
                OverspillWidth = true;
            }
            if (_lines.Sum(l => l.ContentHeight) > MaximumHeight)
            {
                OverspillHeight = true;
            }
        }

        private void RetestOverspills()
        {
            OverspillWidth = false;
            OverspillHeight = false;
            TestOverspills();
        }
    }
}
