using System;
using Unicorn.Base;
using Unicorn.CoreTypes;

namespace Unicorn
{
    /// <summary>
    /// A wireframe image object, with a fixed size, 
    /// </summary>
    public class ImageWireframe : IFixedSizeDrawable
    {
        /// <summary>
        /// Width of the "image".
        /// </summary>
        public double Width => ContentWidth + MarginSet.Left + MarginSet.Right;

        /// <summary>
        /// Height of the "image".
        /// </summary>
        public double Height => ContentHeight + MarginSet.Top + MarginSet.Bottom;

        /// <summary>
        /// Margins of the "image".
        /// </summary>
        public MarginSet MarginSet { get; private set; }

        /// <summary>
        /// Height of the "image".
        /// </summary>
        public double ContentHeight { get; private set; }

        /// <summary>
        /// Width of the "image".
        /// </summary>
        public double ContentWidth { get; private set; }

        /// <summary>
        /// Constructor with width and height parameters.
        /// </summary>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        public ImageWireframe(double width, double height) : this(width, height, new MarginSet()) { }

        /// <summary>
        /// Constructor with width, height and margin parameters.
        /// </summary>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        /// <param name="margins">Margin around the image.</param>
        public ImageWireframe(double width, double height, MarginSet margins)
        {
            ContentWidth = width;
            ContentHeight = height;
            MarginSet = margins ?? new MarginSet();
        }

        /// <summary>
        /// Constructor which takes a fixed width parameter and derives the image height from the aspect ratio of a source image.
        /// </summary>
        /// <param name="width">Image width.</param>
        /// <param name="source">Source image for the aspect ratio of this image.</param>
        /// <param name="margins">Margin around the image</param>
        /// <exception cref="ArgumentNullException"><c>source</c> is <c>null</c>.</exception>
        public ImageWireframe(double width, ISourceImage source, MarginSet margins)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            ContentWidth = width;
            ContentHeight = width / source.AspectRatio;
            MarginSet = margins ?? new MarginSet();
        }

        /// <summary>
        /// Draw this "image" onto a context.
        /// </summary>
        /// <param name="context">The context to draw the "image" onto.</param>
        /// <param name="x">The x-coordinate of the top-left corner of the "image".</param>
        /// <param name="y">The y-coordinate of the top-left corner of the "image".</param>
        /// <exception cref="ArgumentNullException"><c>context</c> is <c>null</c>.</exception>
        public void DrawAt(IGraphicsContext context, double x, double y)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            double leftEdge = x + MarginSet.Left;
            double topEdge = y + MarginSet.Top;
            context.DrawRectangle(leftEdge, topEdge, ContentWidth, ContentHeight);
            context.DrawLine(leftEdge, topEdge, leftEdge + ContentWidth, topEdge + ContentHeight);
            context.DrawLine(leftEdge + ContentWidth, topEdge, leftEdge, topEdge + ContentHeight);
        }
    }
}
