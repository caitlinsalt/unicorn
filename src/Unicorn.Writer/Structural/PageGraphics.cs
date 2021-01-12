using System;
using System.Collections.Generic;
using Unicorn.CoreTypes;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// This class defines drawing operations, is responsible for writing drawing operators to a page content stream, and also maintains metadata about the
    /// state of the current page.
    /// </summary>
    public class PageGraphics : IGraphicsContext
    {
        /// <summary>
        /// The page that this graphics context belongs to.
        /// </summary>
        private readonly IPdfPage _page;

        private readonly Func<double, double> _xTransformer;

        private readonly Func<double, double> _yTransformer;

        private readonly Stack<GraphicsState> _stateStack = new Stack<GraphicsState>();

        /// <summary>
        /// Current path stroking width.
        /// </summary>
        private double CurrentLineWidth { get; set; }

        /// <summary>
        /// Current path stroking dash style.
        /// </summary>
        private UniDashStyle CurrentDashStyle { get; set; }

        /// <summary>
        /// Indicates if the line width has been changed more recently than the dash style.
        /// </summary>
        private bool LineWidthChanged { get; set; }

        private IFontDescriptor CurrentFont { get; set; }

        /// <summary>
        /// Constructor.  Requires methods for mapping coordinates from Unicorn-space (with the Y-origin at the top of the page, like most desktop drawing libraries)
        /// to PDF user space (with the Y-origin at the bottom of the page, like a graph).
        /// </summary>
        /// <param name="parentPage">The page that this graphics object belongs to.</param>
        /// <param name="xTransform">A transform function for converting Unicorn-space X coordinates.</param>
        /// <param name="yTransform">A transform function for converting Unicorn-space Y coordinates.</param>
        public PageGraphics(IPdfPage parentPage, Func<double, double> xTransform, Func<double, double> yTransform)
        {
            if (parentPage is null)
            {
                throw new ArgumentNullException(nameof(parentPage));
            }
            _page = parentPage;
            _xTransformer = xTransform ?? (x => x);
            _yTransformer = yTransform ?? (x => x);
            CurrentLineWidth = -1;
            CurrentDashStyle = UniDashStyle.Solid;
        }

        /// <summary>
        /// Save the current state.
        /// </summary>
        /// <returns></returns>
        public IGraphicsState Save()
        {
            lock (_stateStack)
            {
                GraphicsState gs = new GraphicsState(CurrentLineWidth, CurrentDashStyle);
                _stateStack.Push(gs);
                PdfOperator.PushState().WriteTo(_page.ContentStream);
                return gs;
            } 
        }

        /// <summary>
        /// Restore a previous state.
        /// </summary>
        /// <param name="state">The state to be restored.</param>
        public void Restore(IGraphicsState state)
        {
            if (!(state is GraphicsState gs))
            {
                throw new ArgumentException(Resources.Structural_PageGraphics_RestoreWrongTypeError);
            }
            lock (_stateStack)
            {
                if (!_stateStack.Contains(gs))
                {
                    return;
                }
                GraphicsState popped;
                do
                {
                    popped = _stateStack.Pop();
                } while (gs != popped);
                CurrentLineWidth = gs.LineWidth;
                CurrentDashStyle = gs.DashStyle;
                LineWidthChanged = true;
                PdfOperator.PopState().WriteTo(_page.ContentStream);
            }
        }

        /// <summary>
        /// Carry out any unfinished operations needed to complete this page, such as balancing PDF operators.
        /// </summary>
        public void CloseGraphics()
        {
            lock (_stateStack)
            {
                while (_stateStack.Count > 0)
                {
                    PdfOperator.PopState().WriteTo(_page.ContentStream);
                    _stateStack.Pop();
                }
            }
        }

        /// <summary>
        /// Rotate the coordinate system around a point.
        /// </summary>
        /// <param name="angle">The angle to rotate by.</param>
        /// <param name="x">The X coordinate of the centre of rotation.</param>
        /// <param name="y">The Y coordinate of the centre of rotation.</param>
        public void RotateAt(double angle, double x, double y) => RotateAt(angle, new UniPoint(x, y));

        /// <summary>
        /// Rotate the coordinate system around a point.
        /// </summary>
        /// <param name="angle">The angle to rotate by.</param>
        /// <param name="around">The centre of rotation.</param>
        public void RotateAt(double angle, UniPoint around)
        {
            PdfOperator.ApplyTransformation(UniMatrix.RotationAt(MathsHelpers.DegToRad(-angle), new UniPoint(_xTransformer(around.X), _yTransformer(around.Y))))
                .WriteTo(_page.ContentStream);
        }

        /// <summary>
        /// Draw a straight solid line of 1pt width.
        /// </summary>
        /// <param name="x1">X-coordinate of the starting point.</param>
        /// <param name="y1">Y-coordinate of the starting point.</param>
        /// <param name="x2">X-coordinate of the ending point.</param>
        /// <param name="y2">Y-coordinate of the ending point.</param>
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            DrawLine(x1, y1, x2, y2, 1d, UniDashStyle.Solid);
        }

        /// <summary>
        /// Draw a straight solid line of specified width. 
        /// </summary>
        /// <param name="x1">X-coordinate of the starting point.</param>
        /// <param name="y1">Y-coordinate of the starting point.</param>
        /// <param name="x2">X-coordinate of the ending point.</param>
        /// <param name="y2">Y-coordinate of the ending point.</param>
        /// <param name="width">Width of the line.</param>
        public void DrawLine(double x1, double y1, double x2, double y2, double width)
        {
            DrawLine(x1, y1, x2, y2, width, UniDashStyle.Solid);
        }

        /// <summary>
        /// Draw a straight line with specified width and dash pattern.
        /// </summary>
        /// <param name="x1">X-coordinate of the starting point.</param>
        /// <param name="y1">Y-coordinate of the starting point.</param>
        /// <param name="x2">X-coordinate of the ending point.</param>
        /// <param name="y2">Y-coordinate of the ending point.</param>
        /// <param name="width">Width of the line.</param>
        /// <param name="style">Dash pattern of the line.</param>
        public void DrawLine(double x1, double y1, double x2, double y2, double width, UniDashStyle style)
        {
            ChangeLineWidth(width);
            ChangeDashStyle(style);
            PdfOperator.StartPath(new PdfReal(_xTransformer(x1)), new PdfReal(_yTransformer(y1))).WriteTo(_page.ContentStream);
            PdfOperator.AppendStraightLine(new PdfReal(_xTransformer(x2)), new PdfReal(_yTransformer(y2))).WriteTo(_page.ContentStream);
            PdfOperator.StrokePath().WriteTo(_page.ContentStream);
        }

        /// <summary>
        /// Draw a filled polygon.
        /// </summary>
        /// <param name="vertexes">List of vertexes of the polygon.</param>
        public void DrawFilledPolygon(IEnumerable<UniPoint> vertexes)
        {
            
        }

        /// <summary>
        /// Draw a non-filled rectangle with line width 1pt.
        /// </summary>
        /// <param name="xTopLeft">X-coordinate of the top left corner of the rectangle.</param>
        /// <param name="yTopLeft">Y-coordinate of the top left corner of the rectangle.</param>
        /// <param name="rectWidth">Width of the rectangle.</param>
        /// <param name="rectHeight">Height of the rectangle.</param>
        public void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight)
        {
            DrawRectangle(xTopLeft, yTopLeft, rectWidth, rectHeight, 1d);
        }

        /// <summary>
        /// Draw a non-filled rectangle of specified line width.
        /// </summary>
        /// <param name="xTopLeft">X-coordinate of the top left corner of the rectangle.</param>
        /// <param name="yTopLeft">Y-coordinate of the top left corner of the rectangle.</param>
        /// <param name="rectWidth">Width of the rectangle.</param>
        /// <param name="rectHeight">Height of the rectangle.</param>
        /// <param name="lineWidth">Stroke width.</param>
        public void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight, double lineWidth)
        {
            ChangeLineWidth(lineWidth);
            ChangeDashStyle(UniDashStyle.Solid);
            PdfOperator.AppendRectangle(new PdfReal(_xTransformer(xTopLeft)), new PdfReal(_yTransformer(yTopLeft + rectHeight)), 
                new PdfReal(rectWidth), new PdfReal(rectHeight))
                .WriteTo(_page.ContentStream);
            PdfOperator.StrokePath().WriteTo(_page.ContentStream);
        }

        /// <summary>
        /// Draw a string.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <param name="font">The font to use</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawString(string text, IFontDescriptor font, double x, double y)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            PdfOperator.StartText().WriteTo(_page.ContentStream);
            ChangeFont(font);
            PdfOperator.SetTextLocation(new PdfReal(_xTransformer(x)), new PdfReal(_yTransformer(y))).WriteTo(_page.ContentStream);
            PdfOperator.DrawText(new PdfByteString(font.PreferredEncoding.GetBytes(text))).WriteTo(_page.ContentStream);
            PdfOperator.EndText().WriteTo(_page.ContentStream);
        }

        /// <summary>
        /// Draw a string inside a bounding box.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect"></param>
        /// <param name="hAlign"></param>
        /// <param name="vAlign"></param>
        public void DrawString(string text, IFontDescriptor font, UniRectangle rect, HorizontalAlignment hAlign, VerticalAlignment vAlign)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            var stringBox = MeasureString(text, font);
            double x;
            double y;
            switch (hAlign)
            {
                case HorizontalAlignment.Left:
                    x = rect.MinX;
                    break;
                case HorizontalAlignment.Right:
                    x = rect.MinX + rect.Width - stringBox.Width;
                    break;
                default:
                    x = rect.MinX + (rect.Width - stringBox.Width) / 2;
                    break;
            }
            switch (vAlign)
            {
                case VerticalAlignment.Bottom:
                    y = rect.MinY + rect.Height - stringBox.MaxHeightBelowBaseline;
                    break;
                case VerticalAlignment.Top:
                    y = rect.MinY + stringBox.MaxHeightAboveBaseline;
                    break;
                default:
                    y = rect.MinY + (rect.Height + stringBox.MaxHeight) / 2 - stringBox.MaxHeightBelowBaseline;
                    break;
            }
            DrawString(text, font, x, y);
        }

        /// <summary>
        /// Measure the dimensions of a string, if it were to be drawn.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public UniTextSize MeasureString(string text, IFontDescriptor font)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            return font.MeasureString(text);
        }

        private void ChangeLineWidth(double width)
        {
            if (width != CurrentLineWidth)
            {
                PdfOperator.LineWidth(new PdfReal(width)).WriteTo(_page.ContentStream);
                CurrentLineWidth = width;
                LineWidthChanged = true;
            }
        }

        private void ChangeDashStyle(UniDashStyle style)
        {
            if (style != CurrentDashStyle || (LineWidthChanged && style != UniDashStyle.Solid))
            {
                IPdfPrimitiveObject[] operands = style.ToPdfObjects(CurrentLineWidth);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(_page.ContentStream);
                CurrentDashStyle = style;
                LineWidthChanged = false;
            }
        }

        private void ChangeFont(IFontDescriptor font)
        {
            if (font != CurrentFont)
            {
                PdfFont pageFont = _page.UseFont(font);
                PdfOperator.SetTextFont(pageFont.InternalName, new PdfReal(font.PointSize)).WriteTo(_page.ContentStream);
                CurrentFont = font;
            }
        }
    }
}
