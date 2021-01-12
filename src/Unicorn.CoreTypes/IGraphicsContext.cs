using System.Collections.Generic;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// Defines a graphics context for low-level drawing operations.
    /// </summary>
    public interface IGraphicsContext
    {
        /// <summary>
        /// Carry out any operations needed to cleanly close the content stream for this graphics context, such as balancing any unbalanced PDF operators.
        /// </summary>
        void CloseGraphics();

        /// <summary>
        /// Save the state of this context.
        /// </summary>
        /// <returns>An <see cref="IGraphicsState"/> object encapsulating the saved state.</returns>
        IGraphicsState Save();

        /// <summary>
        /// Restore the state of this context from a previously saved state.
        /// </summary>
        /// <param name="state">The saved state of the context.</param>
        /// <remarks>Implementations may place restrictions on the saved state; for example, that it must previously have been returned by the same object.</remarks>
        void Restore(IGraphicsState state);

        /// <summary>
        /// Rotate the context.
        /// </summary>
        /// <param name="angle">The angle to rotate by (in degrees, clockwise positive).</param>
        /// <param name="x">The X-coordinate of the centre of rotation.</param>
        /// <param name="y">The Y-coordinate of the centre of rotation.</param>
        void RotateAt(double angle, double x, double y);

        /// <summary>
        /// Rotate the context.
        /// </summary>
        /// <param name="angle">The angle to rotate by (in degrees, clockwise positive).</param>
        /// <param name="around">The centre of rotation.</param>
        void RotateAt(double angle, UniPoint around);

        /// <summary>
        /// Draw a line between two points.
        /// </summary>
        /// <param name="x1">X-coordinate of the first point.</param>
        /// <param name="y1">Y-coordinate of the first point.</param>
        /// <param name="x2">X-coordinate of the second point.</param>
        /// <param name="y2">Y-coordinate of the second point.</param>
        void DrawLine(double x1, double y1, double x2, double y2);

        /// <summary>
        /// Draw a line between two points.
        /// </summary>
        /// <param name="x1">X-coordinate of the first point.</param>
        /// <param name="y1">Y-coordinate of the first point.</param>
        /// <param name="x2">X-coordinate of the second point.</param>
        /// <param name="y2">Y-coordinate of the second point.</param>
        /// <param name="width">The width of the line.</param>
        void DrawLine(double x1, double y1, double x2, double y2, double width);

        /// <summary>
        /// Draw a line between two points.
        /// </summary>
        /// <param name="x1">X-coordinate of the first point.</param>
        /// <param name="y1">Y-coordinate of the first point.</param>
        /// <param name="x2">X-coordinate of the second point.</param>
        /// <param name="y2">Y-coordinate of the second point.</param>
        /// <param name="width">The width of the line.</param>
        /// <param name="style">The drawing style of the line - solid, dotted, dashed, etc.</param>
        void DrawLine(double x1, double y1, double x2, double y2, double width, UniDashStyle style);

        /// <summary>
        /// Draw a filled polygon consisting of straight lines connecting an ordered set of vertexes in sequence.
        /// </summary>
        /// <param name="vertexes">The vertexes of the polygon.</param>
        void DrawFilledPolygon(IEnumerable<UniPoint> vertexes);

        /// <summary>
        /// Draw a rectangle.
        /// </summary>
        /// <param name="xTopLeft">X-coordinate of the left side of the rectangle.</param>
        /// <param name="yTopLeft">Y-coordinate of the top side of the rectangle.</param>
        /// <param name="rectWidth">Width of the rectangle.</param>
        /// <param name="rectHeight">Height of the rectangle.</param>
        void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight);

        /// <summary>
        /// Draw a rectangle.
        /// </summary>
        /// <param name="xTopLeft">X-coordinate of the left side of the rectangle.</param>
        /// <param name="yTopLeft">Y-coordinate of the top side of the rectangle.</param>
        /// <param name="rectWidth">Width of the rectangle.</param>
        /// <param name="rectHeight">Height of the rectangle.</param>
        /// <param name="lineWidth">The width of the line that draws the rectangle.</param>
        void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight, double lineWidth);

        /// <summary>
        /// Draw a string at a given point.
        /// </summary>
        /// <param name="text">Text to draw.</param>
        /// <param name="font">Font to use to render the text.</param>
        /// <param name="x">X-coordinate of the top left corner of the text's bounding box.</param>
        /// <param name="y">Y-coordinate of the top left corner of the text's bounding box.</param>
        void DrawString(string text, IFontDescriptor font, double x, double y);

        /// <summary>
        /// Draw a string inside a given rectangle, with specific alignment.
        /// </summary>
        /// <param name="text">Text to draw.</param>
        /// <param name="font">Font to use to render the text.</param>
        /// <param name="rect">The bounding rectangle within which to draw the text.</param>
        /// <param name="hAlign">Desired horizontal alignment of the text within the bounding rectangle.</param>
        /// <param name="vAlign">Desired vertical alignment of the text within the bounding rectangle.</param>
        void DrawString(string text, IFontDescriptor font, UniRectangle rect, HorizontalAlignment hAlign, VerticalAlignment vAlign);

        /// <summary>
        /// Measure the dimensions of a string when rendered with a particular font.
        /// </summary>
        /// <param name="text">Text to measure.</param>
        /// <param name="font">Font to use when measuring what size the text will be on render.</param>
        /// <returns>The dimensions of the text's bounding box.</returns>
        UniTextSize MeasureString(string text, IFontDescriptor font);
    }
}
