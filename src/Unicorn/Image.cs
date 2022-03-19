using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Base;

namespace Unicorn
{
    /// <summary>
    /// An image object with a fixed size.
    /// </summary>
    public class Image : IFixedSizeDrawable
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
        /// Descriptor for the image data.
        /// </summary>
        public IEmbeddedImageDescriptor ImageDescriptor { get; set; }

        /// <summary>
        /// Constructor with width and height parameters.
        /// </summary>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        public Image(double width, double height) : this(width, height, new MarginSet()) { }

        /// <summary>
        /// Constructor with width, height and margin parameters.
        /// </summary>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        /// <param name="margins">Margin around the image.</param>
        public Image(double width, double height, MarginSet margins)
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
        /// <param name="image">Embedded image data to use to draw this image.</param>
        /// <param name="margins">Margin around the image</param>
        /// <exception cref="ArgumentNullException"><c>source</c> is <c>null</c>.</exception>
        public Image(double width, ISourceImage source, IEmbeddedImageDescriptor image, MarginSet margins)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            ImageDescriptor = image;
            ContentWidth = width;
            ContentHeight = width / source.AspectRatio;
            MarginSet = margins ?? new MarginSet();
        }

        /// <summary>
        /// Draw this image at the given location.
        /// </summary>
        /// <param name="context">The context to draw on.  The image's <see cref="ImageDescriptor" /> should be for the same page as the context.</param>
        /// <param name="x">The X-coordinate of the top-left corner of the outside margin of the image.</param>
        /// <param name="y">The Y-coordinate of the top-left corner of the outside margin of the image.</param>
        /// <exception cref="ArgumentNullException"><c>context</c> is <c>null</c>.</exception>
        public void DrawAt(IGraphicsContext context, double x, double y)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (ImageDescriptor is null)
            {
                return;
            }
            double leftEdge = x + MarginSet.Left;
            double topEdge = y + MarginSet.Top;
            context.DrawImage(ImageDescriptor, leftEdge, topEdge, ContentWidth, ContentHeight);
        }
    }
}
