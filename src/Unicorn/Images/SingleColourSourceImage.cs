using System;
using System.Globalization;
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
        /// Width of the image per its data stream.  Single colour images are stored as a single pixel.
        /// </summary>
        public int RawDotWidth => 1;

        /// <summary>
        /// Height of the image.  This is only provided in order to set the aspect ratio, as a single-colour
        /// rectangle can be scaled to any size.
        /// </summary>
        public int DotHeight { get; private set; }

        /// <summary>
        /// Width of the image per its data stream.  Single colour images are stored as a single pixel.
        /// </summary>
        public int RawDotHeight => 1;

        /// <summary>
        /// Aspect ratio of the image (width divided by height).
        /// </summary>
        public double AspectRatio => (double)DotWidth / DotHeight;

        /// <summary>
        /// A string that uniquely identifies this image.
        /// </summary>
        public string Fingerprint => ImageColour.GetType().Name + "SSI" + ImageColour.GetHashCode().ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Single colour images do not need to be rotated to any specific orientation.
        /// </summary>
        public RightAngleRotation DrawingRotation => RightAngleRotation.None;

        /// <summary>
        /// Property-setting constructor.
        /// </summary>
        /// <param name="colour">Colour of the image.</param>
        /// <param name="width">Width of the image.</param>
        /// <param name="height">Height of the image.</param>
        public SingleColourSourceImage(IColour colour, int width, int height)
        {
            if (colour is null)
            {
                throw new ArgumentNullException(nameof(colour));
            }
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
