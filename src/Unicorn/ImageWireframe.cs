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
        public double Width { get; private set; }

        /// <summary>
        /// Height of the "image".
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Height of the "image".
        /// </summary>
        public double ContentHeight => Height;

        /// <summary>
        /// Constructor with width and height parameters.
        /// </summary>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        public ImageWireframe(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Constructor which takes a fixed width parameter and derives the image height from the aspect ratio of a source image.
        /// </summary>
        /// <param name="width">Image width.</param>
        /// <param name="source">Source image for the aspect ratio of this image.</param>
        /// <exception cref="ArgumentNullException"><c>source</c> is <c>null</c>.</exception>
        public ImageWireframe(double width, ISourceImage source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            Width = width;
            Height = width / source.AspectRatio;
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
            context.DrawRectangle(x, y, Width, Height);
            context.DrawLine(x, y, x + Width, y + Height);
            context.DrawLine(x + Width, y, x, y + Height);
        }
    }
}
