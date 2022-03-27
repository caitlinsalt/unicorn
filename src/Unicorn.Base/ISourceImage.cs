namespace Unicorn.Base
{
    /// <summary>
    /// A raster image which may be embedded in a PDF.
    /// </summary>
    public interface ISourceImage
    {
        /// <summary>
        /// A string that uniquely identifies this image.
        /// </summary>
        string Fingerprint { get; }

        /// <summary>
        /// Width of the image in pixels, after any required rotation operation.
        /// </summary>
        int DotWidth { get; }

        /// <summary>
        /// Height of the image in pixels, after any required rotation operation.
        /// </summary>
        int DotHeight { get; }

        /// <summary>
        /// Width of the image in data stream samples.
        /// </summary>
        int RawDotWidth { get; }

        /// <summary>
        /// Height of the image in data stream samples.
        /// </summary>
        int RawDotHeight { get; }

        /// <summary>
        /// Aspect ratio of the image, as the width divided by the height.
        /// </summary>
        double AspectRatio { get; }

        /// <summary>
        /// Rotation operation that should be carried out on the image before drawing it.
        /// The <see cref="DotWidth"/> and <see cref="DotHeight"/> properties must give
        /// the width and height of the image after this transformation, not before.
        /// </summary>
        RightAngleRotation DrawingRotation { get; }
    }
}
