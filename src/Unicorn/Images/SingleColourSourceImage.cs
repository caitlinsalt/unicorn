using Unicorn.Base;

namespace Unicorn.Images
{
    /// <summary>
    /// A source image that consists of a single colour.  Also referred to as a "mock image" elsewhere.
    /// </summary>
    public class SingleColourSourceImage : ISourceImage
    {
        /// <summary>
        /// The colour of the image.
        /// </summary>
        public IColour ImageColour { get; private set; }

        /// <summary>
        /// Width of the image.  This is only provided in order to set the aspect ratio, as a single-colour
        /// rectangle can be scaled to any size.
        /// </summary>
        public int DotWidth { get; private set; }

        /// <summary>
        /// Height of the image.  This is only provided in order to set the aspect ratio, as a single-colour
        /// rectangle can be scaled to any size.
        /// </summary>
        public int DotHeight { get; private set; }

        /// <summary>
        /// Aspect ratio of the image (width divided by height).
        /// </summary>
        public double AspectRatio => (double)DotWidth / DotHeight;

        /// <summary>
        /// Property-setting constructor.
        /// </summary>
        /// <param name="colour">Colour of the image.</param>
        /// <param name="width">Width of the image.</param>
        /// <param name="height">Height of the image.</param>
        public SingleColourSourceImage(IColour colour, int width, int height)
        {
            ImageColour = colour;
            DotWidth = width;
            DotHeight = height;
        }

        /// <summary>
        /// Construct an image with a 1:1 aspect ratio.
        /// </summary>
        /// <param name="colour">COlour of the image</param>
        public SingleColourSourceImage(IColour colour) : this(colour, 1, 1) { }
    }
}
